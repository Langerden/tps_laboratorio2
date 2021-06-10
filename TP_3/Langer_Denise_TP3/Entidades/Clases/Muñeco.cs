using System;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Muñeco : Juguete
    {
        private int cantidadPartes;
        private bool llevaRopa;
        private bool esArticulado;

        /// <summary>
        /// Constructor por defecto para el Serializer
        /// </summary>
        public Muñeco() : base() { }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        public Muñeco(EMateriales materiales, int cantidadProduccion, string marcaProducto) : base(materiales, cantidadProduccion, marcaProducto)
        {
        }

        /// <summary>
        /// Constructor que instancia un objeto con los atributos de la clase base y de Muñeco, reutilizando otros constructores.
        /// </summary>
        /// <param name="materiales">Material del Juguete</param>
        /// <param name="cantidadProduccion">Cantidad a Producir del Juguete</param>
        /// <param name="marcaProducto">Marca del Juguete</param>
        /// <param name="cantidadPartes">Cantidad de Partes del Muñeco</param>
        /// <param name="llevaRopa">Valor booleano que indica si el Muñeco lleva ropa o no</param>
        /// <param name="esArticulado">Valor booleano que indica si el Muñeco es articulado o no</param>
        public Muñeco(EMateriales materiales, int cantidadProduccion, string marcaProducto, int cantidadPartes, bool llevaRopa, bool esArticulado) : this(materiales, cantidadProduccion, marcaProducto)
        {
            CantidadPartes = cantidadPartes;
            LlevaRopa = llevaRopa;
            EsArticulado = esArticulado;
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo cantidadPartes, validando que el valor sea mayor que 0.
        /// </summary>
        public int CantidadPartes
        {
            get { return this.cantidadPartes; }
            set
            {
                if (value > 0)
                    this.cantidadPartes = value;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo llevaRopa.
        /// </summary>
        public bool LlevaRopa
        {
            get { return this.llevaRopa; }
            set { this.llevaRopa = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo esArticulado.
        /// </summary>
        public bool EsArticulado
        {
            get { return this.esArticulado; }
            set { this.esArticulado = value; }
        }

        /// <summary>
        /// Implementacion del metodo abstracto de la clase base. 
        /// Calcula la cantidad de Materia Prima necesaria para fabricar un Muñeco,
        /// multiplicando un valor entero (que varia segun el Material) y la Cantidad a Producir.
        /// </summary>
        /// <param name="cantidad">Cantidad de Muñecos que se quiere fabricar</param>
        /// <returns>Retorna el producto de la multiplicacion (numero entero)</returns>
        public override int CalcularMateriales(int cantidad)
        {
            int result = 0;
            if (cantidad > 0)
            {
                switch (Material)
                {
                    case EMateriales.Plastico:
                        result = cantidad * 20;
                        break;
                    case EMateriales.Hilo:
                        result = cantidad * 5;
                        break;
                    case EMateriales.Tela:
                        result = cantidad * 10;
                        break;
                }
            }
            return result;
        }


        /// <summary>
        /// Muestra todos los datos de un Muñeco.
        /// </summary>
        /// <returns>Un string con todos los datos del objeto ya creado</returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{base.MostrarDatos()}");
            sb.AppendLine($"Partes totales: {CantidadPartes}");
            sb.Append($"Lleva Ropa:");
            if (LlevaRopa)
                sb.AppendLine($"SI");
            else
                sb.AppendLine($"NO");
            sb.Append($"Es Articulado:");
            if (EsArticulado)
                sb.AppendLine("SI");
            else
                sb.AppendLine($"NO");

            return sb.ToString();
        }
    }
}
