using Repository1.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.DATA
{
    public class DataHelper                    //DATA HELPER ES LA CAPA DONDE GUARDO TODA LA COMUNICACIÓN CON LA BD (ex AccesoBD)
                                               //Es importante mantener privada la conexión a la BD, para que solo se conecte desde un solo lugar. 

    {
        private static DataHelper instance;    //Única instancia que va a existir de la clase DataHelper; es static para darle esa unicidad
        private string strConnect;
        //private SqlConnection cnn;
        //private SqlCommand cmd;



        //Utiliza PATRÓN SINGLETON: para tener una sola instancia de esta clase.
        private DataHelper()                  //CONSTRUCTOR con la cadena de conexíón; es privado para que no puede ser llamado desde ningún otro lugar del código
        {
            strConnect = Properties.Resources.strConnect;
        }

        public static DataHelper GetInstance()     //método estático: se llama con el nombre de la clase, no de las instancias
        {
            if (instance == null)                    //si aún no fue creada, la crea
            {
                instance = new DataHelper();
            }
            return instance;                       //si ya fue creada, devuelve la existente
        }

        //private void Connect()
        //{

        //}

        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();
            try                                                       //Va dentro de un bloque try/catch, para salvar cualquier error en ejecución que pueda suceder: Exceptions
            {
                using (var cnn = new SqlConnection(strConnect))      //USING: crea el objeto de conexión y lo instancia llamando al constructor

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
        }

        public List<Product> ExecuteQuery()                            //Otra variante de CONSULTA DE BD, con SqLReader y mapeo en el Repository, devuelve directamente una lista (Ienumarable??)
        {
            List<Product> lst = new List<Product>();
            try 
            { 
            using (var cnn = new SqlConnection(strConnect))
            {
                cnn.Open();
                var query = $"SELECT * FROM Productos";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product aux = new Product();
                    aux.Codigo = reader.GetInt32(0);
                    aux.Nombre = reader.GetString(1);
                    aux.Precio = reader.GetFloat(2);
                    aux.Activo = reader.GetBoolean(3);
                    lst.Add(aux);
                }
            }
            return lst;
            }
            catch (SqlException) 
            {
                throw;
            }
        }
    }
}

