using System;
using System.Runtime.Serialization;

namespace Formularios
{
    [Serializable]
    internal class CantidadMaxMaterialesException : Exception
    {
        public CantidadMaxMaterialesException()
        {
        }

        public CantidadMaxMaterialesException(string message) : base(message)
        {
        }

        public CantidadMaxMaterialesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantidadMaxMaterialesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}