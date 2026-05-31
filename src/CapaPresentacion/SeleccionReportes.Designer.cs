using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    partial class SeleccionReportes
    {
        private System.ComponentModel.IContainer components = null;

        // =========================
        // CONTROLES
        // =========================

        private Panel panelLateral;
        private Panel panelHeader;

        private IconPictureBox iconPictureBoxLogo;

        private Label lblTitulo;
        private Label lblBrandSub;

        private Label lblDashboard;
        private Label lblDescripcion;

        private IconButton btnReporteClientes;
        private IconButton btnReporteProductos;
        private IconButton btnCancelar;

        // =========================
        // DISPOSE
        // =========================

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        // =========================
        // INIT
        // =========================

        private void InitializeComponent()
        {
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.iconPictureBoxLogo = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnReporteClientes = new FontAwesome.Sharp.IconButton();
            this.btnReporteProductos = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.panelLateral.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.panelLateral.Controls.Add(this.panelHeader);
            this.panelLateral.Controls.Add(this.lblTitulo);
            this.panelLateral.Controls.Add(this.lblBrandSub);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(320, 561);
            this.panelLateral.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.panelHeader.Controls.Add(this.iconPictureBoxLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(320, 260);
            this.panelHeader.TabIndex = 0;
            // 
            // iconPictureBoxLogo
            // 
            this.iconPictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBoxLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.iconPictureBoxLogo.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.iconPictureBoxLogo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.iconPictureBoxLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBoxLogo.IconSize = 184;
            this.iconPictureBoxLogo.Location = new System.Drawing.Point(66, 29);
            this.iconPictureBoxLogo.Name = "iconPictureBoxLogo";
            this.iconPictureBoxLogo.Size = new System.Drawing.Size(184, 186);
            this.iconPictureBoxLogo.TabIndex = 0;
            this.iconPictureBoxLogo.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 300);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(320, 45);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "NEXORY";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lblBrandSub.Location = new System.Drawing.Point(0, 350);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(320, 25);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Enterprise Management System";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(380, 60);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(303, 45);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "Centro de Reportes";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblDescripcion.Location = new System.Drawing.Point(382, 110);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(253, 20);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Seleccione un reporte para continuar";
            // 
            // btnReporteClientes
            // 
            this.btnReporteClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnReporteClientes.FlatAppearance.BorderSize = 0;
            this.btnReporteClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnReporteClientes.ForeColor = System.Drawing.Color.White;
            this.btnReporteClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnReporteClientes.IconColor = System.Drawing.Color.White;
            this.btnReporteClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporteClientes.IconSize = 56;
            this.btnReporteClientes.Location = new System.Drawing.Point(380, 180);
            this.btnReporteClientes.Name = "btnReporteClientes";
            this.btnReporteClientes.Size = new System.Drawing.Size(220, 170);
            this.btnReporteClientes.TabIndex = 3;
            this.btnReporteClientes.Text = "Reporte Clientes";
            this.btnReporteClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReporteClientes.UseVisualStyleBackColor = false;
            this.btnReporteClientes.Click += new System.EventHandler(this.BtnReporteClientes_Click);
            // 
            // btnReporteProductos
            // 
            this.btnReporteProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnReporteProductos.FlatAppearance.BorderSize = 0;
            this.btnReporteProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnReporteProductos.ForeColor = System.Drawing.Color.White;
            this.btnReporteProductos.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.btnReporteProductos.IconColor = System.Drawing.Color.White;
            this.btnReporteProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReporteProductos.IconSize = 56;
            this.btnReporteProductos.Location = new System.Drawing.Point(640, 180);
            this.btnReporteProductos.Name = "btnReporteProductos";
            this.btnReporteProductos.Size = new System.Drawing.Size(220, 170);
            this.btnReporteProductos.TabIndex = 4;
            this.btnReporteProductos.Text = "Reporte Productos";
            this.btnReporteProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReporteProductos.UseVisualStyleBackColor = false;
            this.btnReporteProductos.Click += new System.EventHandler(this.BtnReporteProductos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 56;
            this.btnCancelar.Location = new System.Drawing.Point(380, 390);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(480, 120);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // SeleccionReportes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1007, 561);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnReporteClientes);
            this.Controls.Add(this.btnReporteProductos);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SeleccionReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEXORY - Reportes";
            this.panelLateral.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}