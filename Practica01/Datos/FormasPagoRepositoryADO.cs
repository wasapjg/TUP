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
    public class FormasPagoRepositoryADO : IFormasPagoRepository
    {
        public void Add(FormasPago formaPago)
        {
            throw new NotImplementedException();
        }

        public void Delete(FormasPago formaPago)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FormasPago> GetAll()
        {
            List<FormasPago> formasPago = new List<FormasPago>();

            // Llamada al procedimiento almacenado para obtener todas las formas de pago
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("sp_GetFormasPago");

            foreach (DataRow dr in dt.Rows)
            {
                FormasPago formaPago = new FormasPago
                {
                    Id = Convert.ToInt32(dr["idFormaPago"]),
                    Forma = dr["Nombre"].ToString()
                };
                formasPago.Add(formaPago);
            }

            return formasPago;
        }

        public FormasPago GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
