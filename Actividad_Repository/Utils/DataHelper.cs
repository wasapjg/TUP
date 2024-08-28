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
        private string StrCnn;

        private DataHelper()
        {
            StrCnn = Resources.StrCnn;
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
            DataTable dt = new DataTable();
            var cnn = new SqlConnection(StrCnn);     //USING: crea el objeto de conexión y lo instancia llamando al constructor
            try                                                       //Va dentro de un bloque try/catch, para salvar cualquier error en ejecución que pueda suceder: Exceptions
            {

                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
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
                cnn.Close();
            }
        }

        public DataTable ExecuteSPQuery(string sp, List<Parametros> p)
        {
            DataTable dt = new DataTable();
            var cnn = new SqlConnection(StrCnn);     
            try                                                       
            {
                {
                    cnn.Open();
                    var cmd = new SqlCommand(sp, cnn);
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
                cnn.Close();
            }
        }
    }
}
