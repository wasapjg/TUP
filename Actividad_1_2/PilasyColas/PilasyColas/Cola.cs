using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColas
{
    public class Cola : iCollection
    {

        private List<object> colas;   
        private int contador;
        public List<object> Colas
        {
            get { return colas; }
            set { colas = value; }
        }
        public int Contador
        {
            get { return contador; }
            set { contador = value; }
        }

        public Cola()                      
        {
            Colas = new List<object>();
            contador = 0;
        }

        public bool Añadir(object item) 
        {
                colas.Add(item);    
                contador++;
                return true;
        }

        public bool EstaVacia()
        {
            if( contador == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object Extraer()
        {
            object item = this.Primero();
            if (!this.EstaVacia())
            {
                colas.RemoveAt(0);   
                contador -=1;
            }
            return item;
        }

        public object Primero()
        {
            if (!this.EstaVacia())
            {
                return colas[0];
            }
            else
            {
                return "No hay elementos en la lista.";
            }
        }
    }
}
