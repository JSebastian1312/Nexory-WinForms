using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario encargado de la gestión completa de clientes.
    /// Incorpora la identidad visual oscura NEXORY y controles nativos estables.
    /// </summary>
    public partial class FormGestionCliente : Form
    {
        // =========================================================
        // DEPENDENCIAS (CAPA DATOS)
        // =========================================================
        private ClienteDatos clienteDatos;
        private LocalidadDatos localidadDatos;
        private ConexionBD conexion;

        /// <summary>
        /// Evento para notificar a otros formularios que se realizaron cambios.
        /// </summary>
        public event Action ClienteAgregado;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public FormGestionCliente()
        {
            InitializeComponent();

            // Inicialización de dependencias de negocio
            clienteDatos = new ClienteDatos();
            localidadDatos = new LocalidadDatos();
            conexion = new ConexionBD();

            // Configuración inicial de UI
            ConfigurarPlaceholders();
            AsociarEventosPaint();

            // Inicialización y carga de datos distribuidos en grilla
            CargarCombos();
            CargarClientesEnGrilla();
        }

        // =========================================================
        // EVENTO LOAD
        // =========================================================
        private void FormGestionCliente_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarClientesEnGrilla();
        }

        // =========================================================
        // CONFIGURACIÓN VISUAL (UI NEXORY)
        // =========================================================
        private void AsociarEventosPaint()
        {
            txtNombre.Paint += TextBox_PaintShadow;
            txtCUIT.Paint += TextBox_PaintShadow;
            txtDomicilio.Paint += TextBox_PaintShadow;

            cmbLocalidad.Paint += ComboBox_PaintShadow;
            cmbCondicionIVA.Paint += ComboBox_PaintShadow;
        }

        private void ConfigurarPlaceholders()
        {
            ConfigurarPlaceholder(txtNombre, "Nombre completo");
            ConfigurarPlaceholder(txtCUIT, "CUIT / CUIL");
            ConfigurarPlaceholder(txtDomicilio, "Domicilio");
        }

        private void ConfigurarPlaceholder(TextBox txt, string texto)
        {
            txt.Text = texto;
            txt.ForeColor = Color.Gray;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == texto)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.White;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = texto;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void TextBox_PaintShadow(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid);
        }

        private void ComboBox_PaintShadow(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            ControlPaint.DrawBorder(e.Graphics, c.ClientRectangle,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(55, 55, 70), 1, ButtonBorderStyle.Solid);
        }

        // =========================================================
        // EFECTOS HOVER CENTRALIZADOS
        // =========================================================
        private void ButtonHoverEnter(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                btn.BackColor = Color.FromArgb(45, 45, 58);
            }
        }

        private void ButtonHoverLeave(object sender, EventArgs e)
        {
            if (sender is IconButton btn)
            {
                if (btn == btnVolver)
                    btn.BackColor = Color.FromArgb(32, 32, 40);
                else if (btn == btnEliminar)
                    btn.BackColor = Color.FromArgb(180, 50, 50);
                else
                    btn.BackColor = Color.FromArgb(32, 32, 40);
            }
        }

        // =========================================================
        // CARGA DE COMBOS Y GRID
        // =========================================================
        private void CargarCombos()
        {
            CargarLocalidades();
            CargarCondicionesIVA();
        }

        private void CargarLocalidades()
        {
            try
            {
                var localidades = clienteDatos.ObtenerLocalidades();
                if (localidades != null)
                {
                    localidades.Insert(0, "-- Seleccione --");
                    cmbLocalidad.DataSource = localidades;
                }
            }
            catch { }
        }

        private void CargarConditionsIVA()
        {
            // Mantenido por compatibilidad
            CargarCondicionesIVA();
        }

        private void CargarCondicionesIVA()
        {
            try
            {
                var lista = CondicionIVA.ObtenerCondicionesIVA(conexion);
                if (lista != null)
                {
                    lista.Insert(0, new CondicionIVA { CondicionIVAID = 0, Descripcion = "-- Seleccione --" });
                    cmbCondicionIVA.DataSource = lista;
                    cmbCondicionIVA.DisplayMember = "Descripcion";
                    cmbCondicionIVA.ValueMember = "CondicionIVAID";
                }
            }
            catch { }
        }

        private void CargarClientesEnGrilla()
        {
            try
            {
                dgvClientes.Rows.Clear();
                DataTable tabla = clienteDatos.ObtenerClientesTabla();

                if (tabla != null)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        dgvClientes.Rows.Add(
                            row["ClienteID"],
                            row["Nombre"],
                            row["CUIT_CUIL"],
                            row["Domicilio"],
                            row["Localidad"],
                            row["CondicionIVAID"],
                            row["CondicionVentaID"]
                        );
                    }
                }
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando clientes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ACCIONES CRUD
        // =========================================================
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string cuit = txtCUIT.Text.Trim();
            string domicilio = txtDomicilio.Text.Trim();
            string localidad = cmbLocalidad.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || nombre == "Nombre completo" ||
                string.IsNullOrEmpty(cuit) || cuit == "CUIT / CUIL" ||
                string.IsNullOrEmpty(domicilio) || domicilio == "Domicilio" ||
                cmbLocalidad.SelectedIndex <= 0)
            {
                MessageBox.Show("Complete todos los campos correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int iva = cmbCondicionIVA.SelectedValue != null ? (int)cmbCondicionIVA.SelectedValue : 0;
            bool ok = clienteDatos.AgregarCliente(nombre, cuit, domicilio, localidad, iva, 1);

            if (ok)
            {
                ClienteAgregado?.Invoke();
                CargarClientesEnGrilla();
                MessageBox.Show("Cliente agregado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
            int iva = cmbCondicionIVA.SelectedValue != null ? (int)cmbCondicionIVA.SelectedValue : 0;

            bool ok = clienteDatos.ModificarCliente(
                id,
                txtNombre.Text.Trim(),
                txtCUIT.Text.Trim(),
                txtDomicilio.Text.Trim(),
                cmbLocalidad.Text.Trim(),
                iva,
                1
            );

            if (ok)
            {
                ClienteAgregado?.Invoke();
                CargarClientesEnGrilla();
                MessageBox.Show("Cliente actualizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;

            // Acceso seguro por índice 0 (Primera columna: ID)
            var cellValue = dgvClientes.SelectedRows[0].Cells[0].Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int id = Convert.ToInt32(cellValue);

            if (MessageBox.Show("¿Desea eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool ok = clienteDatos.EliminarCliente(id);
                if (ok)
                {
                    ClienteAgregado?.Invoke();
                    CargarClientesEnGrilla();
                    MessageBox.Show("Cliente eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvClientes_SelectionChanged(sender, e);
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;

            var fila = dgvClientes.SelectedRows[0];

            if (fila.Cells["Nombre"].Value != null)
            {
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtNombre.ForeColor = Color.White;
            }

            if (fila.Cells["CUIT_CUIL"].Value != null)
            {
                txtCUIT.Text = fila.Cells["CUIT_CUIL"].Value.ToString();
                txtCUIT.ForeColor = Color.White;
            }

            if (fila.Cells["Domicilio"].Value != null)
            {
                txtDomicilio.Text = fila.Cells["Domicilio"].Value.ToString();
                txtDomicilio.ForeColor = Color.White;
            }

            if (fila.Cells["Localidad"].Value != null)
                cmbLocalidad.Text = fila.Cells["Localidad"].Value.ToString();

            if (fila.Cells["CondicionIVAID"].Value != null)
                cmbCondicionIVA.SelectedValue = Convert.ToInt32(fila.Cells["CondicionIVAID"].Value);
        }

        private void BtnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            ConfigurarPlaceholders();
            if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = 0;
            if (cmbCondicionIVA.Items.Count > 0) cmbCondicionIVA.SelectedIndex = 0;
        }

        private void PanelLateral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}