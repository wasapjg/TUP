using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    interface ITipoCuentaRepository
    {
        List<TipoCuenta> GetAll();
        TipoCuenta GetByID();
        int Delete(int id);
        int Save(TipoCuenta tipoCuenta);
    }
}
