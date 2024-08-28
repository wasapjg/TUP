using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DOMAIN
{
    public class Cuentas
    {
        public int Id_Cuenta { get; set; }
        public string CBU { get; set; }
        public decimal Saldo { get; set; }
        public int Tipo_cuenta_id { get; set; }
        public DateTime Ultimo_Movimiento { get; set; }
        public int Cliente_id { get; set; }
    }
}
