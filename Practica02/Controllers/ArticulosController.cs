using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica01.Datos;
using Practica01.Dominio;

namespace Practica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticulosRepository _articuloRepository;

        public ArticulosController(IArticulosRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        [HttpGet]
        public IEnumerable<Articulos> Get()
        {
            return _articuloRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Articulos Get(int id)
        {
            return _articuloRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Articulos articulo)
        {
            _articuloRepository.Add(articulo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _articuloRepository.Delete(id);
        }
    }
}
