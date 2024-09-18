using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public interface IProduccionService
    {
        List<Componente> ConsultarComponentes();
        bool RegistrarProduccion(OrdenProduccion orden);
 
    }
}
