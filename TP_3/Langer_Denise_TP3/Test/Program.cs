using Entidades;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Fabrica fabrica = new Fabrica("Toy Story");
            Peluche peluche = new Peluche(EMateriales.Tela, 10, "Disney", "Osito", EColores.Blanco, 20, Peluche.EMedida.Centimetros);
            Muñeco muñeco = new Muñeco(EMateriales.Plastico, 15, "Barbie", 2, true, true);
            Inflable inflable = new Inflable(EMateriales.Hilo, 7, "Hasbro", Inflable.EDiseño.Colchoneta, EColores.Azul);
            bool seAgrego = false;

            fabrica.AgregarList(peluche);
            Console.WriteLine(peluche.MostrarDatos());
            fabrica.AgregarList(muñeco);
            Console.WriteLine(muñeco.MostrarDatos());
            fabrica.AgregarList(inflable);
            Console.WriteLine(inflable.MostrarDatos());

            seAgrego = fabrica.ValidarProduccion(peluche, 10);
            Console.WriteLine($"Se agregaron los elementos a la lista: {seAgrego}\n");
            Console.WriteLine("*********Cambio de Diseño**********");

            Muñeco m1 = fabrica.CambiarDiseñoMuñeco(muñeco, EMateriales.Hilo, 22, "Disney", 5, false, false);
            Peluche p1 = fabrica.CambiarDiseñoPeluche(peluche, EMateriales.Plastico, 17, "Disney", "Osito", EColores.Rojo, 550, Peluche.EMedida.Centimetros);
            Inflable i1 = fabrica.CambiarDiseñoInflable(inflable,EMateriales.Plastico, 10, "Hasbro", Inflable.EDiseño.Pelota, EColores.Negro);

            Console.WriteLine(m1.MostrarDatos());
            Console.WriteLine(p1.MostrarDatos());
            Console.WriteLine(i1.MostrarDatos());

            Console.ReadKey();
        }
    }
}
