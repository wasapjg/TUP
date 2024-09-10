using Practica01.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01.Datos
{
    public class Facturas
    {
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public FormasPago? FormaPago { get; set; }
        public string Cliente { get; set; }
        public List<DetallesFactura> Detalles { get; set; } = new List<DetallesFactura>();
    }
}
