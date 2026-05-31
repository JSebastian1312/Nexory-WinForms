using System;
using System.Data;
using System.Windows.Forms;
using CapaDatos;
using CapaDatos.Reportes;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario encargado de mostrar el reporte de productos.
    /// 
    /// Responsabilidades:
    /// - Obtener los datos desde la capa de datos.
    /// - Validar la estructura del DataSet.
    /// - Configurar el reporte Crystal Reports.
    /// - Renderizar la información en el visor.
    /// </summary>
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento de carga del formulario.
        /// Inicializa el flujo completo del reporte de productos.
        /// </summary>
        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarReporteProductos();
        }

        /// <summary>
        /// Ejecuta el flujo completo de generación del reporte.
        /// Separado en método para mejorar mantenibilidad y reutilización.
        /// </summary>
        private void CargarReporteProductos()
        {
            try
            {
                // ===============================
                // 1. OBTENER DATOS DESDE CAPA DATOS
                // ===============================
                ConexionBD conexion = new ConexionBD();
                DataSet ds = conexion.ObtenerProductosConEmpresa();

                // ===============================
                // 2. VALIDACIÓN CRÍTICA
                // ===============================
                if (!ds.Tables.Contains("Producto"))
                    throw new Exception("La tabla 'Producto' no existe en el DataSet.");

                DataTable tablaProductos = ds.Tables["Producto"];

                if (tablaProductos.Rows.Count == 0)
                    throw new Exception("No hay datos disponibles para generar el reporte.");

                // ===============================
                // 3. CONFIGURACIÓN DEL REPORTE
                // ===============================
                CrystalReportProductos reporte = new CrystalReportProductos();

                // Asignación de datos
                reporte.SetDataSource(tablaProductos);

                // ===============================
                // 4. VISUALIZACIÓN
                // ===============================
                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MostrarError("Error al generar el reporte de productos", ex);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Punto de extensión para configuraciones futuras del visor
        }

        // ============================================
        // MÉTODOS AUXILIARES
        // ============================================

        /// <summary>
        /// Centraliza el manejo de errores para mantener consistencia en UI.
        /// </summary>
        private void MostrarError(string contexto, Exception ex)
        {
            MessageBox.Show(
                $"{contexto}:\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}