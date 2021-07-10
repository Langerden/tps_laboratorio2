using System;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Inflable : Juguete
    {
        private EDiseño diseño;
        private EColores colorPrincipal;

        /// <summary>
        /// Constructor por defecto para el Serializer
        /// </summary>
        public Inflable() : base() { }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        public Inflable(EMateriales materiales, int cantidadProduccion, string marcaProducto) : base(materiales, cantidadProduccion, marcaProducto)
        {

        }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base y de Inflable, reutilizando otros constructores.
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        /// <param name="diseño">Diseño del Inflable</param>
        /// <param name="color">Color del Inflable</param>
        public Inflable(EMateriales materiales, int cantidadProduccion, string marcaProducto, EDiseño diseño, EColores color) : this(materiales, cantidadProduccion, marcaProducto)
        {
            Diseño = diseño;
            Color = color;
        }


        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo diseño
        /// </summary>
        public EDiseño Diseño
        {
            get { return this.diseño; }
            set { this.diseño = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo colorPrincipal
        /// </summary>
        public EColores Color
        {
            get { return this.colorPrincipal; }
            set { this.colorPrincipal = value; }
        }

        /// <summary>
        /// Implementacion del metodo abstracto de la clase base. 
        /// Calcula la cantidad de Materia Prima necesaria para fabricar un Inflable,
        /// multiplicando un valor entero (que varia segun el Material) y la Cantidad a Producir.
        /// </summary>
        /// <param name="cantidad">Cantidad de Inflables que se quiere fabricar</param>
        /// <returns>Retorna el producto de la multiplicacion (numero entero)</returns>
        public override int CalcularMateriales(int cantidad)
        {
            int result = 0;
            if (cantidad > 0)
            {
                switch (Material)
                {
                    case EMateriales.Plastico:
                        result = cantidad * 15;
                        break;
                    case EMateriales.Hilo:
                        result = cantidad * 10;
                        break;
                    case EMateriales.Tela:
                        result = cantidad * 5;
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// Muestra todos los datos de un Inflable.
        /// </summary>
        /// <returns>Un string con todos los datos del objeto ya creado</returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.MostrarDatos()}");
            sb.AppendLine($"Diseño: {Diseño}");
            sb.AppendLine($"Color Principal: {Color}");
            return sb.ToString();
        }

        /// <summary>
        /// Enumerado para el Diseño de los Inflables
        /// </summary>
        public enum EDiseño
        {
            Pelota,
            Colchoneta,
            Saltarin
        }
    }
}
