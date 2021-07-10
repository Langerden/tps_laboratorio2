using Entidades.Clases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Entidades.Tests
{
    [TestClass()]
    public class FabricaTests
    {
        [TestMethod()]
        public void ValidarProduccionTest()
        {
            Muñeco muñeco = new Muñeco(EMateriales.Plastico, 5, "Marca");

            Assert.IsTrue(Fabrica.ValidarProduccion(muñeco, 2));
        }

        [TestMethod()]
        public void ConfirmarJugueteRegistrado()
        {
            Random random = new Random();

            Inflable inflable = new Inflable(EMateriales.Plastico, 5, ("Marca" + (random.Next().ToString())), Inflable.EDiseño.Saltarin, EColores.Negro);

            bool result = Fabrica.ConfirmarJugueteRegistrado(inflable);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void WhenConfirmarJugueteRegistrado_IsTrue()
        {
            Inflable inflable = new Inflable(EMateriales.Plastico, 5, "Marca", Inflable.EDiseño.Saltarin, EColores.Negro);
            Inflable inflableRepetido = new Inflable(EMateriales.Tela, 3, "marca ", Inflable.EDiseño.Saltarin, EColores.Blanco);

            SQLConector.InsertarHistorial(inflable);

            bool result = Fabrica.ConfirmarJugueteRegistrado(inflableRepetido);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CambiarDiseñoPelucheTest()
        {
            Peluche peluche = new Peluche(false, EMateriales.Tela, 10, "Peluche", "Modelo", EColores.Violeta, 20, Peluche.EMedida.Centimetros);
            int cantidadActual = peluche.CantidadProduccion;

            peluche = Fabrica.CambiarDiseñoPeluche(peluche, EMateriales.Hilo, 11, "Peluche", "Modelo", EColores.Rosa, 30, Peluche.EMedida.Centimetros);
            int cantidadNueva = peluche.CantidadProduccion;

            Assert.AreNotEqual(cantidadActual, cantidadNueva);
        }

        [TestMethod()]
        public void HayRegistrosTest()
        {
            Fabrica.Peluches.Add(new Peluche());
            Assert.AreNotEqual(0, Fabrica.Peluches.Count);
        }
    }
}