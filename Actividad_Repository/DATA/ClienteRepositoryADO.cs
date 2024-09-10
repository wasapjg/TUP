using Actividad_Repository.DOMAIN;
using Actividad_Repository.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    public class ClienteRepositoryADO : IClienteRepository
    {
        public int Delete(int id)
        {
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("@id", id.ToString()));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("DELETE_CLIENTE", list);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public List<Clientes> GetAll()
        {
            List<Clientes> list = new List<Clientes>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("OBTENER_CLIENTES");
            foreach (DataRow r in dt.Rows)
            {
                Clientes c = new Clientes();
                c.Id_Cliente = Convert.ToInt32(r[0]);
                c.Nombre = r[1].ToString();
                c.Apellido = r[2].ToString();
                c.DNI = r[3].ToString();
                list.Add(c);
            }
            return list;
        }

        public Clientes GetByID(int id)
        {
            Clientes c = new Clientes();
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("@id", id.ToString()));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("OBTENER_CLIENTE_ID", list);
            foreach (DataRow r in dt.Rows)
            {
                c.Id_Cliente = Convert.ToInt32(r[0]);
                c.Nombre = r[1].ToString();
                c.Apellido = r[2].ToString();
                c.DNI = r[3].ToString();
            }
            return c;
        }

        public int Save(Clientes c)
        {
            //var dt = DataHelper.GetInstance().ExecuteSPQuery($"CREATE_CLIENTE");
            //List<Parametros> list = new List<Parametros>();
            // list.Add(new Parametros("@nombre", c.Nombre));
            // list.Add(new Parametros("@apellido", c.Apellido));
            // list.Add(new Parametros("@dni", c.DNI));
            // var dt = DataHelper.GetInstance().ExecuteSPQuery("CREATE_CLIENTE", list);
            // return Convert.ToInt32(dt.Rows[0][0]);
            SqlConnection cnn = null;
            SqlTransaction t = null;
            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("CREATE_CLIENTE", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                cmd.Parameters.AddWithValue("@dni", c.DNI);
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                var id = Convert.ToInt32(param.Value);
                foreach (Cuentas cuenta in c.Cuentas)
                {
                    var cmdCuenta = new SqlCommand("CREATE_CUENTA", cnn, t);
                    cmdCuenta.CommandType = CommandType.StoredProcedure;
                    cmdCuenta.Parameters.AddWithValue("@cbu", cuenta.CBU);
                    cmdCuenta.Parameters.AddWithValue("@saldo", cuenta.Saldo);
                    cmdCuenta.Parameters.AddWithValue("@tipo_cuenta_id", cuenta.Tipo_cuenta_id);
                    cmdCuenta.Parameters.AddWithValue("@ultimo_movimiento", cuenta.Ultimo_Movimiento);
                    cmdCuenta.Parameters.AddWithValue("@cliente_id", id);
                    cmdCuenta.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                    return 0;
                }
            }
            finally
            {
                if (t != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return 3;

        }
    }
}
