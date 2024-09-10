using Practica01.Dominio;
using Practica01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        public void Add(Facturas factura)
        {
            using (SqlConnection cnn = DataHelper.GetInstance().GetConnection())
            {
                SqlTransaction t = null;
                try
                {
                    cnn.Open();
                    t = cnn.BeginTransaction();

                    // Insertar Factura
                    using (SqlCommand cmd = new SqlCommand("sp_InsertFactura", cnn, t))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                        cmd.Parameters.AddWithValue("@idFormaPago", factura.FormaPago.Id);
                        cmd.Parameters.AddWithValue("@cliente", factura.Cliente);

                        SqlParameter param = new SqlParameter("@nroFactura", SqlDbType.Int);
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();

                        var idFactura = Convert.ToInt32(param.Value);

                        // Insertar Detalles de Factura
                        foreach (DetallesFactura detalle in factura.Detalles)
                        {
                            using (SqlCommand cmdDetalle = new SqlCommand("sp_InsertDetalleFactura", cnn, t))
                            {
                                cmdDetalle.CommandType = CommandType.StoredProcedure;
                                cmdDetalle.Parameters.AddWithValue("@nroFactura", idFactura);
                                cmdDetalle.Parameters.AddWithValue("@idArticulo", detalle.Articulo.IdArticulo);
                                cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }
                    }

                    t.Commit();
                }
                catch (Exception ex)
                {
                    // Si hay una excepción, hacer rollback
                    t?.Rollback();
                    throw new Exception("Error al insertar la factura y sus detalles: " + ex.Message);
                }
                finally
                {
                    cnn.Close();
                }
            }
        }

        public List<DetallesFactura> ConsolidarDetalles(List<DetallesFactura> detalles)
        {
            // Utilizar un diccionario para consolidar los artículos por IdArticulo
            Dictionary<int, DetallesFactura> detallesConsolidados = new Dictionary<int, DetallesFactura>();

            foreach (var detalle in detalles)
            {
                if (detallesConsolidados.ContainsKey(detalle.Articulo.IdArticulo))
                {
                    // Si el artículo ya existe, incrementa la cantidad
                    detallesConsolidados[detalle.Articulo.IdArticulo].Cantidad += detalle.Cantidad;
                }
                else
                {
                    // Si el artículo no existe, añadirlo al diccionario
                    detallesConsolidados.Add(detalle.Articulo.IdArticulo, detalle);
                }
            }

            // Devolver la lista consolidada de detalles
            return detallesConsolidados.Values.ToList();
        }



        public void Delete(int id)
        {
            DataHelper.GetInstance().ExecuteSPQuery("sp_DeleteFactura", new List<Parametros> { new Parametros("id", id) });
        }

        public IEnumerable<Facturas> GetAll()
        {
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_GetFacturas");
            List<Facturas> lista = new List<Facturas>();
            foreach (DataRow row in dt.Rows)
            {
                Facturas factura = new Facturas();
                factura.NroFactura = Convert.ToInt32(row["nroFactura"]);
                factura.Fecha = Convert.ToDateTime(row["fecha"]);
                factura.FormaPago = new FormasPago
                {
                    Id = (int)row["idFormaPago"]
                };
                factura.Cliente = row["cliente"].ToString();

                lista.Add(factura);

                Articulos articulo = new Articulos
                {
                    IdArticulo = Convert.ToInt32(row["idArticulo"]),
                    Nombre = row["nombre"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(row["precioUnitario"])
                };


                // Agregar el detalle de la factura
                DetallesFactura detalle = new DetallesFactura();
                {
                    detalle.Articulo = articulo;
                    detalle.Cantidad = Convert.ToInt32(row["cantidad"]);
                    detalle.PrecioUnitario = Convert.ToDecimal(row["precioUnitario"]);
                    detalle.Factura = factura;
                };

                factura.Detalles.Add(detalle);
            }
            return lista;
        }

        public Facturas GetById(int id)
        {
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("id", id));

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_GetFacturaById", list);

            Facturas factura = null;

            foreach (DataRow dr in dt.Rows)
            {
                factura = new Facturas();
                {
                    factura.NroFactura = Convert.ToInt32(dr["nroFactura"]);
                    factura.Fecha = Convert.ToDateTime(dr["fecha"]);
                    factura.Cliente = dr["cliente"].ToString();
                    factura.FormaPago = new FormasPago
                    {
                        Id = (int)dr["id_forma_pago"]
                    };
                    factura.Detalles = new List<DetallesFactura>();
                };

                Articulos articulo = new Articulos
                {
                    IdArticulo = Convert.ToInt32(dr["idArticulo"]),
                    Nombre = dr["nombre"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(dr["precioUnitario"])
                };


                // Agregar el detalle de la factura
                DetallesFactura detalle = new DetallesFactura();
                {
                    detalle.Articulo = articulo;
                    detalle.Cantidad = Convert.ToInt32(dr["cantidad"]);
                    detalle.PrecioUnitario = Convert.ToDecimal(dr["precioUnitario"]);
                    detalle.Factura = factura;
                }; 

                factura.Detalles.Add(detalle);
            }

            return factura;
        }
    }
}
