using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Entidades.Clases.Tests
{
    [TestClass()]
    public class SerializerTests
    {

        [TestMethod()]
        public void GuardarTest_ListOfPeluches()
        {
            Serializer<Peluche> serializerPeluche = new Serializer<Peluche>();
            List<Peluche> auxList = new List<Peluche>() { new Peluche(EMateriales.Plastico, 4, "Peluche1"),
                new Peluche(EMateriales.Tela, 2, "Peluche2"),
                new Peluche(EMateriales.Hilo, 3, "Peluche3") };

            serializerPeluche.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            Assert.IsTrue(serializerPeluche.Guardar(auxList));
        }

        [TestMethod()]
        public void GuardarTest_ListOfMuñecos()
        {
            Serializer<Muñeco> serializerMuñeco = new Serializer<Muñeco>();
            List<Muñeco> auxList = new List<Muñeco>(){ new Muñeco(EMateriales.Plastico, 4, "Muñeco1"),
                new Muñeco(EMateriales.Tela, 2, "Muñeco2"),
                new Muñeco(EMateriales.Hilo, 3, "Muñeco3") };

            serializerMuñeco.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            Assert.IsTrue(serializerMuñeco.Guardar(auxList));
        }

        [TestMethod()]
        public void GuardarTest_ListOfInflables()
        {
            Serializer<Inflable> serializerInflable = new Serializer<Inflable>();
            List<Inflable> auxList = new List<Inflable>(){ new Inflable(EMateriales.Plastico, 4, "Inflable1"),
                new Inflable(EMateriales.Tela, 2, "Inflable2"),
                new Inflable(EMateriales.Hilo, 3, "Inflable3") };

            serializerInflable.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            Assert.IsTrue(serializerInflable.Guardar(auxList));
        }

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void WhenGuardarTest_ThrowException()
        {
            Serializer<Inflable> serializerInflable = new Serializer<Inflable>();
            List<Inflable> auxList = new List<Inflable>(){ new Inflable(EMateriales.Plastico, 4, "Inflable1"),
                new Inflable(EMateriales.Tela, 2, "Inflable2"),
                new Inflable(EMateriales.Hilo, 3, "Inflable3") };

            Assert.IsFalse(serializerInflable.Guardar(auxList));
        }

        [TestMethod()]
        public void LeerTest_ListOfPeluches()
        {
            Serializer<Peluche> serializerPeluche = new Serializer<Peluche>();
            List<Peluche> auxList = new List<Peluche>();

            serializerPeluche.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            auxList = serializerPeluche.Leer<Peluche>();

            Assert.IsTrue(auxList.Count > 0);
        }

        [TestMethod()]
        public void LeerTest_ListOfMuñeco()
        {
            Serializer<Muñeco> serializerMuñeco = new Serializer<Muñeco>();
            List<Muñeco> auxList = new List<Muñeco>();

            serializerMuñeco.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            auxList = serializerMuñeco.Leer<Muñeco>();

            Assert.IsTrue(auxList.Count > 0);
        }

        [TestMethod()]
        public void LeerTest_ListOfInflable()
        {
            Serializer<Inflable> serializerInflable = new Serializer<Inflable>();
            List<Inflable> auxList = new List<Inflable>();

            serializerInflable.Ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\";

            auxList = serializerInflable.Leer<Inflable>();

            Assert.IsTrue(auxList.Count > 0);
        }

        [TestMethod()]
        public void WhenLeer_ThrowException()
        {
            Serializer<Inflable> serializerInflable = new Serializer<Inflable>();
            List<Inflable> auxList = new List<Inflable>();

            auxList = serializerInflable.Leer<Inflable>();

            Assert.IsTrue(auxList.Count == 0);
        }
    }
}