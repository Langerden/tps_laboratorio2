using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entidades.Clases
{
    public static class Binary
    {
        private static string ruta;

        /// <summary>
        /// Constructor estatico que instancia el valor de la ruta
        /// </summary>
        static Binary()
        {
            ruta = $"{AppDomain.CurrentDomain.BaseDirectory}Binario\\";
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura del atributo ruta
        /// </summary>
        public static string Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }


        /// <summary>
        /// Metodo estatico que guarda y/o crea un archivo binario con la cantidad de Materia Prima de la fabrica.
        /// </summary>
        /// <param name="cantidad">Cantidad de materia a serializar</param>
        /// <param name="material">Tipo de Materia Prima</param>
        /// <returns>True si se pudo guardar y/o crear el archivo o false en caso contario</returns>
        public static bool Guardar(int cantidad, EMateriales material)
        {
            bool retorno = false;
            string absolutePath = $"{Ruta}{material.ToString()}.bin";

            using (FileStream fileStream = new FileStream(absolutePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, cantidad);
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo estatico que deserializa los datos del archivo binario con la cantidad de Materia Prima de la fabrica.
        /// </summary>
        /// <param name="material">Tipo de Materia Prima (nombre del archivo que se leera)</param>
        /// <returns>La cantidad de materia prima para el material ingresado como parametro</returns>
        public static int Leer(EMateriales material)
        {
            string absolutePath = $"{Ruta}{material.ToString()}.bin";
            int retorno = 0;

            using (FileStream fileStream = new FileStream(absolutePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                retorno = (int)formatter.Deserialize(fileStream);
            }
            return retorno;
        }

        /// <summary>
        /// Metodo estatico que se ejecutará en un hilo secundario, el cual irá serializando en un archivo binario la cantidad de stock para cada material de la fábrica
        /// </summary>
        public static void SerializarMateriales()
        {
            do
            {
                try
                {
                    Binary.Guardar(MateriaPrima.CantidadHilo, EMateriales.Hilo);
                    Binary.Guardar(MateriaPrima.CantidadPlastico, EMateriales.Plastico);
                    Binary.Guardar(MateriaPrima.CantidadTela, EMateriales.Tela);
                }
                catch (Exception ex)
                {

                }
            } while (true);
        }
    }
}
