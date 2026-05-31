using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Gestiona el acceso a datos de la entidad Localidad.
    /// Incluye operaciones de consulta y creación automática en caso de inexistencia.
    /// </summary>
    public class LocalidadDatos
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ============================================================
        // OBTENER TODAS LAS LOCALIDADES
        // ============================================================
        /// <summary>
        /// Recupera todas las localidades registradas en la base de datos.
        /// </summary>
        /// <returns>DataTable con ID, nombre y provincia asociada.</returns>
        public DataTable ObtenerLocalidades()
        {
            DataTable dt = new DataTable();

            const string query = @"
                SELECT 
                    LocalidadID, 
                    Nombre, 
                    ISNULL(ProvinciaID, 1) AS ProvinciaID 
                FROM Localidad";

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener localidades: " + ex.Message);
            }

            return dt;
        }

        // ============================================================
        // OBTENER O CREAR LOCALIDAD
        // ============================================================
        /// <summary>
        /// Busca una localidad por nombre.  
        /// Si no existe, la crea automáticamente con una provincia por defecto.
        /// </summary>
        /// <param name="nombre">Nombre de la localidad</param>
        /// <returns>ID de la localidad existente o creada</returns>
        public int ObtenerOAgregarLocalidad(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la localidad no puede estar vacío.");

            int localidadID = 0;

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    // ----------------------------------------------------
                    // 1. BUSCAR LOCALIDAD EXISTENTE
                    // ----------------------------------------------------
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT LocalidadID, ProvinciaID FROM Localidad WHERE Nombre = @Nombre",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                localidadID = reader.GetInt32(0);
                                int provinciaID = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);

                                // Si la localidad existe pero no tiene provincia asignada,
                                // se corrige automáticamente.
                                if (provinciaID == 0)
                                    AsignarProvinciaDefault(localidadID, 1);

                                return localidadID;
                            }
                        }
                    }

                    // ----------------------------------------------------
                    // 2. CREAR NUEVA LOCALIDAD
                    // ----------------------------------------------------
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Localidad (Nombre, ProvinciaID)
                          OUTPUT INSERTED.LocalidadID
                          VALUES (@Nombre, @ProvinciaID)",
                        conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@ProvinciaID", 1); // Provincia por defecto

                        localidadID = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener o crear la localidad: " + ex.Message);
            }

            return localidadID;
        }

        // ============================================================
        // ASIGNAR PROVINCIA POR DEFECTO
        // ============================================================
        /// <summary>
        /// Asigna una provincia a una localidad que no tenga relación definida.
        /// Este método es interno y se utiliza como mecanismo de corrección.
        /// </summary>
        private void AsignarProvinciaDefault(int localidadID, int provinciaID)
        {
            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Localidad 
                      SET ProvinciaID = @ProvinciaID 
                      WHERE LocalidadID = @LocalidadID",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@ProvinciaID", provinciaID);
                    cmd.Parameters.AddWithValue("@LocalidadID", localidadID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // ⚠️ No se lanza excepción intencionalmente:
                // Esta operación es correctiva y no debe interrumpir el flujo principal.
            }
        }
    }
}