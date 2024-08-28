using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    interface ICuentaRepository
    {
        List<Cuentas> GetAll();
        Cuentas GetByID(int id);
        int Delete(int id);
        int Save(Cuentas cliente);
    }
}
