using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class FormasPagoServices
    {
        private IFormasPagoRepository oFormasPagoRepository;

        public FormasPagoServices()
        {
            oFormasPagoRepository = new FormasPagoRepositoryADO();
        }

        public List<FormasPago> GetTipoCuenta()
        {
            return (List<FormasPago>)oFormasPagoRepository.GetAll();
        }
    }
}
