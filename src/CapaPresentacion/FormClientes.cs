using System;
using System.Data;
using System.Windows.Forms;
using CapaDatos;
using CapaDatos.Reportes;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario encargado de mostrar el listado de clientes mediante un reporte de Crystal Reports.
    /// 
    /// Este formulario:
    /// - Obtiene los datos desde la capa de datos (incluyendo información de la empresa).
    /// - Valida la estructura del DataSet.
    /// - Carga y renderiza el reporte CrystalReportCliente.
    /// 
    /// Forma parte del módulo de visualización de información del sistema.
    /// </summary>
    public partial class FormClientes : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// Inicializa los componentes visuales.
        /// </summary>
        public FormClientes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Se encarga de obtener los datos y renderizar el reporte.
        /// </summary>
        private void FormClientes_Load(object sender, EventArgs e)
        {
            try
            {
                // ============================================
                // 1. OBTENER DATOS DESDE LA CAPA DE DATOS
                // ============================================
                ConexionBD conexion = new ConexionBD();

                // DataSet que contiene clientes + empresa (estructura preparada para reportes)
                DataSet ds = conexion.ObtenerClientesConEmpresa();

                // ============================================
                // 2. VALIDAR ESTRUCTURA DEL DATASET
                // ============================================
                if (!ds.Tables.Contains("Cliente"))
                    throw new Exception("La tabla 'Cliente' no existe en el DataSet.");

                // ============================================
                // 3. CREAR Y CONFIGURAR REPORTE
                // ============================================
                var reporte = new CrystalReportCliente();

                // Se asigna SOLO la tabla necesaria (mejor práctica para Crystal Reports)
                reporte.SetDataSource(ds.Tables["Cliente"]);

                // ============================================
                // 4. MOSTRAR REPORTE EN EL VISOR
                // ============================================
                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Manejo de errores controlado para evitar caídas de la aplicación
                MessageBox.Show(
                    "Error al cargar el reporte de clientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Evento de carga del visor de Crystal Reports.
        /// Actualmente no contiene lógica, pero queda preparado para futuras extensiones.
        /// </summary>
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // Punto de extensión futura (ej: personalización del viewer)
        }
    }
}

