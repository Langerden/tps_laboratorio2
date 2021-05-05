using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        private ETipo tipo;

        /// <summary>
        /// Constructor (sobrecargado) con parametros de Sedan, inicializando por defecto el tipo con CuatroPuertas
        /// </summary>
        /// <param name="marca">Valor que se le asignará al atributo marca</param>
        /// <param name="chasis">Valor que se le asignará al atributo chasis</param>
        /// <param name="color">Valor que se le asignará al atributo color</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Constructor con parametros de Sedan, inicializando el tipo segun el valor del parametro. 
        /// </summary>
        /// <param name="marca">Valor que se le asignará al atributo marca</param>
        /// <param name="chasis">Valor que se le asignará al atributo chasis</param>
        /// <param name="color">Valor que se le asignará al atributo color</param>
        /// <param name="tipo">Valor que se le asignará al atributo tipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base (chasis, marca , color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        ///  Propiedad de lectura que retorna el tamaño de un Sedan como 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Imprime los datos de un Sedan
        /// </summary>
        /// <returns> Devuelve todos los datos de un Sedan </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.Append($"{base.Mostrar()}");
            sb.Append(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine(String.Format("TIPO : {0}", this.tipo));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Enumerados para los Tipos
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
    }
}
