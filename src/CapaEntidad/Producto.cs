using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa un producto comercializable dentro del sistema.
    /// 
    /// Contiene la información básica necesaria para su venta,
    /// incluyendo código identificador, descripción y precio unitario.
    /// 
    /// Es utilizado principalmente en la generación de facturas
    /// y en la carga de detalles de venta.
    /// </summary>
    public class Producto
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int ProductoID { get; set; }

        /// <summary>
        /// Código interno del producto.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descripción o nombre del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal Precio { get; set; }

        #endregion

        #region === DEPENDENCIAS ===

        /// <summary>
        /// Acceso a la base de datos.
        /// </summary>
        private readonly ConexionBD conexion = new ConexionBD();

        #endregion

        #region === MÉTODOS DE ACCESO A DATOS ===

        /// <summary>
        /// Obtiene todos los productos registrados en la base de datos.
        /// 
        /// Este método es utilizado principalmente para poblar controles de UI
        /// como ComboBox o listados de productos disponibles para la venta.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        /// <exception cref="Exception">Error en la consulta a la base de datos.</exception>
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            const string query = @"
                SELECT 
                    ProductoID,
                    ISNULL(Codigo,''),
                    ISNULL(Descripcion,''),
                    ISNULL(Precio,0)
                FROM Producto
                ORDER BY Descripcion";

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            ProductoID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Codigo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Precio = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }

            return productos;
        }

        #endregion

        #region === REPRESENTACIÓN ===

        /// <summary>
        /// Representación textual del producto.
        /// 
        /// Se utiliza principalmente en controles visuales como ComboBox.
        /// </summary>
        public override string ToString()
        {
            return Descripcion ?? string.Empty;
        }

        #endregion
    }
}