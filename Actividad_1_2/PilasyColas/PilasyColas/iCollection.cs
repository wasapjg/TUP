using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColas
{
    interface iCollection
    {
        bool EstaVacia();
        object Extraer();
        object Primero();
        bool Añadir(object item); 
    }
}
