using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Entidades.Clases
{
    public static class SQLConector
    {
        static SqlConnection sqlConnection;
        static SqlCommand sqlCommand;
        static FileManager fileManager;

        /// <summary>
        /// Constructor estatico que instancia los atributos de la clase y abre la coneccion con la base de datos
        /// </summary>
        static SQLConector()
        {
            sqlConnection = new SqlConnection("Data Source=localhost; Initial Catalog=TP4; Integrated Security = True");
            sqlCommand = new SqlCommand();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            fileManager = new FileManager();
            sqlConnection.Open();
        }

        /// <summary>
        /// Metodo que cierra la coneccion con la Base de Datos
        /// </summary>
        public static void CerrarConexion()
        {
            sqlConnection.Close();
        }

        /// <summary>
        /// Metodo estatico que hace un INSERT en las tablas actuales segun el tipo del Juguete        
        /// </summary>
        /// <param name="juguete">Instancia de Juguete </param>
        /// <returns>Retorna true si se pudo hacer el INSERT o false en caso contrario.</returns>
        public static bool InsertActual(Juguete juguete)
        {
            bool resultadoOperacion = false;
            try
            {
                if (juguete is Muñeco)
                    resultadoOperacion = InsertMuñeco((Muñeco)juguete, "actuales_muñeco");
                else if (juguete is Peluche)
                    resultadoOperacion = InsertarPeluche((Peluche)juguete, "actuales_peluche");
                else
                    resultadoOperacion = InsertarInflable((Inflable)juguete, "actuales_inflable");
            }
            catch (Exception exJug)
            {
                fileManager.Guardar(exJug.ToString());
            }
            return resultadoOperacion;
        }

        /// <summary>
        /// Metodo estatico que agrega el juguete en las tablas del historial (segun el tipo del Juguete)
        /// Si la primary key ya existia o se repite hace un UPDATE al registro, en caso contario hace un INSERT        
        /// </summary>
        /// <param name="juguete">Instancia del Juguete</param>
        /// <returns>Retorna true si se pudo insertar el juguete en la tabla correspondiente o false en caso contrario</returns>
        public static bool InsertarHistorial(Juguete juguete)
        {
            bool resultadoOperacion = false;
            bool yaExiste = false;
            try
            {
                yaExiste = Fabrica.ConfirmarJugueteRegistrado(juguete);
                Fabrica.TablaHistorial = juguete.GetType().Name;
                if (juguete is Muñeco)
                {
                    if (yaExiste)
                        SQLConector.ModificarMuñeco((Muñeco)juguete, Fabrica.TablaHistorial);
                    else
                        resultadoOperacion = InsertMuñeco((Muñeco)juguete, Fabrica.TablaHistorial);
                }
                else if (juguete is Peluche)
                {
                    if (yaExiste)
                        SQLConector.ModificarPeluche((Peluche)juguete, Fabrica.TablaHistorial);
                    else
                        resultadoOperacion = InsertarPeluche((Peluche)juguete, Fabrica.TablaHistorial);
                }
                else
                {
                    if (yaExiste)
                        SQLConector.ModificarInfable((Inflable)juguete, Fabrica.TablaHistorial);
                    else
                        resultadoOperacion = InsertarInflable((Inflable)juguete, Fabrica.TablaHistorial);
                }
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
            }
            return resultadoOperacion;
        }

        /// <summary>
        /// Metodo que se encarga de hacer el INSERT de un Muñeco a la tabla indicada como parametro
        /// </summary>
        /// <param name="muñeco">Instancia de Muñeco</param>
        /// <param name="nombreTable">Nombre de la tabla a la cual se le hará el INSERT</param>
        /// <returns>True si se ejecutó la query sin errores o false en caso contrario</returns>
        private static bool InsertMuñeco(Muñeco muñeco, string nombreTable)
        {
            try
            {
                string query = $"INSERT INTO {nombreTable} (Material, Produccion, Marca, Modelo, Partes, Ropa, Articulado) " +
                     $"VALUES (@material,@cantidad,@marca,@modelo,@partes,@ropa,@articulado)";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@material", muñeco.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@cantidad", muñeco.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@marca", muñeco.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@modelo", muñeco.Modelo);
                sqlCommand.Parameters.AddWithValue("@partes", muñeco.CantidadPartes);
                sqlCommand.Parameters.AddWithValue("@ropa", muñeco.LlevaRopa);
                sqlCommand.Parameters.AddWithValue("@articulado", muñeco.EsArticulado);
                return EjecutarQuery(query);
            }
            catch (Exception exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Metodo que se encarga de hacer el INSERT de un Peluche a la tabla indicada como parametro
        /// </summary>
        /// <param name="peluche">Instancia de Peluche</param>
        /// <param name="nombreTable">Nombre de la tabla a la cual se le hará el INSERT</param>
        /// <returns>True si se ejecutó la query sin errores o false en caso contrario</returns>
        private static bool InsertarPeluche(Peluche peluche, string nombreTable)
        {
            try
            {
                string query = $"INSERT INTO {nombreTable} (Material, Produccion, Marca, Modelo, Color, Tamaño, Medida) " +
                     $"VALUES (@material,@cantidad,@marca,@modelo,@color,@tamaño,@medida)";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@material", peluche.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@cantidad", peluche.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@marca", peluche.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@modelo", peluche.Modelo);
                sqlCommand.Parameters.AddWithValue("@color", peluche.Color.ToString());
                sqlCommand.Parameters.AddWithValue("@tamaño", peluche.TamañoCm);
                sqlCommand.Parameters.AddWithValue("@medida", peluche.Medida.ToString());
                return EjecutarQuery(query);
            }
            catch (Exception exJug)
            {
                throw exJug;
            }
        }


        /// <summary>
        /// Metodo que se encarga de hacer el INSERT de un Inflable a la tabla indicada como parametro
        /// </summary>
        /// <param name="inflable">Instancia de Inflable</param>
        /// <param name="nombreTable">Nombre de la tabla a la cual se le hará el INSERT</param>
        /// <returns>True si se ejecutó la query sin errores o false en caso contrario</returns>
        private static bool InsertarInflable(Inflable inflable, string nombreTable)
        {
            try
            {
                string query = $"INSERT INTO {nombreTable} (Material, Produccion, Marca, Diseño, Color) " +
                     $"VALUES (@material,@cantidad,@marca,@diseño,@color)";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@material", inflable.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@cantidad", inflable.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@marca", inflable.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@diseño", inflable.Diseño.ToString());
                sqlCommand.Parameters.AddWithValue("@color", inflable.Color.ToString());
                return EjecutarQuery(query);
            }
            catch (Exception exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Metodo que se encarga de eliminar una entidad de la tabla, segun la primary key compuesta
        /// </summary>
        /// <param name="juguete">Instancia de Juguete</param>
        /// <param name="marca">Marca (Primary Key compuesta)</param>
        /// <param name="secondKey">string que corresponde al otro valor de la Primary Key compuesta</param>
        /// <returns>True si se pudo eliminar la entidad en la tabla o false en caso contrario</returns>
        public static bool Delete(Juguete juguete, string marca, string secondKey)
        {
            string query = string.Empty;
            try
            {
                if (juguete is Muñeco)
                    query = $"DELETE FROM actuales_muñeco WHERE Marca=@marca AND Modelo=@value;";
                else if (juguete is Peluche)
                    query = $"DELETE FROM actuales_peluche WHERE Marca=@marca AND Modelo=@value;";
                else
                    query = $"DELETE FROM actuales_inflable WHERE Marca=@marca AND Diseño=@value;";

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@marca", marca);
                sqlCommand.Parameters.AddWithValue("@value", secondKey);
                return EjecutarQuery(query);

            }
            catch (Exception exJug)
            {
                throw exJug;
            }
        }

        /// <summary>
        /// Metodo estatico que trae todos los registros de la tabla indicada como parametro y retorna una lista de Peluches
        /// </summary>
        /// <param name="table">Nombre de la tabla</param>
        /// <returns>Una lista de Peluches con los registros de la tabla correspondiente</returns>
        public static List<Peluche> LeerPeluche(string table)
        {
            List<Peluche> auxList = new List<Peluche>();
            string sql = $"SELECT * FROM {table} ORDER BY Marca";

            try
            {
                sqlCommand.CommandText = sql;

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                    sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auxList.Add(new Peluche(true,
                            (EMateriales)Enum.Parse(typeof(EMateriales), reader["Material"].ToString()),
                            int.Parse(reader["Produccion"].ToString()),
                            reader["Marca"].ToString(),
                            reader["Modelo"].ToString(),
                            (EColores)Enum.Parse(typeof(EColores), reader["Color"].ToString()),
                            int.Parse(reader["Tamaño"].ToString()),
                            (Peluche.EMedida)Enum.Parse(typeof(Peluche.EMedida), reader["Medida"].ToString())));
                    }

                }
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
            }
            return auxList;
        }

        /// <summary>
        /// Metodo estatico que trae todos los registros de la tabla indicada como parametro y retorna una lista de Inflables
        /// </summary>
        /// <param name="table">Nombre de la tabla</param>
        /// <returns>Una lista de Inflables con los registros de la tabla correspondiente</returns>
        public static List<Inflable> LeerInflable(string table)
        {
            List<Inflable> auxList = new List<Inflable>();
            string sql = $"SELECT * FROM {table} ORDER BY Marca";

            try
            {
                sqlCommand.CommandText = sql;

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                    sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auxList.Add(new Inflable(
                            (EMateriales)Enum.Parse(typeof(EMateriales), reader["Material"].ToString()),
                            int.Parse(reader["Produccion"].ToString()),
                            reader["Marca"].ToString(),
                            (Inflable.EDiseño)Enum.Parse(typeof(Inflable.EDiseño), reader["Diseño"].ToString()),
                            (EColores)Enum.Parse(typeof(EColores), reader["Color"].ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
            }
            return auxList;
        }


        /// <summary>
        /// Metodo estatico que trae todos los registros de la tabla indicada como parametro y retorna una lista de Muñecos
        /// </summary>
        /// <param name="table">Nombre de la tabla</param>
        /// <returns>Una lista de Muñecos con los registros de la tabla correspondiente</returns>
        public static List<Muñeco> LeerMuñeco(string table)
        {
            List<Muñeco> auxList = new List<Muñeco>();
            string sql = $"SELECT * FROM {table} ORDER BY Marca";

            try
            {
                sqlCommand.CommandText = sql;

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                    sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        auxList.Add(new Muñeco(
                            (EMateriales)Enum.Parse(typeof(EMateriales), reader["Material"].ToString()),
                            int.Parse(reader["Produccion"].ToString()),
                            reader["Marca"].ToString(),
                            reader["Modelo"].ToString(),
                            int.Parse(reader["Partes"].ToString()),
                            bool.Parse(reader["Ropa"].ToString()),
                            bool.Parse(reader["Articulado"].ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
            }

            return auxList;
        }

        /// <summary>
        /// Metodo estatico que recibe una instancia de Peluche y hace el UPDATE de cada registro en la tabla ingresada como parametro
        /// </summary>
        /// <param name="peluche">Instancia de Peluche</param>
        /// <param name="tabla">Nombre de la tabla a realizar el UPDATE</param>
        /// <returns>True si se pudo actualizar los valores de la entidad en la tabla o false en caso contrario</returns>
        public static bool ModificarPeluche(Peluche peluche, string tabla)
        {
            try
            {
                string sql = $"UPDATE {tabla} SET Material=@material, Produccion=@produccion, Color=@color, Tamaño=@tamaño,medida=@medida WHERE Marca = @marca AND Modelo=@modelo; ";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@marca", peluche.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@material", peluche.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@produccion", peluche.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@modelo", peluche.Modelo);
                sqlCommand.Parameters.AddWithValue("@color", peluche.Color.ToString());
                sqlCommand.Parameters.AddWithValue("@tamaño", peluche.TamañoCm);
                sqlCommand.Parameters.AddWithValue("@medida", peluche.Medida.ToString());
                return EjecutarQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo estatico que recibe una instancia de Inflable y hace el UPDATE de cada registro en la tabla ingresada como parametro
        /// </summary>
        /// <param name="inflable">Instancia de Inflable</param>
        /// <param name="tabla">Nombre de la tabla a realizar el UPDATE</param>
        /// <returns>True si se pudo actualizar los valores de la entidad en la tabla o false en caso contrario</returns>
        public static bool ModificarInfable(Inflable inflable, string tabla)
        {
            try
            {
                string sql = $"UPDATE {tabla} SET Material=@material, Produccion=@produccion,Color=@color WHERE Marca = @marca AND Diseño=@diseño; ";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@marca", inflable.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@material", inflable.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@produccion", inflable.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@diseño", inflable.Diseño.ToString());
                sqlCommand.Parameters.AddWithValue("@color", inflable.Color.ToString());
                return EjecutarQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo estatico que recibe una instancia de Muñeco y hace el UPDATE de cada registro en la tabla ingresada como parametro
        /// </summary>
        /// <param name="muñeco">Instancia de Muñeco</param>
        /// <param name="tabla">Nombre de la tabla a realizar el UPDATE</param>
        /// <returns>True si se pudo actualizar los valores de la entidad en la tabla o false en caso contrario</returns>
        public static bool ModificarMuñeco(Muñeco muñeco, string tabla)
        {
            try
            {
                string sql = $"UPDATE {tabla} SET Material=@material, Produccion=@produccion,Partes=@partes, Ropa=@ropa, Articulado=@articulado WHERE Marca=@marca AND Modelo=@modelo; ";
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@marca", muñeco.MarcaProducto);
                sqlCommand.Parameters.AddWithValue("@modelo", muñeco.Modelo);
                sqlCommand.Parameters.AddWithValue("@material", muñeco.Material.ToString());
                sqlCommand.Parameters.AddWithValue("@produccion", muñeco.CantidadProduccion);
                sqlCommand.Parameters.AddWithValue("@partes", muñeco.CantidadPartes);
                sqlCommand.Parameters.AddWithValue("@ropa", muñeco.LlevaRopa);
                sqlCommand.Parameters.AddWithValue("@articulado", muñeco.EsArticulado);
                return EjecutarQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo estatico que hace un TRUNCATE a las tablas actuales
        /// </summary>
        public static void Limpiar()
        {
            EjecutarQuery("TRUNCATE TABLE actuales_muñeco;");
            EjecutarQuery("TRUNCATE TABLE actuales_inflable;");
            EjecutarQuery("TRUNCATE TABLE actuales_peluche;");
        }

        /// <summary>
        /// Metodo estatico que cuenta la cantidad de registros que tiene la tabla ingresada como parametro
        /// </summary>
        /// <param name="table">Nombre de la tabla</param>
        /// <returns>La cantidad de registros totales ( COUNT(*)) de la tabla</returns>
        public static int ContarRegistros(string table)
        {
            string sql = $"SELECT COUNT(*) FROM {table}";

            try
            {
                sqlCommand.CommandText = sql;
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo estatico que recibe una query como parametro, y la ejecuta.
        /// </summary>
        /// <param name="query">String que representa la query a ejecutar</param>
        /// <returns>True si se pudo ejecutar la query sin errores o false en caso contrario</returns>
        private static bool EjecutarQuery(string query)
        {
            bool todoOk = false;
            try
            {
                sqlCommand.CommandText = query;
                sqlCommand.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
                throw ex;
            }

            return todoOk;
        }
    }
}
