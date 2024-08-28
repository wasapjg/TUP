using Actividad_Repository.DATA;
using Actividad_Repository.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repository.SERVICE
{
    public class ClienteService
    {
        private IClienteRepository oRepository;

        public ClienteService()
        {
            oRepository = new ClienteRepositoryADO(); 
        }

        public List<Clientes> GetClientes()
        {
            return oRepository.GetAll();
        }

        public Clientes GetClienteByID(int id)
        {
            return oRepository.GetByID(id);
        }

        public int DeleteCliente(int id)
        {
            return oRepository.Delete(id);
        }

        public int SaveCliente(Clientes cliente)
        {
            return oRepository.Save(cliente);
        }
    }
}
