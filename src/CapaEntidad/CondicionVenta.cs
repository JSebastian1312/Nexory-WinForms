using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa una condición comercial de venta dentro del sistema.
    /// 
    /// Define cómo se realiza la operación comercial con el cliente,
    /// por ejemplo: contado, cuenta corriente, transferencia, etc.
    /// 
    /// Esta información es utilizada durante la generación de facturas
    /// y puede influir en la lógica de pagos y gestión de cobranzas.
    /// </summary>
    public class CondicionVenta
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único de la condición de venta.
        /// </summary>
        public int CondicionVentaID { get; set; }

        /// <summary>
        /// Descripción de la condición (ej: Contado, Cuenta Corriente).
        /// </summary>
        public string Descripcion { get; set; }

        #endregion

        #region === CONSTRUCTORES ===

        /// <summary>
        /// Constructor vacío requerido para inicialización de objetos.
        /// </summary>
        public CondicionVenta() { }

        /// <summary>
        /// Constructor parametrizado para inicializar la entidad rápidamente.
        /// </summary>
        /// <param name="condicionVentaId">ID de la condición de venta.</param>
        /// <param name="descripcion">Descripción de la condición.</param>
        public CondicionVenta(int condicionVentaId, string descripcion)
        {
            CondicionVentaID = condicionVentaId;
            Descripcion = descripcion;
        }

        #endregion

        #region === MÉTODOS DE ACCESO A DATOS ===

        /// <summary>
        /// Obtiene todas las condiciones de venta registradas en la base de datos.
        /// 
        /// Este método es utilizado principalmente para poblar controles de UI
        /// como ComboBox, permitiendo al usuario seleccionar la modalidad de venta.
        /// </summary>
        /// <returns>Lista de condiciones de venta.</returns>
        public static List<CondicionVenta> ObtenerCondicionesVenta()
        {
            var lista = new List<CondicionVenta>();
            var conexion = new ConexionBD();

            const string query = @"
                SELECT CondicionVentaID, Descripcion
                FROM CondicionVenta
                ORDER BY Descripcion";

            using (SqlConnection conn = conexion.AbrirConexion())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new CondicionVenta
                    {
                        CondicionVentaID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        Descripcion = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                    });
                }
            }

            return lista;
        }

        #endregion

        #region === MÉTODOS SOBRESCRITOS ===

        /// <summary>
        /// Representación textual de la condición de venta.
        /// 
        /// Utilizado principalmente en componentes de interfaz gráfica.
        /// </summary>
        public override string ToString()
        {
            return Descripcion ?? string.Empty;
        }

        #endregion
    }
}