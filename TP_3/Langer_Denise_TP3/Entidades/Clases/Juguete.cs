using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Inflable))]
    [XmlInclude(typeof(Muñeco))]
    [XmlInclude(typeof(Peluche))]
    public abstract class Juguete
    {
        private EMateriales material;
        private int cantidadProduccion;
        private string marcaProducto;

        /// <summary>
        /// Constructor por defecto para el Serializer
        /// </summary>
        public Juguete() { }

        /// <summary>
        /// Constructor que instancia los atributos de la clase.
        /// </summary>
        /// <param name="materiales">Material a settear</param>
        /// <param name="cantidadProduccion">Cantidad a Producir a settear</param>
        /// <param name="marcaProducto">Marca a settear</param>
        protected Juguete(EMateriales materiales, int cantidadProduccion, string marcaProducto)
        {
            Material = materiales;
            CantidadProduccion = cantidadProduccion;
            MarcaProducto = marcaProducto;
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo material.
        /// </summary>
        public EMateriales Material
        {
            get { return this.material; }
            set
            {
                this.material = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo cantidadProduccion, validando que el valor sea mayor que 0
        /// </summary>
        public int CantidadProduccion
        {
            get { return this.cantidadProduccion; }
            set
            {
                if (value > 0)
                    this.cantidadProduccion = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo marcaProducto, validando que el string no esté vacio.
        /// </summary>
        public string MarcaProducto
        {
            get { return this.marcaProducto; }
            set
            {
                if (!(value.Equals(string.Empty)))
                    this.marcaProducto = value;
            }
        }

        /// <summary>
        /// Metodo abstracto para calcular y retornar la cantidad de Materia Prima neceseria para fabricar 
        /// un Juguete, el cual varia en cada clase derivada.
        /// </summary>
        /// <param name="cantidadMateriales">Cantidad de Juguetes que se quiere fabricar</param>
        /// <returns>Retorna un numero entero correspondiente a la cantidad de Materia Prima necesaria para fabricar un Juguete</returns>
        public abstract int CalcularMateriales(int cantidadMateriales);

        /// <summary>
        /// Muestra todos los datos de un Juguete.
        /// </summary>
        /// <returns>Un string con todos los datos del objeto ya creado</returns>
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Material: {this.Material}");
            sb.AppendLine($"Cantidad a producir: {this.CantidadProduccion}");
            sb.AppendLine($"Marca: {this.MarcaProducto}");
            sb.AppendLine($"Tipo: {this.GetType().Name}");
            return sb.ToString();
        }
    }
}
