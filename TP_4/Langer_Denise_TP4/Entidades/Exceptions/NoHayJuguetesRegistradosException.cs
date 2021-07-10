using System;

namespace Entidades.Exceptions
{
    public class NoHayJuguetesRegistradosException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando se quiere fabricar juguetes sin haberlos registrado previamente
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public NoHayJuguetesRegistradosException(string message) : base(message)
        {
        }
    }
}
