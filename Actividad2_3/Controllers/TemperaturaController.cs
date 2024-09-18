using Actividad2_3.Model;
using Actividad2_3.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividad2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TemperaturaController : ControllerBase
    {
        public readonly RegistroTemp Temp = RegistroTemp.Instance;

        [HttpGet]
        public IActionResult Get()
        {
            if (Temp.GetTemp().Count == 0)
            {
                return BadRequest("No se encontraron temperaturas");
            }
            return Ok(Temp.GetTemp());
        }

        [HttpGet ("{iot}", Name = "GetTempById")]
        public IActionResult GetById(int iot)
        {
            var temp = Temp.GetTemp(iot);
            if (temp == null)
            {
                return BadRequest("No se encontró la temperatura");
            }
            return Ok(temp);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Temperatura temp)
        {
            try
            {
                if (temp != null)
                {
                    Temp.AddTemp(temp);
                    return CreatedAtRoute("GetTempById", new { iot = temp.IOT }, temp);
                }
                else
                {
                    return BadRequest("No se pudo agregar la temperatura");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
