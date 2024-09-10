// listar tipos de cuentas
// objeto cliente
// objetos cuentas
// agregar a la lista de clientes.cuentas


using Actividad_Repository.DOMAIN;
using Actividad_Repository.SERVICE;

var oTP = new TipoCuentaService();

var tp = oTP.GetTipoCuenta();

var oCliente = new ClienteService();
var oCuenta = new CuentaService();

var cliente = new Clientes()
{
    Nombre = "Juan",
    Apellido = "Perez",
    DNI = "12345678",
    Cuentas = new List<Cuentas>()
    {
        new Cuentas()
        {
            Tipo_cuenta_id = tp[0].Id,
            CBU = "1234",
            Ultimo_Movimiento = DateTime.Now,
            Saldo = 1000
        },
        new Cuentas()
        {
            Tipo_cuenta_id = tp[0].Id,
            CBU = "4321",
            Ultimo_Movimiento = DateTime.Now,
            Saldo = 4000
        }
    }
};

var clientes = oCliente.SaveCliente(cliente);