namespace Entidades
{
    public static class MateriaPrima
    {
        private static int cantidadPlastico;
        private static int cantidadTela;
        private static int cantidadHilo;

        /// <summary>
        /// Constructor estatico que inicializa los atributos por default.
        /// </summary>
        static MateriaPrima()
        {
            CantidadPlastico = 500;
            CantidadTela = 500;
            CantidadHilo = 500;
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo cantidadPlastico.
        /// Settea el valor si es mayor o igual que 0. En caso contrario arroja una Excepcion.
        /// </summary>
        public static int CantidadPlastico
        {
            get { return cantidadPlastico; }
            set
            {
                if (value >= 0)
                    cantidadPlastico = value;
                else
                    throw new NoMaterialesException("No hay cantidad suficiente de Plastico para fabricar el Juguete");
                ;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo cantidadTela.
        /// Settea el valor si es mayor o igual que 0. En caso contrario arroja una Excepcion.
        /// </summary>
        public static int CantidadTela
        {
            get { return cantidadTela; }
            set
            {
                if (value >= 0)
                    cantidadTela = value;
                else
                    throw new NoMaterialesException("No hay cantidad suficiente de Tela para fabricar el Juguete");
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el atributo cantidadHilo.
        /// Settea el valor si es mayor o igual que 0. En caso contrario arroja una Excepcion.
        /// </summary>
        public static int CantidadHilo
        {
            get { return cantidadHilo; }
            set
            {
                if (value >= 0)
                    cantidadHilo = value;
                else
                    throw new NoMaterialesException("No hay cantidad suficiente de Hilo para fabricar el Juguete");
            }
        }

        /// <summary>
        /// Agrega cantidad de materiales (numero entero) a la Materia Prima que se indica como parametro.
        /// En caso de error, arroja una Excepcion.
        /// </summary>
        /// <param name="material">Tipo de Material que se desea agregar unidades</param>
        /// <param name="cantidadAgregar">Cantidad de unidades que se quiere agregar a la cantidad actual</param>
        public static void ComprarMateriales(EMateriales material, int cantidadAgregar)
        {
            try
            {
                switch (material)
                {
                    case EMateriales.Plastico:
                        CantidadPlastico += cantidadAgregar;
                        break;
                    case EMateriales.Hilo:
                        CantidadHilo += cantidadAgregar;
                        break;
                    case EMateriales.Tela:
                        CantidadTela += cantidadAgregar;
                        break;
                }
            }
            catch (NoMaterialesException exMat)
            {
                throw exMat;
            }
        }

        /// <summary>
        /// Resta una cantidad de materiales (numero entero) a la Materia Prima que se indica como parametro.
        /// En caso de error, arroja una Excepcion.
        /// </summary>
        /// <param name="material">Tipo de Material a restar unidades</param>
        /// <param name="cantidadAgregar">Cantidad de unidades a utilizar que se restan a la cantidad disponible</param>
        public static void UsarMateriales(EMateriales material, int cantidadUsada)
        {
            try
            {
                switch (material)
                {
                    case EMateriales.Plastico:
                        CantidadPlastico -= cantidadUsada;
                        break;
                    case EMateriales.Hilo:
                        CantidadHilo -= cantidadUsada;
                        break;
                    case EMateriales.Tela:
                        CantidadTela -= cantidadUsada;
                        break;
                }
            }
            catch (NoMaterialesException exMat)
            {
                throw exMat;
            }
        }
    }
}
