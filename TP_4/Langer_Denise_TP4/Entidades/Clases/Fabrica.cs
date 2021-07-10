using Entidades.Clases;
using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Entidades
{
    public static class Fabrica
    {
        private static string razonSocial;
        private static string tablaActual;
        private static string tablaHistorial;

        private static List<Peluche> listaPeluches;
        private static List<Inflable> listaInflables;
        private static List<Muñeco> listaMuñecos;

        public delegate void ManejoExcepciones(string text, string tittle);
        public static event ManejoExcepciones MostrarExcepciones;

        /// <summary>
        /// Constructor estatico para inicializar las listas
        /// </summary>
        static Fabrica()
        {
            listaPeluches = new List<Peluche>();
            listaInflables = new List<Inflable>();
            listaMuñecos = new List<Muñeco>();
        }

        /// <summary>
        /// Propiedad estatica de Lectura y Escritura que retorna la lista de Peluches
        /// </summary>
        public static List<Peluche> Peluches
        {
            get { return listaPeluches; }
            set { listaPeluches = value; }
        }

        /// <summary>
        /// Propiedad estatica de Lectura y Escritura que retorna la lista de Inflables
        /// </summary>
        public static List<Inflable> Inflables
        {
            get { return listaInflables; }
            set { listaInflables = value; }
        }

        /// <summary>
        /// Propiedad estatica de Lectura y Escritura que retorna la lista de Muñecos
        /// </summary>
        public static List<Muñeco> Muñecos
        {
            get { return listaMuñecos; }
            set { listaMuñecos = value; }
        }

        /// <summary>
        /// Propiedad estatica de Lectura que retorna la Razon Social de la Fabrica
        /// </summary>
        public static string RazonSocial
        {
            set { razonSocial = value; }
        }

        /// <summary>
        /// Propiedad estatica de Lectura y Escritura para obtener el nombre de las tablas de registro actual.
        /// Se le concatena el nombre de la tabla + el nombre del objeto en especifico.
        /// </summary>
        public static string TablaActual
        {
            get { return tablaActual; }
            set { tablaActual = "actuales_" + value.ToLower(); }
        }

        /// <summary>
        /// Propiedad estatica de Lectura y Escritura para obtener el nombre de las tablas de historial.
        /// Se le concatena el nombre de la tabla + el nombre del objeto en especifico.
        /// </summary>
        public static string TablaHistorial
        {
            get { return tablaHistorial; }
            set { tablaHistorial = "historial_" + value.ToLower(); }
        }

        /// <summary>
        /// Agrega un Juguete en la tabla de registros actuales de la Base de Datos, validando previamente que ya no se encuentre registrado o que ya se hizo un registro
        /// del mismo juguete en las tablas de historial (segun las primary key de cada entidad).
        /// En caso de que ya exista un registro actual o ya hubo un registro del mismo juguete en alguna de las tablas,
        /// arroja un JugueteYaExisteException o JugueteRegistradoEnLaBaseException.
        /// En caso contrario, hace un INSERT del Juguete en la tabla correspondiente.
        /// </summary>
        /// <param name="juguete">Juguete que se quiere insertar en la tabla</param>
        public static bool AgregarList(Juguete juguete)
        {
            if (ValidarRegistros(juguete))
            {
                string msg = "Ya hay un juguete registrado con la misma Marca o mismas caracteristicas";
                Fabrica.MostrarExcepciones(msg, "Juguete ya Registrado");
                throw new JugueteYaExisteException(msg);
            }

            if (ConfirmarJugueteRegistrado(juguete))
            {
                string msg = "Ya hay un Juguete registrado en la BDD con la misma marca";
                Fabrica.MostrarExcepciones(msg, "Juguete registrado en el Historial");
                throw new JugueteRegistradoEnLaBaseException(msg);
            }

            return SQLConector.InsertActual(juguete);
        }

        /// <summary>
        /// Valida que haya Materia Prima suficiente para crear un Juguete, según la cantidad que se quiere producir y el tipo de Material elegido.
        /// En caso de ser insuficiente, arroja una Excepcion.
        /// </summary>
        /// <param name="juguete">Instancia de Juguete</param>
        /// <param name="cantidad">Cantidad de elementos que se quiere fabricar</param>
        /// <returns>Retorna true si hay Materia Prima suficiente para fabricar el Juguete</returns>
        public static bool ValidarProduccion(Juguete juguete, int cantidad)
        {
            try
            {
                int cantidadNecesaria = juguete.CalcularMateriales(cantidad);
                MateriaPrima.UsarMateriales(juguete.Material, cantidadNecesaria);
                return true;
            }
            catch (NoMaterialesException exMat)
            {
                Fabrica.MostrarExcepciones(exMat.Message, "Falta de Materiales");
                throw exMat;
            }
        }

        /// <summary>
        /// Metodo que se ejecuta en un hilo secundario (haciendo un Thread.Sleep cada 500 milisegundos)
        /// para ir actualizando las 3 listas estaticas de la clase Fabrica con los registros de las tablas en Base de datos.
        /// </summary>
        public static void ActualizarListas()
        {
            while (true)
            {
                Peluches = SQLConector.LeerPeluche("actuales_peluche");
                Muñecos = SQLConector.LeerMuñeco("actuales_muñeco");
                Inflables = SQLConector.LeerInflable("actuales_inflable");
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Metodo que se utiliza para validar (segun la primary key correspondiente a cada tipo de Juguete)
        /// si el objeto ingresado como parametro ya no se encuentra registrado en su tabla de historial.
        /// </summary>
        /// <param name="juguete">Instancia de Juguete</param>
        /// <returns>True si ya existe un Juguete registrado en el historial (segun su Primary Key) o false en caso contrario</returns>
        public static bool ConfirmarJugueteRegistrado(Juguete juguete)
        {
            TablaHistorial = juguete.GetType().Name;
            bool existe = false;
            try
            {
                if (juguete is Peluche)
                {
                    List<Peluche> auxListPeluche = SQLConector.LeerPeluche(TablaHistorial);
                    existe = ValidarRegistrosPeluches((Peluche)juguete, auxListPeluche);
                }
                else if (juguete is Inflable)
                {
                    List<Inflable> auxListInfalble = SQLConector.LeerInflable(TablaHistorial);
                    existe = ValidarRegistrosInflables((Inflable)juguete, auxListInfalble);
                }
                else
                {
                    List<Muñeco> auxListMuñeco = SQLConector.LeerMuñeco(TablaHistorial);
                    existe = ValidarRegistrosMuñecos((Muñeco)juguete, auxListMuñeco);
                }
            }
            catch (Exception ex)
            {
                MostrarExcepciones.Invoke(ex.Message, "Error");
                throw ex;
            }
            return existe;
        }

        /// <summary>
        /// Modifica ciertos atributos de un Muñeco ya instanciado y hace el UPDATE en la tabla correspondiente.
        /// </summary>
        /// <param name="muñeco">Instancia de Muñeco a modificar sus atributos</param>
        /// <param name="material">Material a modificar</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a modificar</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="modelo">Modelo actual</param>
        /// <param name="cantidadPartes">Cantidad de Partes actual a modificar</param>
        /// <param name="llevaRopa">Valor booleano a actualizar en el atributo llevaRopa</param>
        /// <param name="esArticulado">Valor booleano a actualizar en el atributo esArticulado</param>
        /// <returns> El Muñeco con los campos modificados o arroja una Excepcion en caso de error</returns>
        public static Muñeco CambiarDiseñoMuñeco(Muñeco muñeco, EMateriales material, int cantidadProducir, string marca, string modelo, int cantidadPartes, bool llevaRopa, bool esArticulado)
        {
            try
            {
                muñeco.Material = material;
                muñeco.CantidadProduccion = cantidadProducir;
                muñeco.MarcaProducto = marca;
                muñeco.Modelo = modelo;
                muñeco.CantidadPartes = cantidadPartes;
                muñeco.LlevaRopa = llevaRopa;
                muñeco.EsArticulado = esArticulado;
                TablaActual = muñeco.GetType().Name;
                SQLConector.ModificarMuñeco(muñeco, TablaActual);
                return muñeco;
            }
            catch (JugueteYaExisteException exJug)
            {
                Fabrica.MostrarExcepciones(exJug.Message, "Error");
                throw exJug;
            }
        }

        /// <summary>        
        /// Modifica ciertos atributos de un Peluche ya instanciado y hace el UPDATE en la tabla correspondiente.
        /// </summary>
        /// <param name="peluche">Instancia de Peluche a modificar sus atributos</param>
        /// <param name="material">Material actual a modificar</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a modificar</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="modelo">Modelo actual</param>
        /// <param name="colorPrincipal">Color actual a modificar</param>
        /// <param name="tamañoCm">Tamaño en Centimetros a modificar</param>
        /// <param name="medida">Medida seleccionada a modificar</param>
        /// <returns> El Peluche con los campos modificados o arroja una Excepcion en caso de error</returns>
        public static Peluche CambiarDiseñoPeluche(Peluche peluche, EMateriales material, int cantidadProducir, string marca, string modelo, EColores colorPrincipal, int tamañoCm, Peluche.EMedida medida)
        {
            try
            {
                peluche.sqlObject = false;
                peluche.Material = material;
                peluche.CantidadProduccion = cantidadProducir;
                peluche.MarcaProducto = marca;
                peluche.Modelo = modelo;
                peluche.Color = colorPrincipal;
                peluche.TamañoCm = tamañoCm;
                peluche.Medida = medida;
                TablaActual = peluche.GetType().Name;
                SQLConector.ModificarPeluche(peluche, TablaActual);
                return peluche;
            }
            catch (JugueteYaExisteException exJug)
            {
                Fabrica.MostrarExcepciones(exJug.Message, "Error");
                throw exJug;
            }
        }

        /// <summary>
        /// Modifica ciertos atributos de un Inflable ya instanciado y hace el UPDATE en la tabla correspondiente.
        /// </summary>
        /// <param name="inflable">Instancia de Inflable a modificar sus atributos</param>
        /// <param name="material">Material actual a modificar</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a modificar</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="diseño">Diseño actual</param>
        /// <param name="colorPrincipal">Color actual a modificar</param>
        /// <returns> El Inflable con los campos modificados o arroja una Excepcion en caso de error</returns>
        public static Inflable CambiarDiseñoInflable(Inflable inflable, EMateriales material, int cantidadProducir, string marca, Inflable.EDiseño diseño, EColores colorPrincipal)
        {
            try
            {
                inflable.Material = material;
                inflable.CantidadProduccion = cantidadProducir;
                inflable.MarcaProducto = marca;
                inflable.Diseño = diseño;
                inflable.Color = colorPrincipal;
                TablaActual = inflable.GetType().Name;
                SQLConector.ModificarInfable(inflable, TablaActual);
                return inflable;
            }
            catch (Exception exJug)
            {
                Fabrica.MostrarExcepciones(exJug.Message, "Error");
                throw exJug;
            }
        }

        /// <summary>
        /// Metodo que valida si un Juguete ya existe en la tabla de registros actuales (segun su Primary Key).
        /// En caso de Peluche: verifica que no se repita el Modelo y la Marca.
        /// En caso de Inflable: verifica que no se repita el Diseño y la Marca.
        /// En caso de Muñeco: verifica que no se repita el Modelo y la Marca.
        /// </summary>
        /// <param name="juguete">Instancia de Juguete a validar</param>
        /// <returns>Si ya existe un Juguete, segun cada criterio, retorna true. En caso contrario retorna false</returns>
        public static bool ValidarRegistros(Juguete juguete)
        {
            bool result = false;

            if (juguete is Peluche)
            {
                result = ValidarRegistrosPeluches((Peluche)juguete, Peluches);
            }
            else if (juguete is Inflable)
            {
                result = ValidarRegistrosInflables((Inflable)juguete, Inflables);
            }
            else
            {
                result = ValidarRegistrosMuñecos((Muñeco)juguete, Muñecos);
            }
            return result;
        }


        /// <summary>
        /// Metodo que recorre la lista de Peluches actuales (recibida como parametro) y valida que ya no exista un registro de otro
        /// peluche con la misma marca y mismo modelo (utlilizando un método de extension).
        /// </summary>
        /// <param name="peluche">Instancia de Peluche</param>
        /// <param name="lista">Lista de peluches a recorrer</param>
        /// <returns>Retorna true si se repite la marca y el modelo dentro de la lista, o false en caso contrario</returns>
        public static bool ValidarRegistrosPeluches(Peluche peluche, List<Peluche> lista)
        {
            bool result = false;
            foreach (Peluche item in lista)
            {
                result = item.Modelo.CompareValuesFormat(peluche.Modelo) &&
                    item.MarcaProducto.CompareValuesFormat(peluche.MarcaProducto);
                if (result)
                    break;
            }
            return result;
        }

        /// <summary>
        /// Metodo que recorre la lista de Inflables actuales (recibida como parametro) y valida que ya no exista un registro de otro
        /// inflable con el mismo diseño y la misma marca (utlilizando un método de extension).
        /// </summary>
        /// <param name="inflable">Instancia del Inflable</param>
        /// <param name="lista">Lista de Inflables a recorrer</param>
        /// <returns>Retorna true si se repite la marca y el diseño dentro de la lista, o false en caso contrario</returns>
        public static bool ValidarRegistrosInflables(Inflable inflable, List<Inflable> lista)
        {
            bool result = false;
            foreach (Inflable item in lista)
            {
                result = item.Diseño.CompareValuesEnumFormat(inflable.Diseño) &&
                         item.MarcaProducto.CompareValuesFormat(inflable.MarcaProducto);
                if (result)
                    break;
            }
            return result;
        }

        /// <summary>
        /// Metodo que recorre la lista de Muñecos actuales (recibida como parametro) y valida que ya no exista un registro de otro
        /// muñeco con el mismo modelo y la misma marca (utlilizando un método de extension).
        /// </summary>
        /// <param name="inflable">Instancia del Muñeco</param>
        /// <param name="lista">Lista de Muñecos a recorrer</param>
        /// <returns>Retorna true si se repite la marca y el modelo dentro de la lista, o false en caso contrario</returns>
        public static bool ValidarRegistrosMuñecos(Muñeco muñeco, List<Muñeco> lista)
        {
            bool result = false;
            foreach (Muñeco item in lista)
            {
                result = item.Modelo.CompareValuesFormat(muñeco.Modelo) &&
                    item.MarcaProducto.CompareValuesFormat(muñeco.MarcaProducto);
                if (result)
                    break;
            }
            return result;
        }

        /// <summary>
        /// Metodo que valida si, al menos una de las 3 listas de la Fabrica, tienen algun elemento agregado.
        /// </summary>
        /// <returns>True si alguna de las listas tienen algun elemento agregado o false en caso contario</returns>
        public static bool HayRegistros()
        {
            return Peluches.Count > 0 || Inflables.Count > 0 || Muñecos.Count > 0;
        }
    }
}