using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    partial class FormGestionarProducto
    {
        private System.ComponentModel.IContainer components = null;

        // Estructura de Contenedores Nexory
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelTopLogo;
        private FontAwesome.Sharp.IconPictureBox iconLogo;
        private System.Windows.Forms.Label lblBrandingTitulo;
        private System.Windows.Forms.Panel panelFormulario;

        // Componentes de Captura de Datos
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;

        // Botoneras Modernas (FontAwesome)
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnActualizar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnVolver;

        private System.Windows.Forms.DataGridView dgvProductos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRows = new System.Windows.Forms.DataGridViewCellStyle();

            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelTopLogo = new System.Windows.Forms.Panel();
            this.iconLogo = new FontAwesome.Sharp.IconPictureBox();
            this.lblBrandingTitulo = new System.Windows.Forms.Label();

            this.panelFormulario = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();

            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnVolver = new FontAwesome.Sharp.IconButton();

            this.dgvProductos = new System.Windows.Forms.DataGridView();

            this.panelLateral.SuspendLayout();
            this.panelTopLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogo)).BeginInit();
            this.panelFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();

            // =========================================================
            // PANEL LATERAL IZQUIERDO (BRANDING CORPORATIVO)
            // =========================================================
            this.panelLateral.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.panelLateral.Controls.Add(this.panelTopLogo);
            this.panelLateral.Controls.Add(this.lblBrandingTitulo);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(280, 611);
            this.panelLateral.TabIndex = 0;

            // panelTopLogo
            this.panelTopLogo.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            this.panelTopLogo.Controls.Add(this.iconLogo);
            this.panelTopLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopLogo.Location = new System.Drawing.Point(0, 0);
            this.panelTopLogo.Name = "panelTopLogo";
            this.panelTopLogo.Size = new System.Drawing.Size(280, 220);
            this.panelTopLogo.TabIndex = 0;

            // iconLogo (Icono de producto en azul de acento)
            this.iconLogo.BackColor = System.Drawing.Color.Transparent;
            this.iconLogo.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.iconLogo.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.iconLogo.IconColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.iconLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconLogo.IconSize = 110;
            this.iconLogo.Location = new System.Drawing.Point(85, 50);
            this.iconLogo.Name = "iconLogo";
            this.iconLogo.Size = new System.Drawing.Size(110, 110);
            this.iconLogo.TabIndex = 0;
            this.iconLogo.TabStop = false;

            // lblBrandingTitulo
            this.lblBrandingTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBrandingTitulo.ForeColor = System.Drawing.Color.White;
            this.lblBrandingTitulo.Location = new System.Drawing.Point(0, 260);
            this.lblBrandingTitulo.Name = "lblBrandingTitulo";
            this.lblBrandingTitulo.Size = new System.Drawing.Size(280, 35);
            this.lblBrandingTitulo.TabIndex = 1;
            this.lblBrandingTitulo.Text = "Catálogo de Productos";
            this.lblBrandingTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =========================================================
            // PANEL CONTENEDOR CENTRAL DE CAMPOS
            // =========================================================
            this.panelFormulario.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.panelFormulario.Controls.Add(this.lblDescripcion);
            this.panelFormulario.Controls.Add(this.txtDescripcion);
            this.panelFormulario.Controls.Add(this.lblPrecio);
            this.panelFormulario.Controls.Add(this.txtPrecio);
            this.panelFormulario.Location = new System.Drawing.Point(305, 25);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(350, 430);
            this.panelFormulario.TabIndex = 1;

            // lblDescripcion
            this.lblDescripcion.Text = "Descripción General";
            this.lblDescripcion.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(20, 20);
            this.lblDescripcion.Size = new System.Drawing.Size(150, 20);

            // txtDescripcion
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.White;
            this.txtDescripcion.Location = new System.Drawing.Point(20, 45);
            this.txtDescripcion.Size = new System.Drawing.Size(305, 27);

            // lblPrecio
            this.lblPrecio.Text = "Precio Unitario ($)";
            this.lblPrecio.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(20, 95);
            this.lblPrecio.Size = new System.Drawing.Size(150, 20);

            // txtPrecio
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPrecio.ForeColor = System.Drawing.Color.White;
            this.txtPrecio.Location = new System.Drawing.Point(20, 120);
            this.txtPrecio.Size = new System.Drawing.Size(305, 27);

            // =========================================================
            // BOTONERA DE COMANDOS CRUDS (CON ENLACES DE HOVER)
            // =========================================================

            // btnAgregar
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnAgregar.IconColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 24;
            this.btnAgregar.Location = new System.Drawing.Point(305, 475);
            this.btnAgregar.Size = new System.Drawing.Size(165, 45);
            this.btnAgregar.Text = "  Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.MouseEnter += new System.EventHandler(this.ButtonHoverEnter);
            this.btnAgregar.MouseLeave += new System.EventHandler(this.ButtonHoverLeave);

            // btnActualizar
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnActualizar.IconColor = System.Drawing.Color.White;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize = 24;
            this.btnActualizar.Location = new System.Drawing.Point(490, 475);
            this.btnActualizar.Size = new System.Drawing.Size(165, 45);
            this.btnActualizar.Text = "  Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.btnActualizar.MouseEnter += new System.EventHandler(this.ButtonHoverEnter);
            this.btnActualizar.MouseLeave += new System.EventHandler(this.ButtonHoverLeave);

            // btnEliminar
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 24;
            this.btnEliminar.Location = new System.Drawing.Point(305, 540);
            this.btnEliminar.Size = new System.Drawing.Size(165, 45);
            this.btnEliminar.Text = "  Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.MouseEnter += new System.EventHandler(this.ButtonHoverEnter);
            this.btnEliminar.MouseLeave += new System.EventHandler(this.ButtonHoverLeave);

            // btnVolver
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnVolver.IconColor = System.Drawing.Color.FromArgb(255, 120, 120);
            this.btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVolver.IconSize = 24;
            this.btnVolver.Location = new System.Drawing.Point(490, 540);
            this.btnVolver.Size = new System.Drawing.Size(165, 45);
            this.btnVolver.Text = "  Volver";
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.btnVolver.MouseEnter += new System.EventHandler(this.ButtonHoverEnter);
            this.btnVolver.MouseLeave += new System.EventHandler(this.ButtonHoverLeave);

            // =========================================================
            // DATAGRIDVIEW (ESTILO OSCURO INLINE SIN VARIABLES LOCALES)
            // =========================================================
            this.dgvProductos.Location = new System.Drawing.Point(680, 25);
            this.dgvProductos.Size = new System.Drawing.Size(400, 560);
            this.dgvProductos.BackgroundColor = System.Drawing.Color.FromArgb(22, 22, 30);
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(40, 40, 55);
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Inyección en una sola sentencia evaluada para no confundir al CodeDom de Visual Studio
            this.dgvProductos.Columns[this.dgvProductos.Columns.Add("ProductoID", "ID")].Name = "ProductoID";
            this.dgvProductos.Columns[this.dgvProductos.Columns.Add("Codigo", "Código")].Name = "Codigo";
            this.dgvProductos.Columns[this.dgvProductos.Columns.Add("Descripcion", "Descripción")].Name = "Descripcion";
            this.dgvProductos.Columns[this.dgvProductos.Columns.Add("Precio", "Precio")].Name = "Precio";

            // Personalización de estilos del Header
            dgvHeader.BackColor = System.Drawing.Color.FromArgb(28, 28, 38);
            dgvHeader.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            dgvHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dgvHeader;
            this.dgvProductos.ColumnHeadersHeight = 40;

            // Personalización de estilos de Filas
            dgvRows.BackColor = System.Drawing.Color.FromArgb(32, 32, 40);
            dgvRows.ForeColor = System.Drawing.Color.White;
            dgvRows.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvRows.SelectionBackColor = System.Drawing.Color.FromArgb(45, 45, 58);
            dgvRows.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProductos.DefaultCellStyle = dgvRows;
            this.dgvProductos.RowTemplate.Height = 35;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);

            // =========================================================
            // CONFIGURACIÓN DE PROPIEDADES DEL FORMULARIO BASE
            // =========================================================
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(15, 15, 20);
            this.ClientSize = new System.Drawing.Size(1100, 611);

            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panelFormulario);
            this.Controls.Add(this.panelLateral);

            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Forzar Barra del SO Nativa celeste/clásica según especificaciones
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "FormGestionarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEXORY";

            this.panelLateral.ResumeLayout(false);
            this.panelTopLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconLogo)).EndInit();
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}