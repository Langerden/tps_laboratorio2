using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private int espacioDisponible;
        private List<Vehiculo> vehiculos;

        /// <summary>
        /// Constructor privado para inicializar la lista
        /// </summary>
        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor de Taller para inicializar el valor del espacio disponible.
        /// </summary>
        /// <param name="espacioDisponible">Valor que se le asignará al espacio disponible</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestra los datos del estacionamiento y de todos los vehículos
        /// </summary>
        /// <returns>Los datos completos del estacionamiento (incluyendo cada vehiculo)</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.SUV:
                        if (v is Suv)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista, siempre y cuando haya espacio disponible.
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>La lista con el elemento agregado (en caso de ser posible). En caso contrario retorna la lista sin agregar el vehiculo</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count < taller.espacioDisponible && vehiculo != null && taller != null)
            {
                foreach (Vehiculo item in taller.vehiculos)
                {
                    if (item == vehiculo)
                        return taller;
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }

        /// <summary>
        /// Quitará un elemento de la lista, validando que lo contenga.
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>La lista con el elemento borrado (en caso de existir). En caso contrario retorna la lista sin quitar el vehiculo</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count > 0 && (!(vehiculo is null) && (!(taller is null))))
            {
                if (taller.vehiculos.Contains(vehiculo))
                    taller.vehiculos.Remove(vehiculo);
            }
            return taller;
        }
        #endregion

        /// <summary>
        /// Enumerados para los Tipos de Vehiculo
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

    }
}
