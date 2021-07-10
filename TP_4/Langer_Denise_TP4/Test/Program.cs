using Entidades;
using Entidades.Clases;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Peluche peluche = new Peluche(false, EMateriales.Tela, 10, "Peluche Consola", "Osito", EColores.Blanco, 20, Peluche.EMedida.Centimetros);
            Muñeco muñeco = new Muñeco(EMateriales.Plastico, 15, "Muñeco Consola", "CascaNuez", 2, true, true);
            Inflable inflable = new Inflable(EMateriales.Hilo, 7, "Inflable Consola", Inflable.EDiseño.Colchoneta, EColores.Azul);

            Console.WriteLine("********* Agrego por primera vez *********\n");
            try
            {
                Fabrica.AgregarList(peluche);
                Fabrica.AgregarList(muñeco);
                Fabrica.AgregarList(inflable);
            }
            catch (Exception)
            {
            }

            Fabrica.Peluches.Add(peluche);
            Fabrica.Muñecos.Add(muñeco);
            Fabrica.Inflables.Add(inflable);

            Console.WriteLine("Hay cantidad de materiales para fabricar el peluche: " + Fabrica.ValidarProduccion(peluche, peluche.CantidadProduccion));
            Console.WriteLine("Hay cantidad de materiales para fabricar el muñeco: " + Fabrica.ValidarProduccion(muñeco, muñeco.CantidadProduccion));
            Console.WriteLine("Hay cantidad de materiales para fabricar el inflable: " + Fabrica.ValidarProduccion(inflable, inflable.CantidadProduccion));

            Console.WriteLine("\n********* Datos Actuales *********");
            Console.WriteLine("PELUCHE:\n" + peluche.MostrarDatos());
            Console.WriteLine("MUÑECO:\n" + muñeco.MostrarDatos());
            Console.WriteLine("INFLABLE:\n" + inflable.MostrarDatos());

            Console.WriteLine("********* Intento volver a agregar los mismos elementos *********");

            try
            {
                Fabrica.AgregarList(peluche);
                Fabrica.AgregarList(muñeco);
                Fabrica.AgregarList(inflable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSe lanza la excepcion porque el juguete ya fue registrado\n");
            }

            Console.WriteLine("********* Cambio de Diseño **********");

            Muñeco m1 = Fabrica.CambiarDiseñoMuñeco(muñeco, EMateriales.Hilo, 22, "Disney", "Oso", 5, false, false);
            Peluche p1 = Fabrica.CambiarDiseñoPeluche(peluche, EMateriales.Plastico, 17, "Disney", "Osito", EColores.Rojo, 550, Peluche.EMedida.Centimetros);
            Inflable i1 = Fabrica.CambiarDiseñoInflable(inflable, EMateriales.Plastico, 10, "Hasbro", Inflable.EDiseño.Pelota, EColores.Negro);

            Console.WriteLine("PELUCHE:\n" + p1.MostrarDatos());
            Console.WriteLine("MUÑECO:\n" + m1.MostrarDatos());
            Console.WriteLine("INFLABLE:\n" + i1.MostrarDatos());

            Console.WriteLine("********* Elimino los Juguetes **********");

            Console.WriteLine("Se eliminó: " + SQLConector.Delete(p1, p1.MarcaProducto, p1.Modelo));
            Console.WriteLine("Se eliminó: " + SQLConector.Delete(m1, m1.MarcaProducto, m1.Modelo));
            Console.WriteLine("Se eliminó: " + SQLConector.Delete(i1, i1.MarcaProducto, i1.Diseño.ToString()));


            Console.ReadKey();
        }
    }
}
