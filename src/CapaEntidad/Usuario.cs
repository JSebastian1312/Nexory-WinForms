using System;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaEntidad
{
    /// <summary>
    /// Representa un usuario del sistema.
    /// 
    /// Esta entidad se utiliza para la autenticación y control de acceso,
    /// permitiendo validar credenciales contra la base de datos.
    /// 
    /// ⚠️ Nota: En un entorno productivo, las contraseñas deberían almacenarse
    /// utilizando hashing seguro (ej: SHA-256, BCrypt, etc.) y no en texto plano.
    /// </summary>
    public class Usuario
    {
        #region === CONFIGURACIÓN ===

        /// <summary>
        /// Cadena de conexión obtenida desde el archivo de configuración.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int UsuarioID { get; set; }

        /// <summary>
        /// Nombre de usuario utilizado para autenticación.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Clave del usuario (en este sistema se maneja en texto plano).
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Email del usuario.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Rol del usuario dentro del sistema (Administrador, Usuario, etc.).
        /// </summary>
        public string Rol { get; set; }

        #endregion

        #region === CONSTRUCTOR ===

        /// <summary>
        /// Inicializa el usuario obteniendo la cadena de conexión desde app.config.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si la cadena de conexión no está configurada correctamente.
        /// </exception>
        public Usuario()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["DB_Facturacion"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new InvalidOperationException(
                    "No se encontró la cadena de conexión 'DB_Facturacion' en app.config.");
        }

        #endregion

        #region === AUTENTICACIÓN ===

        /// <summary>
        /// Verifica si existe un usuario con las credenciales proporcionadas.
        /// 
        /// Este método realiza una consulta segura utilizando parámetros
        /// para evitar ataques de SQL Injection.
        /// </summary>
        /// <param name="nombre">Nombre de usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <returns>True si las credenciales son válidas, false en caso contrario.</returns>
        /// <exception cref="ArgumentException">Si los parámetros están vacíos.</exception>
        /// <exception cref="Exception">Si ocurre un error durante la operación.</exception>
        public bool VerificarUsuario(string nombre, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("El nombre y la clave no pueden estar vacíos.");

            const string query = @"
                SELECT COUNT(1) 
                FROM Usuario 
                WHERE Nombre = @Nombre AND Clave = @Clave";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Uso de parámetros para prevenir SQL Injection
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Clave", clave);

                    conn.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count == 1;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(
                    "Error al verificar el usuario en la base de datos: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error inesperado al verificar el usuario: " + ex.Message, ex);
            }
        }

        #endregion
    }
}