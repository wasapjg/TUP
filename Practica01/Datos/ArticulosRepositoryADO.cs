using Practica01.Dominio;
using Practica01.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class ArticulosRepositoryADO : IArticulosRepository
    {
        public void Add(Articulos articulo)
        {
            throw new NotImplementedException();
        }

        public void Delete(Articulos articulo)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
