using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Entidades.Tests
{
    [TestClass()]
    public class PelucheTests
    {

        [TestMethod()]
        public void CalcularMaterialesPlastico()
        {
            Peluche peluche = new Peluche(EMateriales.Plastico, 20, "Example");
            Assert.AreEqual(100, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesHilo()
        {
            Peluche peluche = new Peluche(EMateriales.Hilo, 10, "Example");
            Assert.AreEqual(80, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesTela()
        {
            Peluche peluche = new Peluche(EMateriales.Tela, 15, "Example");
            Assert.AreEqual(225, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void MostrarDatosTest()
        {
            Peluche peluche = new Peluche(EMateriales.Tela, 7, "Example", "OSO", EColores.Verde, 1, Peluche.EMedida.Metros);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Material: {peluche.Material}");
            sb.AppendLine($"Cantidad a producir: {peluche.CantidadProduccion}");
            sb.AppendLine($"Marca: {peluche.MarcaProducto}");
            sb.AppendLine($"Tipo: {peluche.GetType().Name}");
            sb.AppendLine($"Modelo: {peluche.Modelo}");
            sb.AppendLine($"Color Principal: {peluche.Color}");
            sb.AppendLine($"Tamaño en Centimetros: {peluche.TamañoCm}");
            Assert.AreEqual(sb.ToString(), peluche.MostrarDatos());
        }

        [TestMethod()]
        public void CalcularCentimetrosEnMetros()
        {
            Peluche peluche = new Peluche(EMateriales.Plastico, 2, "Example", "Osito", EColores.Negro, 2, Peluche.EMedida.Metros);
            int resultado = peluche.CalcularCentimetros(2, Peluche.EMedida.Metros);
            Assert.IsTrue(resultado == 200);
        }

        [TestMethod()]
        public void CalcularCentimetrosEnMilimetros()
        {
            Peluche peluche = new Peluche(EMateriales.Plastico, 2, "Example", "Osito", EColores.Negro, 1000, Peluche.EMedida.Milimetros);
            int resultado = peluche.CalcularCentimetros(1000, Peluche.EMedida.Milimetros);
            Assert.IsTrue(resultado == 100);
        }
    }
}