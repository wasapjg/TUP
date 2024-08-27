using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilasyColas
{
    public class Pila : iCollection
    {
        private object[] pilas;                       //arreglo como atributo
        private int contador;
        public object[] Pilas
        {
            get { return pilas; }
            set { pilas = value; }
        }
        public int Contador
        {
            get { return contador; }
            set { contador = value; }
        }

        public Pila(int tamanio)                      //constructor que define longitud del arreglo
        {
            pilas = new object[tamanio];
            contador = 0;
        }

        public bool Añadir(object item)
        {
            if (contador < pilas.Length)
            {
                pilas[contador] = item;   
                contador++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EstaVacia()
        {
            if (contador == 0)        //Si el contador está en 0, es porque no se agregó nada, porque el método Añadir, suma al contador cuando se agrega un elemento. 
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
                pilas[contador - 1] = null;   //Pone a null la última posición ocupada, que no es lo mismo que la última posición de la longitud total
                contador -= 1;
            }
            return item;

        }

        public object Primero()
        {
            if(!this.EstaVacia())
            {
                return pilas[contador - 1];
            }
            else
            {
                return "El arreglo está vacío.";
            }
        }
    }
}
