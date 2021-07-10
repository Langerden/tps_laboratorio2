using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Entidades.Tests
{
    [TestClass()]
    public class MuñecoTests
    {
        Muñeco muñeco;

        [TestMethod()]
        public void CalcularMaterialesPlastico()
        {
            this.muñeco = new Muñeco(EMateriales.Plastico, 10, "Example");
            Assert.AreEqual(200, muñeco.CalcularMateriales(muñeco.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesHilo()
        {
            this.muñeco = new Muñeco(EMateriales.Hilo, 10, "Example");
            Assert.AreEqual(50, muñeco.CalcularMateriales(muñeco.CantidadProduccion));
        }

        [TestMethod()]
        public void CalcularMaterialesTela()
        {
            this.muñeco = new Muñeco(EMateriales.Tela, 10, "Example");
            Assert.AreEqual(100, muñeco.CalcularMateriales(muñeco.CantidadProduccion));
        }

        [TestMethod()]
        public void MostrarDatosTest()
        {
            this.muñeco = new Muñeco(EMateriales.Plastico, 5, "Example", "Oso", 4, true, false);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Material: {muñeco.Material}");
            sb.AppendLine($"Cantidad a producir: {muñeco.CantidadProduccion}");
            sb.AppendLine($"Marca: {muñeco.MarcaProducto}");
            sb.AppendLine($"Tipo: {muñeco.GetType().Name}");
            sb.AppendLine($"Modelo: {muñeco.Modelo}");
            sb.AppendLine($"Partes totales: {muñeco.CantidadPartes}");
            sb.AppendLine($"Lleva Ropa:SI");
            sb.AppendLine($"Es Articulado:NO");
            Assert.AreEqual(sb.ToString(), muñeco.MostrarDatos());
        }
    }
}