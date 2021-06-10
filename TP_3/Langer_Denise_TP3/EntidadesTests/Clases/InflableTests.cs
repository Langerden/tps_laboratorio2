using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Entidades.Tests
{
    [TestClass()]
    public class InflableTests
    {
        [TestMethod()]
        public void CalcularMaterialesPlastico()
        {
            Inflable inflable = new Inflable(EMateriales.Plastico, 20, "Example");
            Assert.AreEqual(300, inflable.CalcularMateriales(inflable.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesHilo()
        {
            Inflable inflable = new Inflable(EMateriales.Hilo, 10, "Example");
            Assert.AreEqual(100, inflable.CalcularMateriales(inflable.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesTela()
        {
            Inflable inflable = new Inflable(EMateriales.Tela, 15, "Example");
            Assert.AreEqual(75, inflable.CalcularMateriales(inflable.CantidadProduccion));
        }

        [TestMethod()]
        public void MostrarDatosTest()
        {
            Inflable inflable = new Inflable(EMateriales.Tela, 7, "Example", Inflable.EDiseño.Colchoneta, EColores.Negro);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Material: {inflable.Material}");
            sb.AppendLine($"Cantidad a producir: {inflable.CantidadProduccion}");
            sb.AppendLine($"Marca: {inflable.MarcaProducto}");
            sb.AppendLine($"Tipo: {inflable.GetType().Name}");
            sb.AppendLine($"Diseño: {inflable.Diseño}");
            sb.AppendLine($"Color Principal: {inflable.Color}");
            Assert.AreEqual(sb.ToString(), inflable.MostrarDatos());
        }
    }
}