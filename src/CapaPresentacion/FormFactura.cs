using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario encargado de visualizar una factura mediante Crystal Reports.
    /// 
    /// Este formulario recibe un DataSet desde la capa de negocio/presentación,
    /// el cual contiene toda la información necesaria para renderizar la factura.
    /// 
    /// Responsabilidades:
    /// - Validar los datos recibidos
    /// - Cargar el reporte correspondiente
    /// - Mostrar la factura en el visor CrystalReportViewer
    /// </summary>
    public partial class FormFactura : Form
    {
        // ============================================
        //              ATRIBUTOS
        // ============================================

        /// <summary>
        /// DataSet que contiene los datos de la factura a visualizar.
        /// </summary>
        private readonly DataSet dataSet;

        /// <summary>
        /// Documento de Crystal Reports utilizado para renderizar la factura.
        /// </summary>
        private ReportDocument reporte;

        // ============================================
        //              CONSTRUCTOR
        // ============================================

        /// <summary>
        /// Inicializa el formulario con los datos de la factura.
        /// </summary>
        /// <param name="dataSet">DataSet con la información de la factura</param>
        public FormFactura(DataSet dataSet)
        {
            InitializeComponent();
            this.dataSet = dataSet ?? throw new ArgumentNullException(nameof(dataSet));
        }

        // ============================================
        //              EVENTOS
        // ============================================

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Se encarga de validar datos y renderizar el reporte.
        /// </summary>
        private void FormFactura_Load(object sender, EventArgs e)
        {
            try
            {
                ValidarDataSet();

                // Nota:
                // El ReportDocument ya viene cargado desde el método que abre este formulario
                // (ImprimirFactura), por lo tanto aquí solo se asegura el refresco visual.

                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la factura:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================
        //              MÉTODOS PRIVADOS
        // ============================================

        /// <summary>
        /// Valida que el DataSet contenga datos antes de renderizar el reporte.
        /// </summary>
        private void ValidarDataSet()
        {
            if (dataSet == null)
                throw new Exception("El DataSet de la factura es nulo.");

            if (dataSet.Tables.Count == 0)
                throw new Exception("El DataSet no contiene tablas.");

            if (dataSet.Tables[0].Rows.Count == 0)
                throw new Exception("El DataSet no contiene datos para mostrar.");
        }

        /// <summary>
        /// Libera recursos utilizados por el reporte al cerrar el formulario.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try
            {
                if (reporte != null)
                {
                    reporte.Close();
                    reporte.Dispose();
                }
            }
            catch
            {
                // Evita errores silenciosos al cerrar
            }

            base.OnFormClosed(e);
        }
    }
}