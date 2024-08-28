using Actividad_Repository.DOMAIN;
using Actividad_Repository.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.DATA
{
    public class CuentaRepository : ICuentaRepository
    {
        public int Delete(int id)
        {
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("@id", id.ToString()));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("DELETE_CUENTA", list);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public List<Cuentas> GetAll()
        {
            List<Cuentas> list = new List<Cuentas>();
            var dt = DataHelper.GetInstance().ExecuteSPQuery("OBTENER_CUENTAS");
            foreach (DataRow r in dt.Rows)
            {
                Cuentas c = new Cuentas();
                c.Id_Cuenta = Convert.ToInt32(r[0]);
                c.CBU = r[1].ToString();
                c.Saldo = Convert.ToDecimal(r[2]);
                c.Tipo_cuenta_id = Convert.ToInt32(r[3]);
                c.Ultimo_Movimiento = (DateTime) r[4];
                c.Cliente_id = Convert.ToInt32(r[5]);
                list.Add(c);
            }
            return list;
        }

        public Cuentas GetByID(int id)
        {
            Cuentas c = new Cuentas();
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("@id", id.ToString()));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("OBTENER_CLIENTE_ID", list);
            foreach (DataRow r in dt.Rows)
            {
                c.Id_Cuenta = Convert.ToInt32(r[0]);
                c.CBU = r[1].ToString();
                c.Saldo = Convert.ToDecimal(r[2]);
                c.Tipo_cuenta_id = Convert.ToInt32(r[3]);
                c.Ultimo_Movimiento = (DateTime) r[4];
                c.Cliente_id = Convert.ToInt32(r[5]);
            }
            return c;
        }

        public int Save(Cuentas cliente)
        {
            List<Parametros> list = new List<Parametros>();
            list.Add(new Parametros("@cbu", cliente.CBU));
            list.Add(new Parametros("@saldo", cliente.Saldo.ToString()));
            list.Add(new Parametros("@tipo_cuenta_id", cliente.Tipo_cuenta_id.ToString()));
            list.Add(new Parametros("@ultimo_movimiento", cliente.Ultimo_Movimiento.ToString()));
            list.Add(new Parametros("@cliente_id", cliente.Cliente_id.ToString()));
            var dt = DataHelper.GetInstance().ExecuteSPQuery("CREATE_CUENTA", list);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
