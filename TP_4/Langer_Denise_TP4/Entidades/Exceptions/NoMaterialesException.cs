using System;

namespace Entidades
{
    public class NoMaterialesException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando no hay suficientes materiales para fabricar un Juguete
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public NoMaterialesException(string message) : base(message)
        {
        }
    }
}
