using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario de selección de reportes del sistema.
    /// Permite al usuario acceder a los distintos reportes disponibles:
    /// - Reporte de Clientes
    /// - Reporte de Productos
    /// </summary>
    public partial class SeleccionReportes : Form
    {
        // ================================
        //      CONSTRUCTOR
        // ================================
        public SeleccionReportes()
        {
            InitializeComponent();
        }

        // ================================
        //      EVENTO LOAD
        // ================================
        private void SeleccionReportes_Load(object sender, EventArgs e)
        {
            // Espacio reservado para inicializaciones futuras
            // Ej: cargar filtros, permisos por usuario, etc.
        }

        // ================================
        //      REPORTES
        // ================================

        /// <summary>
        /// Abre el reporte de clientes en modo modal.
        /// </summary>
        private void BtnReporteClientes_Click(object sender, EventArgs e)
        {
            try
            {
                // Se instancia el formulario del reporte
                FormClientes formClientes = new FormClientes();

                // Se muestra como ventana modal (bloquea interacción con otras ventanas)
                formClientes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al abrir reporte de Clientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Abre el reporte de productos en modo modal.
        /// </summary>
        private void BtnReporteProductos_Click(object sender, EventArgs e)
        {
            try
            {
                FormProductos formProductos = new FormProductos();
                formProductos.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al abrir reporte de Productos:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ================================
        //      CONTROL DE FORMULARIO
        // ================================

        /// <summary>
        /// Cierra el formulario de selección de reportes.
        /// </summary>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
