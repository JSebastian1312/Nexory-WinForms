using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>
    /// Dashboard principal del sistema
    /// </summary>
    public partial class MenuPrincipal : Form
    {
        // =========================================================
        // COLORES GLOBALES UI
        // =========================================================

        private readonly Color colorNormal =
            Color.FromArgb(32, 32, 40);

        private readonly Color colorHover =
            Color.FromArgb(45, 90, 190);

        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MenuPrincipal()
        {
            InitializeComponent();

            ConfigurarEfectosUI();
        }

        // =========================================================
        // LOAD
        // =========================================================

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        // =========================================================
        // EFECTOS VISUALES
        // =========================================================

        private void ConfigurarEfectosUI()
        {
            AplicarHover(btnInicio);
            AplicarHover(btnReportes);
            AplicarHover(btnNuevo);
            AplicarHover(btnSalir);
        }

        private void AplicarHover(Button boton)
        {
            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = colorHover;
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = colorNormal;
            };
        }

        // =========================================================
        // NAVEGACIÓN
        // =========================================================

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Inicio());
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new SeleccionReportes());
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new FormNuevoItem())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (frm.TipoSeleccionado)
                    {
                        case FormNuevoItem.Tipo.NuevoCliente:
                            AbrirGestionCliente();
                            break;

                        case FormNuevoItem.Tipo.NuevoProducto:
                            AbrirGestionProducto();
                            break;
                    }
                }
            }
        }

        // =========================================================
        // CLIENTES
        // =========================================================

        private void AbrirGestionCliente()
        {
            FormGestionCliente frmCliente =
                new FormGestionCliente();

            frmCliente.ClienteAgregado += () =>
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Inicio frmInicio)
                    {
                        frmInicio.CargarClientes();
                        break;
                    }
                }
            };

            AbrirFormulario(frmCliente);
        }

        // =========================================================
        // PRODUCTOS
        // =========================================================

        private void AbrirGestionProducto()
        {
            FormGestionarProducto frmProducto =
                new FormGestionarProducto();

            frmProducto.ProductosActualizados += () =>
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Inicio frmInicio)
                    {
                        frmInicio.CargarProductos();
                        break;
                    }
                }
            };

            AbrirFormulario(frmProducto);
        }

        // =========================================================
        // SALIR
        // =========================================================

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "¿Desea cerrar la aplicación?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // =========================================================
        // ABRIR FORMULARIOS
        // =========================================================

        private void AbrirFormulario(Form formulario)
        {
            try
            {
                formulario.Show();

                this.Hide();

                formulario.FormClosing += (s, ev) =>
                {
                    this.Show();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al abrir formulario: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
