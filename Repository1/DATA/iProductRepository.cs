using Repository1.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1.DATA
{
    interface iProductRepository              //INTERFACE del REPOSITORY
    {
        List<Product> GetAll();
        Product? GetById(int id);         //? indica que el retorno puede ser nulo
        int Delete(int id); 
        int Save(Product product);      //SAVE va a servir tanto para el INSERT como el UPDATE dependiendo del contexto y del estado del objeto que se pasa como parámentro
    }
}
