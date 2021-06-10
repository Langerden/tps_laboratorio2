using Entidades.Exceptions;
using Entidades.Interfaces;
using System.Collections.Generic;

namespace Entidades
{
    public class Fabrica : IJuguete<Juguete>
    {
        private List<Juguete> listaJuguetes;
        private string razonSocial;
        private static Fabrica singleton;

        /// <summary>
        /// Constructor privado para inicializar la lista
        /// </summary>
        private Fabrica()
        {
            this.listaJuguetes = new List<Juguete>();
        }

        /// <summary>
        /// Constructor publico que reutiliza el constructor privado
        /// </summary>
        /// <param name="razonSocial">Valor a settear como Razon social de la Fabrica</param>
        public Fabrica(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }

        /// <summary>
        /// Metodo estatico que utiliza el patron Singleton.  
        /// Verifica que ya exista una instancia de Fabrica y la retorna. En caso contrario, instancia la clase y lo retorna.
        /// </summary>
        /// <param name="razonSocial">String de la Razon social</param>
        /// <returns></returns>
        public static Fabrica GetFabrica(string razonSocial)
        {
            if (singleton is null)
                return singleton = new Fabrica(razonSocial);
            else
            {
                singleton.razonSocial = razonSocial;
                return singleton;
            }
        }

        /// <summary>
        /// Propiedad de Lectura para retornar la Lista de Juguetes
        /// </summary>
        public List<Juguete> Juguetes
        {
            get { return this.listaJuguetes; }
        }

        /// <summary>
        /// Propiedad de Lectura que retorna la Razon Social
        /// </summary>
        public string RazonSocial
        {
            get { return this.razonSocial; }
        }

        /// <summary>
        /// Agrega un Juguete a la lista, validando que no se repitan (segun criterios especificos de cada tipo de Juguete).
        /// En caso de que ya exista, arroja una Excepcion.
        /// </summary>
        /// <param name="juguete">Juguete que se quiere agregar a la lista</param>
        public void AgregarList(Juguete juguete)
        {
            if (this == juguete)
            {
                throw new JugueteYaExisteException("Ya hay un juguete registrado con la misma Marca o mismas caracteristicas");
            }
            else
            {
                this.Juguetes.Add(juguete);
            }
        }

        /// <summary>
        /// Valida que haya Materia Prima suficiente para crear un Juguete, según la cantidad que se quiere producir y el tipo de Material elegido.
        /// En caso de ser insuficiente, arroja una Excepcion.
        /// </summary>
        /// <param name="juguete">Instancia de Juguete</param>
        /// <param name="cantidad">Cantidad de elementos que se quiere fabricar</param>
        /// <returns>Retorna true si hay Materia Prima suficiente para fabricar el Juguete</returns>
        public bool ValidarProduccion(Juguete juguete, int cantidad)
        {
            try
            {
                int cantidadNecesaria = juguete.CalcularMateriales(cantidad);
                MateriaPrima.UsarMateriales(juguete.Material, cantidadNecesaria);
                return true;
            }
            catch (NoMaterialesException exMat)
            {
                throw exMat;
            }
        }

        /// <summary>
        /// Modifica ciertos atributos de un Muñeco ya instanciado y lo agrega a la lista de Juguetes.
        /// </summary>
        /// <param name="muñeco">Instancia de Muñeco a modificar sus atributos</param>
        /// <param name="material">Material actual a settear</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a settear</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="cantidadPartes">Cantidad de Partes actual a settear</param>
        /// <param name="llevaRopa">Valor booleano actual a settear en el atributo llevaRopa</param>
        /// <param name="esArticulado">Valor booleano actual a settear en el atributo esArticulado</param>
        /// <returns> El Muñeco con los campos modificados o arroja una Excepcion en caso de error</returns>
        public Muñeco CambiarDiseñoMuñeco(Muñeco muñeco, EMateriales material, int cantidadProducir, string marca, int cantidadPartes, bool llevaRopa, bool esArticulado)
        {
            try
            {
                muñeco.Material = material;
                muñeco.CantidadProduccion = cantidadProducir;
                muñeco.MarcaProducto = marca;
                muñeco.CantidadPartes = cantidadPartes;
                muñeco.LlevaRopa = llevaRopa;
                muñeco.EsArticulado = esArticulado;
                this.Juguetes.Add(muñeco);
                return muñeco;
            }
            catch (JugueteYaExisteException exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Modifica ciertos atributos de un Peluche ya instanciado y lo agrega a la lista de Juguetes.
        /// </summary>
        /// <param name="peluche">Instancia de Peluche a modificar sus atributos</param>
        /// <param name="material">Material actual a settear</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a settear</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="modelo">Modelo actual</param>
        /// <param name="colorPrincipal">Color actual a settear</param>
        /// <param name="tamañoCm">Tamaño en Centimetros actuales a settear</param>
        /// <param name="medida">Medida seleccionada actual a settear</param>
        /// <returns> El Peluche con los campos modificados o arroja una Excepcion en caso de error</returns>
        public Peluche CambiarDiseñoPeluche(Peluche peluche, EMateriales material, int cantidadProducir, string marca, string modelo, EColores colorPrincipal, int tamañoCm, Peluche.EMedida medida)
        {
            try
            {
                if (peluche.Modelo != modelo && ValidarModelo(modelo))
                {
                    throw new JugueteYaExisteException("No se puede modificar los datos porque ya existe un juguete registrado con la misma Marca o mismas caracteristicas");
                }
                else
                {
                    peluche.Material = material;
                    peluche.CantidadProduccion = cantidadProducir;
                    peluche.MarcaProducto = marca;
                    peluche.Modelo = modelo;
                    peluche.Color = colorPrincipal;
                    peluche.TamañoCm = tamañoCm;
                    peluche.Medida = medida;
                    this.Juguetes.Add(peluche);
                    return peluche;
                }
            }
            catch (JugueteYaExisteException exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Modifica ciertos atributos de un Inflable ya instanciado y lo agrega a la lista de Juguetes.
        /// </summary>
        /// <param name="inflable">Instancia de Inflable a modificar sus atributos</param>
        /// <param name="material">Material actual a settear</param>
        /// <param name="cantidadProducir">Cantidad a Producir actual a settear</param>
        /// <param name="marca">Marca actual</param>
        /// <param name="diseño">Diseño actual</param>
        /// <param name="colorPrincipal">Color actual a settear</param>
        /// <returns> El Inflable con los campos modificados o arroja una Excepcion en caso de error</returns>
        public Inflable CambiarDiseñoInflable(Inflable inflable, EMateriales material, int cantidadProducir, string marca, Inflable.EDiseño diseño, EColores colorPrincipal)
        {
            try
            {
                if (inflable.Diseño != diseño && ValidarDiseño(diseño))
                {
                    throw new JugueteYaExisteException("No se puede modificar los datos porque ya existe un juguete registrado con la misma Marca o mismas caracteristicas");
                }
                else
                {
                    inflable.Material = material;
                    inflable.CantidadProduccion = cantidadProducir;
                    inflable.MarcaProducto = marca;
                    inflable.Diseño = diseño;
                    inflable.Color = colorPrincipal;
                    this.Juguetes.Add(inflable);
                    return inflable;
                }
            }
            catch (JugueteYaExisteException exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Sobrecarga del operador == que valida si un Juguete ya existe en listaJuguetes.
        /// En caso de Peluche: verifica que no se repita el Modelo y la Marca.
        /// En caso de Inflable: verifica que no se repita el Diseño y la Marca.
        /// En caso de Muñeco: verifica que no se repita la Marca.
        /// </summary>
        /// <param name="fabrica">Instancia de Fabrica que contiene la lista</param>
        /// <param name="juguete">Instancia de Juguete a validar</param>
        /// <returns>Si ya existe un Juguete segun cada criterio, retorna true. En caso contrario retorna false</returns>
        public static bool operator ==(Fabrica fabrica, Juguete juguete)
        {
            bool result = false;
            foreach (Juguete item in fabrica.listaJuguetes)
            {
                if (item.GetType() == juguete.GetType())
                {
                    string marca = item.MarcaProducto.Trim().ToLower();
                    switch (juguete.GetType().Name)
                    {
                        case "Peluche":
                            result = ((((Peluche)juguete).Modelo).ToLower().Trim() == (((Peluche)item).Modelo).ToLower().Trim()
                                && (marca.Equals(juguete.MarcaProducto.ToLower().Trim())));
                            break;
                        case "Inflable":
                            result = (((Inflable)juguete).Diseño == ((Inflable)item).Diseño
                                && (marca.Equals(juguete.MarcaProducto.ToLower().Trim())));
                            break;
                        case "Muñeco":
                            result = (marca.Equals(juguete.MarcaProducto.ToLower().Trim()));
                            break;
                    }
                }
                if (result)
                    break;
                else
                    continue;
            }
            return result;
        }

        /// <summary>
        /// Sobrecarga del operado !=
        /// </summary>
        /// <param name="fabrica">Instancia de Fabrica que contiene la lista</param>
        /// <param name="juguete">Instancia de Juguete a validar</param>
        /// <returns>Si ya existe un Juguete (segun cada criterio), retorna false. En caso contrario retorna true</returns>
        public static bool operator !=(Fabrica fabrica, Juguete juguete)
        {
            return !(fabrica == juguete);
        }

        /// <summary>
        /// Compara si ya existe el Modelo ingresado como parametro dentro de la lista de Juguetes.
        /// </summary>
        /// <param name="modelo">Modelo a validar</param>
        /// <returns>Retorna true si ya existe un Peluche con el mismo modelo o false en caso contrario</returns>
        private bool ValidarModelo(string modelo)
        {
            foreach (Juguete item in this.Juguetes)
            {
                if (item.GetType().Name == "Peluche" && ((Peluche)item).Modelo.ToLower().Trim() == modelo.ToLower().Trim())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si existe un Inflable ya registrado con el mismo Diseño dentro de la lista de Juguetes.
        /// </summary>
        /// <param name="diseño">Diseño a validar</param>
        /// <returns>Retorna true si ya existe el Inflable con el mismo Diseño o false en caso contrario</returns>
        private bool ValidarDiseño(Inflable.EDiseño diseño)
        {
            foreach (Juguete item in this.Juguetes)
            {
                if (item.GetType().Name == "Inflable" && ((Inflable)item).Diseño == diseño)
                    return true;
            }
            return false;
        }
    }
}
