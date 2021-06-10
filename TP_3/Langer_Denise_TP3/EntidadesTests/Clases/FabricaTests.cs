using Entidades.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Entidades.Tests
{
    [TestClass()]
    public class FabricaTests
    {

        [TestMethod()]
        public void AgregarListTest()
        {
            Fabrica fabrica = new Fabrica("Test");
            Muñeco muñeco = new Muñeco(EMateriales.Tela, 10, "Example");

            fabrica.AgregarList(muñeco);
            Assert.IsTrue(fabrica.Juguetes.Count > 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(JugueteYaExisteException))]
        public void AgregarListThrowException()
        {
            Fabrica fabrica = new Fabrica("Test");
            Muñeco muñeco1 = new Muñeco(EMateriales.Tela, 10, "Example");
            Muñeco muñeco2 = new Muñeco(EMateriales.Hilo, 5, "example");

            fabrica.AgregarList(muñeco1);
            fabrica.AgregarList(muñeco2);
        }

        [TestMethod()]
        public void ValidarProduccionTest()
        {
            Fabrica fabrica = new Fabrica("Test");
            Peluche peluche = new Peluche(EMateriales.Hilo, 5, "Example");
            int cantidadNecesaria = peluche.CalcularMateriales(peluche.CantidadProduccion);
            MateriaPrima.UsarMateriales(peluche.Material, cantidadNecesaria);
            Assert.IsTrue(MateriaPrima.CantidadHilo >= 0);
            Assert.IsTrue(fabrica.ValidarProduccion(peluche, cantidadNecesaria));
        }

        [TestMethod()]
        [ExpectedException(typeof(NoMaterialesException))]
        public void ValidarProduccion_ThrowException()
        {
            Fabrica fabrica = new Fabrica("Test");
            Peluche peluche = new Peluche(EMateriales.Hilo, 500, "Example");
            int cantidadNecesaria = peluche.CalcularMateriales(peluche.CantidadProduccion);
            MateriaPrima.UsarMateriales(peluche.Material, cantidadNecesaria);
        }

        [TestMethod()]
        public void CambiarDiseñoMuñecoTest()
        {
            Fabrica fabrica = new Fabrica("Test");
            Muñeco muñeco = new Muñeco(EMateriales.Plastico, 2, "Example", 2, true, false);
            Muñeco muñeco1 = fabrica.CambiarDiseñoMuñeco(muñeco, EMateriales.Hilo, 4, "Example", 5, false, false);
            Assert.IsNotNull(muñeco1);
            Assert.IsTrue(fabrica.Juguetes.Count > 0);
        }

        [TestMethod()]
        public void CambiarDiseñoPelucheTest()
        {
            Fabrica fabrica = new Fabrica("Test");
            Peluche peluche = new Peluche(EMateriales.Plastico, 2, "Example", "osito", EColores.Azul, 20, Peluche.EMedida.Centimetros);
            Peluche peluche2 = fabrica.CambiarDiseñoPeluche(peluche, EMateriales.Tela, 5, "example2", "osito", EColores.Azul, 22, Peluche.EMedida.Centimetros);
            Assert.IsNotNull(peluche2);
            Assert.IsTrue(fabrica.Juguetes.Count > 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(JugueteYaExisteException))]
        public void CambiarDiseñoPeluche_ThrowException()
        {
            Fabrica fabrica = new Fabrica("Test");
            Peluche peluche = new Peluche(EMateriales.Plastico, 2, "EXAMPLE", "OSO", EColores.Azul, 20, Peluche.EMedida.Centimetros);
            Peluche peluche2 = new Peluche(EMateriales.Tela, 5, "example    ", "dino", EColores.Rojo, 540, Peluche.EMedida.Milimetros);
            fabrica.Juguetes.Add(peluche);
            fabrica.Juguetes.Add(peluche2);
            Peluche peluche3 = fabrica.CambiarDiseñoPeluche(peluche2, EMateriales.Tela, 5, "example", "oso", EColores.Azul, 1, Peluche.EMedida.Metros);
        }

        [TestMethod()]
        public void CambiarDiseñoInflableTest()
        {
            Fabrica fabrica = new Fabrica("Test");
            Inflable inflable = new Inflable(EMateriales.Plastico, 2, "Example", Inflable.EDiseño.Colchoneta, EColores.Azul);
            Inflable inflable2 = fabrica.CambiarDiseñoInflable(inflable, EMateriales.Tela, 2, "Example", Inflable.EDiseño.Pelota, EColores.Verde);
            Assert.IsNotNull(inflable2);
            Assert.IsTrue(fabrica.Juguetes.Count > 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(JugueteYaExisteException))]
        public void CambiarDiseñoInflable_ThrowException()
        {
            Fabrica fabrica = new Fabrica("Test");
            Inflable inflable = new Inflable(EMateriales.Plastico, 2, "EXAMPLE    ", Inflable.EDiseño.Colchoneta, EColores.Violeta);
            Inflable inflable2 = new Inflable(EMateriales.Plastico, 20, "example", Inflable.EDiseño.Pelota, EColores.Verde);
            fabrica.Juguetes.Add(inflable);
            fabrica.Juguetes.Add(inflable2);
            Inflable inflable3 = fabrica.CambiarDiseñoInflable(inflable2, EMateriales.Tela, 4, "example", Inflable.EDiseño.Colchoneta, EColores.Rojo);
        }
    }
}