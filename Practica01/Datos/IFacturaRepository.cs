using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IFacturaRepository
    {
        void Add(Facturas factura);
        void Delete(int id);
        Facturas GetById(int id);
        IEnumerable<Facturas> GetAll();
    }
}
