using System;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Peluche : Juguete
    {
        private string modelo;
        private EColores colorPrincipal;
        private int tamañoCm;
        private EMedida medida;

        /// <summary>
        /// Constructor por defecto para el Serializer
        /// </summary>
        public Peluche() : base() { }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        public Peluche(EMateriales materiales, int cantidadProduccion, string marcaProducto) : base(materiales, cantidadProduccion, marcaProducto)
        {
        }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base y de Peluche, reutilizando otros constructores.
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        /// <param name="modelo">Modelo del Peluche a settear</param>
        /// <param name="color">Color del Peluche a settear</param>
        /// <param name="tamañoCm">Tamaño en Centimetros del Peluche a settear</param>
        /// <param name="medida">Unidad de longitud del Peluche a settear</param>
        public Peluche(EMateriales materiales, int cantidadProduccion, string marcaProducto, string modelo, EColores color, int tamañoCm, EMedida medida) : this(materiales, cantidadProduccion, marcaProducto)
        {
            Modelo = modelo;
            Color = color;
            TamañoCm = tamañoCm;
            Medida = medida;
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo modelo, validando que el string no esté vacio.
        /// </summary>
        public string Modelo
        {
            get { return this.modelo; }
            set
            {
                if (!(value.Equals(string.Empty)))
                    this.modelo = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo colorPrincipal.
        /// </summary>
        public EColores Color
        {
            get { return this.colorPrincipal; }
            set { this.colorPrincipal = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo tamañoCm.
        /// Settea el valor calculado en Centimetros (segun un tamaño y la Unidad de longitud seleccionada)
        /// </summary>
        public int TamañoCm
        {
            get { return this.tamañoCm; }
            set { this.tamañoCm = CalcularCentimetros(value, this.medida); }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo medida.
        /// Devuelve por default Centimetros.
        /// </summary>
        public EMedida Medida
        {
            get { return EMedida.Centimetros; }
            set { this.medida = value; }
        }

        /// <summary>
        /// Implementacion del metodo abstracto de la clase base. 
        /// Calcula la cantidad de Materia Prima necesaria para fabricar un Peluche,
        /// multiplicando un valor entero (que varia segun el Material) y la Cantidad a Producir.
        /// </summary>
        /// <param name="cantidad">Cantidad de Peluches que se quiere fabricar</param>
        /// <returns>Retorna el producto de la multiplicacion (numero entero)</returns>
        public override int CalcularMateriales(int cantidad)
        {
            int result = 0;
            if (cantidad > 0)
            {
                switch (Material)
                {
                    case EMateriales.Plastico:
                        result = cantidad * 5;
                        break;
                    case EMateriales.Hilo:
                        result = cantidad * 8;
                        break;
                    case EMateriales.Tela:
                        result = cantidad * 15;
                        break;
                }
            }
            return result;
        }


        /// <summary>
        /// Muestra todos los datos de un Peluche.
        /// </summary>
        /// <returns>Un string con todos los datos del objeto ya creado</returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.MostrarDatos()}");
            sb.AppendLine($"Modelo: {Modelo}");
            sb.AppendLine($"Color Principal: {Color}");
            sb.AppendLine($"Tamaño en Centimetros: {TamañoCm}");
            return sb.ToString();
        }

        /// <summary>
        /// Calcula y retorna la cantidad de Centimetros en base al tamaño (numero entero) y la Unidad de longitud ingresados por parametro.
        /// </summary>
        /// <param name="tamaño">Valor entero con el tamaño a calcular</param>
        /// <param name="medida">Unidad de longitud o medida para realizar el calculo</param>
        /// <returns> Valor entero (equivalente en Centimetros) al tamaño y medida inicial </returns>
        public int CalcularCentimetros(int tamaño, EMedida medida)
        {
            int aux = 0;
            if (tamaño > 0)
            {
                switch (medida)
                {
                    case EMedida.Milimetros:
                        aux = (int)(tamaño / 10);
                        break;
                    case EMedida.Metros:
                        aux = tamaño * 100;
                        break;
                    default:
                        aux = tamaño;
                        break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Enumerados para la Medidas de los tamaños
        /// </summary>
        public enum EMedida
        {
            Metros,
            Centimetros,
            Milimetros
        }

    }
}
