using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Entidades.Tests
{
    [TestClass()]
    public class PelucheTests
    {
        Peluche peluche;

        [TestMethod()]
        public void CalcularMaterialesPlastico()
        {
            this.peluche = new Peluche(EMateriales.Plastico, 20, "Example");
            Assert.AreEqual(100, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesHilo()
        {
            this.peluche = new Peluche(EMateriales.Hilo, 10, "Example");
            Assert.AreEqual(80, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesTela()
        {
            this.peluche = new Peluche(EMateriales.Tela, 15, "Example");
            Assert.AreEqual(225, peluche.CalcularMateriales(peluche.CantidadProduccion));
        }

        [TestMethod()]
        public void MostrarDatosTest()
        {
            this.peluche = new Peluche(false, EMateriales.Tela, 7, "Example", "OSO", EColores.Verde, 1, Peluche.EMedida.Metros);
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
            this.peluche = new Peluche(false, EMateriales.Plastico, 2, "Example", "Osito", EColores.Negro, 2, Peluche.EMedida.Metros);
            long resultado = peluche.CalcularCentimetros(2, Peluche.EMedida.Metros);
            Assert.AreEqual(resultado, 200);
        }

        [TestMethod()]
        public void CalcularCentimetrosEnMilimetros()
        {
            this.peluche = new Peluche(false, EMateriales.Plastico, 2, "Example", "Osito", EColores.Negro, 1000, Peluche.EMedida.Milimetros);
            long resultado = peluche.CalcularCentimetros(1000, Peluche.EMedida.Milimetros);
            Assert.AreEqual(resultado, 100);

        }
    }
}