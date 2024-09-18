using Actividad2_4.Domain;

namespace Actividad2_4.Data
{
    public interface IAplicacionRepository
    {
        void Add(Productos p);
        void Delete(int id);
        void Update(Productos p);
        Productos FindById(int id);
        List<Productos> GetAll();
    }

    public class AplicacionRepository : IAplicacionRepository
    {
        private static readonly List<Productos> _productos = new List<Productos>();

        public void Add(Productos p)
        {
            _productos.Add(p);
        }

        public void Delete(int id)
        {
            var producto = _productos.Find(prod => prod.Id == id);

            if (producto != null)
            {
                _productos.Remove(producto);
            }
            else
            {
                throw new Exception("Producto no encontrado");
            }
        }

        public Productos FindById(int id)
        {
            var producto = _productos.Find(prod => prod.Id == id);
            return producto != null ? producto : throw new Exception("Producto no encontrado");
        }

        public List<Productos> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Productos p)
        {
            throw new NotImplementedException();
        }
    }
}
