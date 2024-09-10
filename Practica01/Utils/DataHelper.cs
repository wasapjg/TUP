using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Utils
{
    public class DataHelper
    {
        private static DataHelper? instance;
        private readonly SqlConnection _strCnn;

        public DataHelper()
        {
            _strCnn = new SqlConnection(Properties.Resources.StrCnn);
        }

        public static DataHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHelper();
            }
            return instance;
        }

        public SqlConnection GetConnection()
        {
            return _strCnn;
        }

        public DataTable ExecuteSPQuery(string sp)
        {
            var dt = new DataTable();
            try
            {
                _strCnn.Open();
                var cmd = new SqlCommand(sp, _strCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el SP: " + ex.Message);
            }
            finally
            {
                _strCnn.Close();
            }
        }
        public DataTable ExecuteSPQuery(string sp, List<Parametros> p)
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    _strCnn.Open();
                    var cmd = new SqlCommand(sp, _strCnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in p)
                    {
                        cmd.Parameters.Add(item);
                    }
                    dt.Load(cmd.ExecuteReader());
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar el SP: " + ex.Message);
            }
            finally
            {
                _strCnn.Close();
            }
        }

    }
}