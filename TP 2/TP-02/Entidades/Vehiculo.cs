using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        /// <summary>
        /// Constructor con parametros de Vehiculo
        /// </summary>
        /// <param name="chasis">Valor que se le asignará al atributo chasis</param>
        /// <param name="marca">Valor que se le asignará al atributo marca</param>
        /// <param name="color">Valor que se le asignará al atributo color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.color = color;
            this.marca = marca;
        }

        /// <summary>
        /// Propiedad de solo lectura del tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }


        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Devuelve todos los datos de un vehiculos</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Operador explicito para convertir un Vehiculo a un String
        /// </summary>
        /// <param name="p">Instancia de Vehiculo</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("CHASIS: {0}\r\n", p.chasis));
            sb.Append(String.Format("MARCA : {0}\r\n", p.marca.ToString()));
            sb.Append(String.Format("COLOR : {0}\r\n", p.color.ToString()));
            sb.AppendLine("---------------------");
            sb.AppendLine("");


            return sb.ToString();
        }

        /// <summary>
        /// Compara si dos vehiculos tienen el mismo chasis
        /// </summary>
        /// <param name="v1">Intancia del Vehiculo 1</param>
        /// <param name="v2">Intancia del Vehiculo 2</param>
        /// <returns>Devuelve true si tienen el mismo chasis o false en caso contrario</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (!(v1 is null) && (!(v2 is null)))
                return (v1.chasis == v2.chasis);

            return false;
        }

        /// <summary>
        /// Compara si dos vehiculos tienen chasis diferentes
        /// </summary>
        /// <param name="v1">Intancia del Vehiculo 1</param>
        /// <param name="v2">Intancia del Vehiculo 2</param>
        /// <returns>Devuelve true si tienen chasis distintos o false en caso contrario</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Enumerados para las Marcas
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        /// <summary>
        /// Enumerados para los Tamaños
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
    }
}
