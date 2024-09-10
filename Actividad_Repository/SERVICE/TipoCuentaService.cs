using Actividad_Repository.DATA;
using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.SERVICE
{
    public class TipoCuentaService
    {
        private ITipoCuentaRepository oTipoCuenta;

        public TipoCuentaService()
        {
            oTipoCuenta = new TipoCuentaRepository();
        }

        public List<TipoCuenta> GetTipoCuenta()
        {
            return oTipoCuenta.GetAll();
        }
    }
}
