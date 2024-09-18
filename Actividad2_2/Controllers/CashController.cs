using Actividad2_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividad2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private static  readonly List<Moneda> monedas = new List<Moneda>();

        //public CashController()
        //{
        //    monedas = new List<Moneda>();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Moneda>> Get()
        {
            if(monedas.Count == 0)
            {
                return NotFound("No se encontraron monedas");
            }

            return Ok(monedas);
        }

        [HttpGet("{nombre}", Name = "GetMonedaById")]
        public IActionResult Get(string nombre)
        {
            Moneda moneda = monedas.Find(m => m.Nombre == nombre);

            if (moneda == null)
            {
                return NotFound("No se encontraron resultados");
            }

            return Ok(moneda);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Moneda moneda)
        {
            try
            {
                if(moneda != null)
                {
                    monedas.Add(moneda);
                    return CreatedAtRoute("GetMonedaById", new { nombre = moneda.Nombre }, moneda);
                }
                else
                {
                    return BadRequest("No se pudo agregar la moneda");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
