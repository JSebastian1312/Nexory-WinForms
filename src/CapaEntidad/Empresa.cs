using System;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa la empresa emisora de facturas dentro del sistema.
    /// 
    /// Esta entidad contiene los datos fiscales y comerciales necesarios
    /// para la generación de comprobantes, incluyendo CUIT, domicilio y
    /// condición frente al IVA.
    /// 
    /// Es utilizada como origen de la facturación en cada operación.
    /// </summary>
    public class Empresa
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único de la empresa.
        /// </summary>
        public int EmpresaID { get; set; }

        /// <summary>
        /// Nombre o razón social de la empresa.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// CUIT de la empresa (identificación fiscal obligatoria).
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Domicilio fiscal de la empresa.
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Identificador de la localidad donde se encuentra la empresa.
        /// </summary>
        public int LocalidadID { get; set; }

        /// <summary>
        /// Identificador de la condición frente al IVA.
        /// </summary>
        public int CondicionIVAID { get; set; }

        #endregion

        #region === DEPENDENCIAS ===

        /// <summary>
        /// Instancia compartida de conexión a base de datos.
        /// 
        /// Se utiliza en métodos estáticos para evitar múltiples instanciaciones innecesarias.
        /// </summary>
        private static readonly ConexionBD conexion = new ConexionBD();

        #endregion

        #region === MÉTODOS DE ACCESO A DATOS ===

        /// <summary>
        /// Busca una empresa por su identificador.
        /// 
        /// Este método es utilizado principalmente al momento de generar una factura,
        /// ya que se requiere conocer los datos del emisor.
        /// </summary>
        /// <param name="empresaID">ID de la empresa.</param>
        /// <returns>Instancia de Empresa o null si no existe.</returns>
        /// <exception cref="Exception">Error en el acceso a la base de datos.</exception>
        public static Empresa BuscarPorID(int empresaID)
        {
            Empresa empresa = null;

            const string query = @"
                SELECT EmpresaID, Nombre, CUIT, Domicilio, LocalidadID, CondicionIVAID
                FROM Empresa
                WHERE EmpresaID = @EmpresaID";

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpresaID", empresaID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empresa = new Empresa
                            {
                                EmpresaID = reader.GetInt32(0),
                                Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                CUIT = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Domicilio = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                LocalidadID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                CondicionIVAID = reader.IsDBNull(5) ? 0 : reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Se encapsula la excepción para mantener control sobre los mensajes del sistema
                throw new Exception("Error al buscar la empresa: " + ex.Message);
            }

            return empresa;
        }

        #endregion

        #region === REPRESENTACIÓN ===

        /// <summary>
        /// Representación textual de la empresa.
        /// Utilizada principalmente en interfaces gráficas.
        /// </summary>
        public override string ToString() => Nombre ?? string.Empty;

        #endregion
    }
}