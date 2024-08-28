using Actividad_Repository.DATA;
using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.SERVICE
{
    public class CuentaService
    {
        private ICuentaRepository oRepository;

        public CuentaService()
        {
            oRepository = new CuentaRepository();
        }

        public List<Cuentas> GetCuentas()
        {
            return oRepository.GetAll();
        }

        public Cuentas GetCuentaByID(int id)
        {
            return oRepository.GetByID(id);
        }

        public int DeleteCuenta(int id)
        {
            return oRepository.Delete(id);
        }

        public int SaveCuenta(Cuentas cuenta)
        {
            return oRepository.Save(cuenta);
        }
    }
}
