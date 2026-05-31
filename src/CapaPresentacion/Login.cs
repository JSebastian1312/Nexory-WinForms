// ======================================================
// LOGIN.cs
// LOGIN PREMIUM DARK UI - SISTEMA FACTURACIÓN PROFESIONAL
// ======================================================

using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario de autenticación del sistema.
    /// </summary>
    public partial class Login : Form
    {
        // ================================
        //      CONSTRUCTOR
        // ================================
        public Login()
        {
            InitializeComponent();

            // ENTER para iniciar sesión
            txtClave.KeyDown += TxtClave_KeyDown;

            // Focus visual moderno
            txtNombre.Enter += TextBox_Enter;
            txtNombre.Leave += TextBox_Leave;

            txtClave.Enter += TextBox_Enter;
            txtClave.Leave += TextBox_Leave;

            // Hover botones
            btnIngresar.MouseEnter += BtnIngresar_MouseEnter;
            btnIngresar.MouseLeave += BtnIngresar_MouseLeave;

            btnCancelar.MouseEnter += BtnCancelar_MouseEnter;
            btnCancelar.MouseLeave += BtnCancelar_MouseLeave;

            // Mostrar/Ocultar contraseña
            btnMostrarClave.Click += BtnMostrarClave_Click;

            // Optimización visual
            this.DoubleBuffered = true;
        }

        // ================================
        //      LOAD
        // ================================
        private void Login_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        // ================================
        //      TECLADO
        // ================================
        private void TxtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Ingresar();
        }

        // ================================
        //      BOTONES
        // ================================
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ================================
        //      MOSTRAR CLAVE
        // ================================
        private void BtnMostrarClave_Click(object sender, EventArgs e)
        {
            txtClave.PasswordChar =
                txtClave.PasswordChar == '●' ? '\0' : '●';

            btnMostrarClave.IconChar =
                txtClave.PasswordChar == '●'
                ? FontAwesome.Sharp.IconChar.Eye
                : FontAwesome.Sharp.IconChar.EyeSlash;
        }

        // ================================
        //      EFECTOS FOCUS
        // ================================
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender == txtNombre)
                lineUsuario.BackColor = Color.FromArgb(59, 130, 246);

            if (sender == txtClave)
                lineClave.BackColor = Color.FromArgb(59, 130, 246);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            lineUsuario.BackColor = Color.FromArgb(70, 70, 70);
            lineClave.BackColor = Color.FromArgb(70, 70, 70);
        }

        // ================================
        //      HOVER BOTÓN INGRESAR
        // ================================
        private void BtnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(96, 165, 250);
        }

        private void BtnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.FromArgb(59, 130, 246);
        }

        // ================================
        //      HOVER BOTÓN CANCELAR
        // ================================
        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void BtnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = Color.FromArgb(45, 45, 45);
        }

        // ================================
        //      LOGIN
        // ================================
        private void Ingresar()
        {
            string nombre = txtNombre.Text.Trim();
            string clave = txtClave.Text.Trim();

            // VALIDACIONES

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show(
                    "Ingrese el nombre de usuario",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show(
                    "Ingrese la contraseña",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtClave.Focus();
                return;
            }

            // VALIDACIÓN USUARIO

            Usuario usuario = new Usuario();

            if (usuario.VerificarUsuario(nombre, clave))
            {
                MenuPrincipal menuForm = new MenuPrincipal();
                menuForm.Show();

                this.Hide();

                menuForm.FormClosing += (s, ev) =>
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
                    else
                    {
                        ev.Cancel = true;
                    }
                };
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtClave.Clear();
                txtClave.Focus();
            }
        }

        // ================================
        //      PANEL LATERAL
        // ================================
        private void PanelLateral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}