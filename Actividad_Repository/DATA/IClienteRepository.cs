using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    interface IClienteRepository
    {
        List<Clientes> GetAll();
        Clientes? GetByID(int id);
        int Delete(int id);
        int Save(Clientes cliente);
    }
}
