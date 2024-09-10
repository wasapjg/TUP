using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public  interface IDetallesFacturaRepository
    {
        void Add(DetallesFactura detalle);
        void Delete(DetallesFactura detalle);
        DetallesFactura GetById(int id);
        IEnumerable<DetallesFactura> GetAll();
    }
}
