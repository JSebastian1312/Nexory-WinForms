using System;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa una línea de detalle dentro de una factura.
    /// 
    /// Contiene la información del producto, la cantidad vendida y el subtotal calculado.
    /// Esta entidad forma parte de la composición de la factura y participa en el cálculo total.
    /// </summary>
    public class DetalleFactura
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único del detalle de factura.
        /// </summary>
        public int DetalleFacturaId { get; set; }

        /// <summary>
        /// Producto asociado al detalle.
        /// </summary>
        public Producto Producto { get; set; }

        /// <summary>
        /// Cantidad de unidades del producto.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Referencia a la factura a la que pertenece este detalle.
        /// </summary>
        public Factura Factura { get; set; }

        /// <summary>
        /// Subtotal calculado del detalle (Precio * Cantidad).
        /// </summary>
        public decimal Subtotal { get; private set; }

        #endregion

        #region === LÓGICA DE NEGOCIO ===

        /// <summary>
        /// Calcula el subtotal del detalle en base al precio del producto y la cantidad.
        /// 
        /// Se aplican validaciones para garantizar integridad de datos antes del cálculo.
        /// </summary>
        /// <returns>Subtotal calculado.</returns>
        /// <exception cref="InvalidOperationException">Si el producto no está definido.</exception>
        /// <exception cref="ArgumentException">Si el precio o la cantidad son inválidos.</exception>
        public decimal CalcularSubtotal()
        {
            if (Producto == null)
                throw new InvalidOperationException("No hay producto asignado al detalle.");

            if (Producto.Precio < 0)
                throw new ArgumentException("El precio del producto no puede ser negativo.");

            if (Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            Subtotal = Math.Round(Producto.Precio * Cantidad, 2);
            return Subtotal;
        }

        #endregion

        #region === PERSISTENCIA ===

        /// <summary>
        /// Guarda el detalle de factura en la base de datos.
        /// 
        /// Este método se ejecuta dentro de una transacción SQL, lo que garantiza que
        /// todos los detalles de la factura se guarden de manera atómica junto con el encabezado.
        /// </summary>
        /// <param name="conn">Conexión SQL abierta.</param>
        /// <param name="facturaId">ID de la factura asociada.</param>
        /// <param name="transaction">Transacción activa.</param>
        /// <exception cref="InvalidOperationException">Si el producto no está definido.</exception>
        /// <exception cref="ArgumentException">Si la cantidad es inválida.</exception>
        public void Guardar(SqlConnection conn, int facturaId, SqlTransaction transaction)
        {
            if (Producto == null)
                throw new InvalidOperationException("El detalle debe tener un producto.");

            if (Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            const string query = @"
                INSERT INTO DetalleFactura (FacturaID, Codigo, Descripcion, Cantidad, Subtotal)
                VALUES (@FacturaID, @Codigo, @Descripcion, @Cantidad, @Subtotal)";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@FacturaID", facturaId);
                cmd.Parameters.AddWithValue("@Codigo", Producto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                cmd.Parameters.AddWithValue("@Subtotal", CalcularSubtotal());

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region === REPRESENTACIÓN ===

        /// <summary>
        /// Devuelve una representación legible del detalle para depuración o UI.
        /// </summary>
        public override string ToString()
        {
            if (Producto == null)
                return "Detalle sin producto";

            return $"{Producto.Descripcion} x{Cantidad} = ${Subtotal}";
        }

        #endregion
    }
}