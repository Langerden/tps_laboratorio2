using System;

namespace Entidades.Clases
{
    public static class MetodosDeExtension
    {
        /// <summary>
        /// Metodo de extension de la clase string que hace un .ToLower y un .Trim a la instancia que llamará al metodo
        /// y al string recibido como parametro y comparan si son iguales.
        /// </summary>
        /// <param name="marcaPadre">Instancia de string que llamará al metodo</param>
        /// <param name="marcaHija">String recibido como parametro a comparar</param>
        /// <returns>Retorna true si ambos strings son iguales o false en caso contario</returns>
        public static bool CompareValuesFormat(this string marcaPadre, string marcaHija)
        {
            return marcaPadre.ToLower().Trim().Equals(marcaHija.ToLower().Trim());
        }

        /// <summary>
        /// Metodo de extension para un Enum que castea su valor a string y compara que tenga el mismo valor
        /// que el string recibido como parametro 
        /// </summary>
        /// <param name="diseño">Enumerado que llamará al metodo</param>
        /// <param name="diseñoHija">String recibido como parametro a comparar</param>
        /// <returns>Retorna true si son iguales o false en caso contario</returns>
        public static bool CompareValuesEnumFormat(this Enum diseño, Enum diseñoHija)
        {
            return diseño.ToString().ToLower().Trim().Equals(diseñoHija.ToString().ToLower().Trim());
        }
    }
}