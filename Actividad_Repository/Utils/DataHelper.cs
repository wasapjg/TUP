using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actividad_Repository.Properties;
using Actividad_Repository.DOMAIN;


namespace Actividad_Repository.Utils
{
    public class DataHelper
    {
        private static DataHelper? instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.StrCnn);
        }

        public static DataHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHelper();
            }
            return instance;
        }

        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();  //USING: crea el objeto de conexión y lo instancia llamando al constructor
            try                                                       //Va dentro de un bloque try/catch, para salvar cualquier error en ejecución que pueda suceder: Exceptions
            {

                {
                    _connection.Open();

                    var cmd = new SqlCommand(sp, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;        //Tengo que dejar indicado que lo que le voy a pasar es un SP y no una query
                    dt.Load(cmd.ExecuteReader());

                }

                return dt;
            }
            catch (SqlException) //CONTROLA POSIBLE ERROR MIENTRAS SE CONSULTA LA BD
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteSPQuery(string sp, List<Parametros> p)
        {
            DataTable dt = new DataTable();
            try                                                       
            {
                {
                    _connection.Open();
                    var cmd = new SqlCommand(sp, _connection);
                    cmd.CommandType = CommandType.StoredProcedure;        
                    foreach (var item in  p)
                    {
                        cmd.Parameters.Add(item);
                    }
                    dt.Load(cmd.ExecuteReader());
                }
                return dt;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
