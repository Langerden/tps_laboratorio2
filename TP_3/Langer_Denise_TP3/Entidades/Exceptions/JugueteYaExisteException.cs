using System;

namespace Entidades.Exceptions
{
    public class JugueteYaExisteException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando ya se registró un Juguete con la misma Marca y/o caracteristicas.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public JugueteYaExisteException(string message) : base(message)
        {
        }
    }
}
