using Practica01.Dominio;
using Practica01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practica01.Datos
{
    public class ArticulosRepositoryADO : IArticulosRepository
    {
        public void Add(Articulos articulo)
        {
            Console.WriteLine(articulo.PrecioUnitario);
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@nombre", articulo.Nombre));
            parametros.Add(new Parametros("@precioUnitario", articulo.PrecioUnitario));

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_InsertArticulo", parametros);
        }

        public void Delete(int id)
        {
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@id", id));
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_DeleteArticulo");
        }

        public IEnumerable<Articulos> GetAll()
        {
            List<Articulos> articulos = new List<Articulos>();
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_GetArticulos");

            foreach (DataRow dr in dt.Rows)
            {
                Articulos articulo = new Articulos
                {
                    IdArticulo = Convert.ToInt32(dr["IdArticulo"]),
                    Nombre = dr["Nombre"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"])
                };
                articulos.Add(articulo);
            }

            return articulos;
        }

        public Articulos GetById(int id)
        {
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("id", id));
            Articulos articulos = new Articulos();

            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_GetArticuloById", list);


            foreach (DataRow dr in dt.Rows)
            {
                Articulos articulo = new Articulos
                {
                    IdArticulo = Convert.ToInt32(dr["IdArticulo"]),
                    Nombre = dr["Nombre"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"])
                };
            }

            return articulos;
        }
    }
}
