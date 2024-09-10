using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IFormasPagoRepository
    {
        void Add(FormasPago formaPago);
        void Delete(FormasPago formaPago);
        FormasPago GetById(int id);
        IEnumerable<FormasPago> GetAll();
    }
}
