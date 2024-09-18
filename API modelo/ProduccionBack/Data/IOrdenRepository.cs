using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IOrdenRepository
    {
        List<Componente> ObtenerComponentes();
        bool CrearOrden(OrdenProduccion orden);

    
    }
}
