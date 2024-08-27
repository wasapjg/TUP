using Repository1.DATA;
using Repository1.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.SERVICES
{
    public class ProdServices 
    {
        private iProductRepository oRepository;   //creo una instancia de una interface  ¿POR QUÉ CREA UNA INSTANCIA DE INTERFACE Y NO DIRECTAMENTE LA CLASE QUE LA IMPLEMENTA???

        public ProdServices()
        {
            oRepository = new ProdRepositoryADO();    //Esa instancia de interfaz se implementa como una clase ProdRepositoryADO
        }

        public List<Product> GetProducts()
        {
            return oRepository.GetAll();
        }
    }
}
