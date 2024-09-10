using Actividad_Repository.DOMAIN;
using Actividad_Repository.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    public class TipoCuentaRepository : ITipoCuentaRepository
    {
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoCuenta> GetAll()
        {
            var dt = DataHelper.GetInstance().ExecuteSPQuery("OBTENER_TIPO_CUENTA");
            var list = new List<TipoCuenta>();
            foreach (DataRow dr in dt.Rows)
            {
                TipoCuenta tc = new TipoCuenta();
                tc.Id = Convert.ToInt32(dr["ID"]);
                tc.Nombre = dr["Nombre"].ToString();
                list.Add(tc);
            }
            return list;
        }

        public TipoCuenta GetByID()
        {
            throw new NotImplementedException();
        }

        public int Save(TipoCuenta tipoCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
