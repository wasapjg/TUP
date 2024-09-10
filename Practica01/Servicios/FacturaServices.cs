using Practica01.Datos;
using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Servicios
{
    public class FacturaServices
    {
        private IFacturaRepository _facturaRepository;

        private FacturaRepositoryADO fr = new FacturaRepositoryADO();
        public FacturaServices()
        {
            _facturaRepository = new FacturaRepositoryADO();
        }

        public IEnumerable<Facturas> ListarFacturas()
        {
            return _facturaRepository.GetAll();
        }

        public Facturas BuscarFactura(int nroFactura)
        {
            return _facturaRepository.GetById(nroFactura);
        }

        public void AgregarFactura(Facturas factura)
        {
            _facturaRepository.Add(factura);
        }

        public List<DetallesFactura> ConsolidarDetalles(List<DetallesFactura> df)
        {
            return fr.ConsolidarDetalles(df);
        }

        public void EliminarFactura(int nroFactura)
        {
            _facturaRepository.Delete(nroFactura);
        }
    }
}
