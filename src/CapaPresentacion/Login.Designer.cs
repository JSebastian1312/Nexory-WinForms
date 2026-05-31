using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        // ======================================================
        // CONTROLES
        // ======================================================

        private Panel panelLateral;

        private IconPictureBox iconSistema;

        private Label lblTitulo;
        private Label lblBrandSub;

        private Label lblSubtitulo;

        private Label lblNombre;
        private Label lblClave;

        private TextBox txtNombre;
        private TextBox txtClave;

        private Panel lineUsuario;
        private Panel lineClave;

        private IconButton btnIngresar;
        private IconButton btnCancelar;
        private IconButton btnMostrarClave;

        // ======================================================
        // DISPOSE
        // ======================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        // ======================================================
        // INITIALIZE COMPONENT
        // ======================================================

        private void InitializeComponent()
        {
            this.panelLateral = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.iconSistema = new FontAwesome.Sharp.IconPictureBox();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lineUsuario = new System.Windows.Forms.Panel();
            this.lineClave = new System.Windows.Forms.Panel();
            this.btnIngresar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnMostrarClave = new FontAwesome.Sharp.IconButton();
            this.panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.panelLateral.Controls.Add(this.lblBrandSub);
            this.panelLateral.Controls.Add(this.lblTitulo);
            this.panelLateral.Controls.Add(this.iconSistema);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(1, 1);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Padding = new System.Windows.Forms.Padding(30);
            this.panelLateral.Size = new System.Drawing.Size(320, 586);
            this.panelLateral.TabIndex = 0;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.lblBrandSub.Location = new System.Drawing.Point(30, 290);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(260, 35);
            this.lblBrandSub.TabIndex = 0;
            this.lblBrandSub.Text = "Enterprise Management System";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 220);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(260, 70);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "NEXORY";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconSistema
            // 
            this.iconSistema.BackColor = System.Drawing.Color.Transparent;
            this.iconSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.iconSistema.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.iconSistema.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.iconSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSistema.IconSize = 190;
            this.iconSistema.Location = new System.Drawing.Point(30, 30);
            this.iconSistema.Name = "iconSistema";
            this.iconSistema.Size = new System.Drawing.Size(260, 190);
            this.iconSistema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconSistema.TabIndex = 2;
            this.iconSistema.TabStop = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(390, 70);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(179, 19);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Acceda con sus credenciales";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblNombre.Location = new System.Drawing.Point(390, 140);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Usuario";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblClave.Location = new System.Drawing.Point(390, 250);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(67, 15);
            this.lblClave.TabIndex = 5;
            this.lblClave.Text = "Contraseña";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(390, 170);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(320, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClave.ForeColor = System.Drawing.Color.White;
            this.txtClave.Location = new System.Drawing.Point(390, 280);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '●';
            this.txtClave.Size = new System.Drawing.Size(285, 20);
            this.txtClave.TabIndex = 6;
            // 
            // lineUsuario
            // 
            this.lineUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lineUsuario.Location = new System.Drawing.Point(390, 200);
            this.lineUsuario.Name = "lineUsuario";
            this.lineUsuario.Size = new System.Drawing.Size(320, 2);
            this.lineUsuario.TabIndex = 4;
            // 
            // lineClave
            // 
            this.lineClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lineClave.Location = new System.Drawing.Point(390, 310);
            this.lineClave.Name = "lineClave";
            this.lineClave.Size = new System.Drawing.Size(320, 2);
            this.lineClave.TabIndex = 7;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnIngresar.IconColor = System.Drawing.Color.White;
            this.btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresar.IconSize = 24;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(390, 360);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnIngresar.Size = new System.Drawing.Size(320, 50);
            this.btnIngresar.TabIndex = 9;
            this.btnIngresar.Text = " Iniciar Sesión";
            this.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCancelar.IconColor = System.Drawing.Color.White;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 22;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(390, 425);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btnCancelar.Size = new System.Drawing.Size(320, 50);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = " Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnMostrarClave
            // 
            this.btnMostrarClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMostrarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarClave.FlatAppearance.BorderSize = 0;
            this.btnMostrarClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarClave.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnMostrarClave.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnMostrarClave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarClave.Location = new System.Drawing.Point(685, 285);
            this.btnMostrarClave.Name = "btnMostrarClave";
            this.btnMostrarClave.Size = new System.Drawing.Size(25, 19);
            this.btnMostrarClave.TabIndex = 8;
            this.btnMostrarClave.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(869, 588);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lineUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lineClave);
            this.Controls.Add(this.btnMostrarClave);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEXORY";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconSistema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}