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
    public class ProdRepositoryADO : iProductRepository
    {

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_recuperar");  //INVOCA AL MÉTODO ESTÁTICO DE LA CLASE DATAHELPER, LUEGO AL MÉTODO QUE HACE LA CONSULTA Y MANDA LA QUERY CON FORMA DE sp
                                                                               //El método estático del DataHelper crea la instancia, por eso no hace falta crearla como atributo en esta clase. 
            
            foreach (DataRow dr in dt.Rows)                      //Si bien recibe una DataTable desde el DataHelper, con cada fila de la tabla, rellena la lista que va a devolver al service
            {
                Product p = new Product();                      //Por cada fila que trae el método, creo un objeto y lo mapeo: cargo sus properties con el contenido de cada columna
                p.Codigo = Convert.ToInt32(dr[0]);              //Si o si hay que castear, se suele usar el casteo explícito más que el convert
                p.Nombre = (string)(dr[1]);
                p.Precio = Convert.ToDouble(dr[2]);
                p.Stock = Convert.ToInt32(dr[3]);
                p.Activo = Convert.ToBoolean(dr[4]);
                list.Add(p);
            }   
            return list;
        }

        public List<Product> GetAll2()                        //Llama al método alternativo para consultar toda la BD
        {
            List<Product> lst = new List<Product>();
            lst = DataHelper.GetInstance().ExecuteQuery();
            return lst;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Product product)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
