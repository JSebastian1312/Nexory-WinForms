using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Gestiona las operaciones de acceso a datos relacionadas con la entidad Producto.
    /// Incluye altas, modificaciones, eliminaciones y consultas básicas.
    /// </summary>
    public class ProductoDatos
    {
        private readonly ConexionBD conexion = new ConexionBD();

        // ======================================================
        // AGREGAR PRODUCTO
        // ======================================================
        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// El código se genera automáticamente en base al valor máximo existente.
        /// </summary>
        /// <param name="descripcion">Descripción del producto</param>
        /// <param name="precio">Precio unitario</param>
        /// <returns>True si se insertó correctamente</returns>
        public bool AgregarProducto(string descripcion, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    // ------------------------------------------------------
                    // 1. GENERACIÓN DE CÓDIGO
                    // ------------------------------------------------------
                    // ⚠️ Nota:
                    // Se utiliza MAX(Codigo) + 1 como estrategia simple.
                    // En entornos concurrentes esto podría generar colisiones.
                    // En escenarios productivos se recomienda usar IDENTITY o SEQUENCE.

                    int nuevoCodigo = 1;

                    using (SqlCommand cmdMax = new SqlCommand(
                        "SELECT MAX(Codigo) FROM Producto", conn))
                    {
                        object result = cmdMax.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                            nuevoCodigo = Convert.ToInt32(result) + 1;
                    }

                    // ------------------------------------------------------
                    // 2. INSERCIÓN DEL PRODUCTO
                    // ------------------------------------------------------
                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Producto (Codigo, Descripcion, Precio)
                          VALUES (@Codigo, @Descripcion, @Precio)", conn))
                    {
                        cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = nuevoCodigo;
                        cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = descripcion;
                        cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = precio;

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message, ex);
            }
        }

        // ======================================================
        // ACTUALIZAR PRECIO
        // ======================================================
        /// <summary>
        /// Actualiza el precio de un producto existente.
        /// </summary>
        /// <param name="productoID">ID del producto</param>
        /// <param name="nuevoPrecio">Nuevo precio</param>
        /// <returns>True si se actualizó correctamente</returns>
        public bool ActualizarPrecio(int productoID, decimal nuevoPrecio)
        {
            if (productoID <= 0)
                throw new ArgumentException("ID de producto inválido.");

            if (nuevoPrecio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Producto 
                      SET Precio = @Precio 
                      WHERE ProductoID = @ProductoID", conn))
                {
                    cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = nuevoPrecio;
                    cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = productoID;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el precio: " + ex.Message, ex);
            }
        }

        // ======================================================
        // ELIMINAR PRODUCTO
        // ======================================================
        /// <summary>
        /// Elimina físicamente un producto de la base de datos.
        /// </summary>
        /// <param name="productoID">ID del producto</param>
        /// <returns>True si se eliminó correctamente</returns>
        public bool EliminarProducto(int productoID)
        {
            if (productoID <= 0)
                throw new ArgumentException("ID de producto inválido.");

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Producto WHERE ProductoID = @ProductoID", conn))
                {
                    cmd.Parameters.Add("@ProductoID", SqlDbType.Int).Value = productoID;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message, ex);
            }
        }

        // ======================================================
        // OBTENER PRODUCTOS (COMBOBOX)
        // ======================================================
        /// <summary>
        /// Devuelve una lista de descripciones de productos.
        /// Ideal para carga en controles como ComboBox.
        /// </summary>
        public List<string> ObtenerProductos()
        {
            var productos = new List<string>();

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Descripcion FROM Producto ORDER BY Descripcion", conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        productos.Add(dr["Descripcion"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message, ex);
            }

            return productos;
        }
    }
}