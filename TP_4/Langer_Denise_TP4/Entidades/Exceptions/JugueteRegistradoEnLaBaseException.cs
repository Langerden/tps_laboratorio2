using System;

namespace Entidades.Exceptions
{
    public class JugueteRegistradoEnLaBaseException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza al momento de querer registrar un Juguete nuevo que ya fue registrado previamente en la tabla de historial (segun la Primary Key compuesta)
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public JugueteRegistradoEnLaBaseException(string message) : base(message)
        {
        }
    }
}
