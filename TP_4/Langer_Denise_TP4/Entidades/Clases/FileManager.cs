using Entidades.Interfaces;
using System;
using System.IO;

namespace Entidades.Clases
{
    public class FileManager : IArchivos<string>
    {
        private string ruta;

        /// <summary>
        /// Constructor estatico que instancia el valor de la ruta
        /// </summary>
        public FileManager()
        {
            this.ruta = $"{AppDomain.CurrentDomain.BaseDirectory}\\Archivos\\{DateTime.Today.DayOfWeek.ToString()}_Errores.txt";

        }

        /// <summary>
        /// Propiedad de Lectura y Escritura que retorna la ruta del archivo
        /// </summary>
        public string Ruta
        {
            get { return this.ruta; }
            set { this.ruta = value; }
        }

        /// <summary>
        /// Escribe y agrega datos del tipo string en un archivo de texto. En caso de no existir el archivo, lo crea.
        /// </summary>
        /// <param name="datos">Datos del tipo string que se quiere guardar en el archivo.txt</param>
        /// <returns>Retorna true si se pudo agregar los datos en el archivo o false en caso contrario. 
        /// En caso de fallas, arroja una Excepcion</returns>
        public bool Guardar(string datos)
        {
            bool agregoInfo = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(Ruta, true))
                {
                    writer.WriteLine(datos);
                    writer.WriteLine("-----------------------------------------------------------------------------------");
                    agregoInfo = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return agregoInfo;
        }

        /// <summary>
        /// Valida que exista un archivo de texto y retorna todo su contenido. 
        /// En caso de no existir el archivo arroja una Excepcion.
        /// </summary>
        /// <param name="datos">Datos del tipo string que fueron obtenidos del archivo.txt</param>
        /// <returns>Retorna true si pudo leer y retornar los datos o false en caso contrario. 
        /// En caso de fallas, arroja una Excepcion</returns>
        public bool Leer(out string datos)
        {
            bool agregoInfo = false;
            datos = string.Empty;
            if (File.Exists(Ruta))
            {
                using (StreamReader reader = new StreamReader(Ruta))
                {
                    datos = reader.ReadToEnd();
                    agregoInfo = true;
                }
            }
            else
            {
                throw new FileNotFoundException("No se encontró ningun archivo de Excepciones creado para leer");
            }
            return agregoInfo;
        }
    }
}
