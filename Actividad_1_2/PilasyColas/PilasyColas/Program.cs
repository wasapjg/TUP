// See https://aka.ms/new-console-template for more information


using PilasyColas;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main()
    {
        Console.WriteLine("PRUEBA PILAS\nDefina la cantidad de elementos a ingresar");
        int tamanio = Convert.ToInt32(Console.ReadLine());
        var Pilase = new Pila(tamanio);
        for (int i = 0; i < Pilase.Pilas.Length; i++)                     //ciclo for para llenar el array; recurre al método añadir propio de la clase pila
        {
            Console.WriteLine("Ingrese el elemento: ");
            object item = Console.ReadLine();
            Pilase.Añadir(item);
            Console.WriteLine("Ha incorporado el elemento " + item);
        }
        if (Pilase.EstaVacia() == false)
        {
            Console.WriteLine("Su pila tiene " + Pilase.Contador + " elementos. \nEstos son: ");
            for (int i = 0; i < Pilase.Pilas.Length; i++)               //for para recorrer los valores del arreglo
            {
                Console.WriteLine(Pilase.Pilas[i]);
            }
        }
        Console.WriteLine("¿Quiere hacer funcionar la pila? S/N");
        string flag = Console.ReadLine();
        if (flag == "S")
        {
            Console.WriteLine("En la estructura LIFO, el último elemento ingresado es el primero en salir");
            Console.WriteLine("En este caso:\n" + Pilase.Extraer() + " es el primero en salir");
            Console.WriteLine("Los elementos del arreglo ahora son: ");
            for (int i = 0; i < Pilase.Pilas.Length; i++)  
            {
                Console.WriteLine(Pilase.Pilas[i]);
            }
            Console.WriteLine("\nEl próximo elemento en salir es " + Pilase.Primero());
        }
        else if (flag == "N")
        {
            Console.WriteLine("Muchas gracias por usar nuestros servicios");
        }


        Console.WriteLine("PRUEBA COLAS");
        var Colase = new Cola();
        Colase.Añadir("7 de basto");
        Colase.Añadir("2 de oro");
        Colase.Añadir("4 de copas");
        foreach (object co in Colase.Colas)
        {
            Console.WriteLine(co);
        }
        Console.WriteLine("La lista de colas tiene " + Colase.Contador + " elementos");
        Console.WriteLine("En la estructura FIFO, el primero en entrar es el primero en salir");
        Console.WriteLine("El primero en cola es " + Colase.Primero());
        Console.WriteLine("Sale " + Colase.Extraer() + " y en la lista quedan\n");
        foreach (object co in Colase.Colas)
        {
            Console.WriteLine(co);
        }
    }
}