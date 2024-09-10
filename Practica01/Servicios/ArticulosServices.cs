using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class ArticulosServices
    {
        private IArticulosRepository oArticulosRepo;

        public ArticulosServices()
        {
            oArticulosRepo = new ArticulosRepositoryADO();
        }

        public List<Articulos> GetTipoCuenta()
        {
            return (List<Articulos>)oArticulosRepo.GetAll();
        }
    }
}
