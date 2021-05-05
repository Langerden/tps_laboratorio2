using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Constructor con parametros de Suv
        /// </summary>
        /// <param name="marca">Valor que se le asignará al atributo marca</param>
        /// <param name="chasis">Valor que se le asignará al atributo chasis</param>
        /// <param name="color">Valor que se le asignará al atributo color</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Propiedad de lectura que retorna el tamaño de un SUV como "Grande"
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Imprime los datos de un Suv
        /// </summary>
        /// <returns> Devuelve todos los datos de un Suv </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.Append($"{base.Mostrar()}");
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
