using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public interface IArticulosRepository
    {
        void Add(Articulos articulo);
        void Delete(Articulos articulo);
        Articulos GetById(int id);
        IEnumerable<Articulos> GetAll();
    }
}
