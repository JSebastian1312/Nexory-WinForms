using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa la condición frente al IVA de un cliente o empresa.
    /// 
    /// Esta entidad es fundamental para la lógica de facturación,
    /// ya que determina el tipo de comprobante a emitir (Factura A, B, etc.)
    /// y el tratamiento impositivo correspondiente.
    /// </summary>
    public class CondicionIVA
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único de la condición de IVA.
        /// </summary>
        public int CondicionIVAID { get; set; }

        /// <summary>
        /// Descripción de la condición (ej: Responsable Inscripto, Monotributista).
        /// </summary>
        public string Descripcion { get; set; }

        #endregion

        #region === MÉTODOS SOBRESCRITOS ===

        /// <summary>
        /// Representación textual de la condición de IVA.
        /// 
        /// Se utiliza principalmente en controles de UI como ComboBox.
        /// </summary>
        public override string ToString() => Descripcion ?? string.Empty;

        #endregion

        #region === MÉTODOS DE ACCESO A DATOS ===

        /// <summary>
        /// Obtiene todas las condiciones de IVA desde la base de datos.
        /// 
        /// Este método crea internamente una instancia de conexión,
        /// facilitando su uso en contextos donde no se comparte conexión.
        /// </summary>
        /// <returns>Lista de condiciones de IVA.</returns>
        public static List<CondicionIVA> ObtenerCondicionesIVA()
        {
            var conexion = new ConexionBD();
            return ObtenerCondicionesIVA(conexion);
        }

        /// <summary>
        /// Obtiene todas las condiciones de IVA utilizando una conexión existente.
        /// 
        /// Este overload permite reutilizar la misma conexión en operaciones
        /// más complejas, evitando múltiples aperturas a la base de datos
        /// y mejorando el rendimiento.
        /// </summary>
        /// <param name="conexion">Instancia de conexión a la base de datos.</param>
        /// <returns>Lista de condiciones de IVA.</returns>
        public static List<CondicionIVA> ObtenerCondicionesIVA(ConexionBD conexion)
        {
            var lista = new List<CondicionIVA>();

            const string query = @"
                SELECT CondicionIVAID, Descripcion
                FROM CondicionIVA
                ORDER BY Descripcion";

            using (SqlConnection conn = conexion.AbrirConexion())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new CondicionIVA
                    {
                        CondicionIVAID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Descripcion = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                    });
                }
            }

            return lista;
        }

        #endregion
    }
}