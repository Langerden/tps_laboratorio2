using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Entidades.Clases.Tests
{
    [TestClass()]
    public class FileManagerTests
    {
        FileManager fileManager;

        public FileManagerTests()
        {
            this.fileManager = new FileManager();
            fileManager.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\{DateTime.Today.DayOfWeek.ToString()}_Errores.txt";
        }

        [TestMethod()]
        public void GuardarTest()
        {
            Assert.IsTrue(this.fileManager.Guardar("Prueba Unitaria"));
        }

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void WhenGuardar_ThrowException()
        {
            this.fileManager.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\Carpeta\\{DateTime.Today.DayOfWeek.ToString()}Error.txt";
            fileManager.Guardar("Prueba Unitaria: RUTA INCORRECTA");
        }

        [TestMethod()]
        public void LeerTest()
        {
            string datos = string.Empty;

            Assert.IsTrue(fileManager.Leer(out datos));
            Assert.IsNotNull(datos);
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]

        public void WhenLeer_ThrowException()
        {
            this.fileManager = new FileManager();
            this.fileManager.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\{DateTime.Today.DayOfWeek.ToString()}Error.txt";

            string datos = string.Empty;

            Assert.IsFalse(fileManager.Leer(out datos));
            Assert.IsNull(datos);
        }
    }
}