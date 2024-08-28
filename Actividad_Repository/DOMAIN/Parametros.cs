using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DOMAIN
{
    public class Parametros
    {
        public Parametros(string nombre, string valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
