using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {

        /// <summary>
        /// Constructor con parametros de Ciclomotor.
        /// </summary>
        /// <param name="marca">Valor que se le asignará al atributo marca</param>
        /// <param name="chasis">Valor que se le asignará al atributo chasis</param>
        /// <param name="color">Valor que se le asignará al atributo color</param>
        public Ciclomotor(EMarca marca,string chasis,  ConsoleColor color) : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Propiedad de lectura que retorna el tamaño de un Ciclomotor como "Chico"
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Imprime los datos de un Ciclomotor
        /// </summary>
        /// <returns> Devuelve todos los datos de un Ciclomotor </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.Append($"{base.Mostrar()}");
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
