using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Clases
{
    public class Serializer<T> : ISerializador<T> where T : Juguete
    {

        private string ruta;

        public Serializer()
        {
            this.ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\Serializado\\";
        }

        /// <summary>
        /// Propuedad de Lectura y Escritura que retorna la ruta del archivo
        /// </summary>
        public string Ruta
        {
            get { return this.ruta; }
            set { this.ruta = value; }
        }

        /// <summary>
        /// Serializa los datos que se ingresa como parametro en un archivo del tipo xml. En caso de no existir el archivo, lo crea.
        /// </summary>
        /// <typeparam name="U">Variable generica para indicar el tipo de objecto</typeparam>
        /// <param name="datos">Datos que se quieren serializar en el archivo</param>
        /// <returns> Retorna true si se pudo serializar los datos en un archivo o false en caso contrario</returns>        
        public bool Guardar<T>(List<T> datos)
        {
            string absolutePath = $"{Ruta}{typeof(T).Name}.xml";
            bool retorno = false;
            using (XmlTextWriter auxWriter = new XmlTextWriter(absolutePath, Encoding.UTF8))
            {
                XmlSerializer nuevoXml = new XmlSerializer(typeof(List<T>));
                nuevoXml.Serialize(auxWriter, datos);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa los datos de un archivo.xml a una lista, validando que exista.
        /// </summary>
        /// <typeparam name="U">Variable generica para indicar el tipo de objecto que contiene la lista a deserializar</typeparam>
        /// <returns>Una lista con los datos del archivo.xml (segun el tipo de objeto declarado).
        /// En caso de no existir el archivo, retorna una lista vacia</returns>
        public List<T> Leer<T>()
        {
            string absolutePath = $"{Ruta}{typeof(T).Name}.xml";
            List<T> auxList = new List<T>();
            if (File.Exists(absolutePath))
            {
                using (XmlTextReader auxReader = new XmlTextReader(absolutePath))
                {
                    XmlSerializer nuevoXml = new XmlSerializer(typeof(List<T>));
                    auxList = (List<T>)nuevoXml.Deserialize(auxReader);
                }
            }
            return auxList;
        }
    }
}
