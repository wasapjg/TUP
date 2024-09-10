// Crear una instancia del servicio que contiene los métodos para manejar facturas
using Practica01.Datos;
using Practica01.Dominio;
using Practica01.Servicios;

FacturaServices facturaService = new FacturaServices();


var oFP = new FormasPagoServices();
var fp = oFP.GetTipoCuenta();

var oA = new ArticulosServices();
var a = oA.GetTipoCuenta();


// Crear detalles de la factura
DetallesFactura detalle1 = new DetallesFactura { Articulo = a[0], Cantidad = 2 };
DetallesFactura detalle2 = new DetallesFactura { Articulo = a[1], Cantidad = 1 };
DetallesFactura detalle3 = new DetallesFactura { Articulo = a[0], Cantidad = 3 };

List<DetallesFactura> detallesFactura = new List<DetallesFactura> { detalle1, detalle2, detalle3 };

var df = facturaService.ConsolidarDetalles(detallesFactura);

// Crear una factura
Facturas factura = new Facturas
{
    Fecha = DateTime.Now,
    Cliente = "Cliente de Prueba 2.0",
    FormaPago = fp[1],
    Detalles = df
};

// Agregar la factura a la base de datos
try
{
    facturaService.AgregarFactura(factura);
    Console.WriteLine("Factura creada e insertada con éxito.");
}
catch (Exception ex)
{
    Console.WriteLine("Error al insertar la factura: " + ex.Message);
}

Console.WriteLine("\nPresiona cualquier tecla para salir...");
Console.ReadKey();