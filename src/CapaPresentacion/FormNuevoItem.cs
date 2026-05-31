using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario modal selector para la creación de nuevos registros (Clientes / Productos).
    /// Utiliza el marco nativo del sistema operativo para mantener consistencia visual.
    /// </summary>
    public partial class FormNuevoItem : Form
    {
        // =========================================================
        // ENUMERACIONES Y PROPIEDADES DE ESTADO
        // =========================================================
        public enum Tipo
        {
            Ninguno,
            NuevoCliente,
            NuevoProducto
        }

        /// <summary>
        /// Obtiene el tipo de registro seleccionado por el usuario.
        /// </summary>
        public Tipo TipoSeleccionado { get; private set; } = Tipo.Ninguno;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public FormNuevoItem()
        {
            InitializeComponent();
        }

        // =========================================================
        // ACCIONES DE BOTONES (ASIGNACIÓN DE DIALOGRESULT)
        // =========================================================
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = Tipo.NuevoCliente;
            this.DialogResult = DialogResult.OK; // Asignar OK cierra automáticamente el Form modal
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = Tipo.NuevoProducto;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TipoSeleccionado = Tipo.Ninguno;
            this.DialogResult = DialogResult.Cancel; // Asignar Cancel cierra el Form de manera segura
        }

        // =========================================================
        // EVENTOS HOVER CENTRALIZADOS (IDENTIDAD OSCURA NEXORY)
        // =========================================================
        private void ButtonHoverEnter(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                // Variación sutil a un tono más claro para simular iluminación al pasar el mouse
                btn.BackColor = Color.FromArgb(45, 45, 58);
            }
        }

        private void ButtonHoverLeave(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                // Retorno al color base original de la tarjeta del botón
                btn.BackColor = Color.FromArgb(32, 32, 40);
            }
        }
    }
}