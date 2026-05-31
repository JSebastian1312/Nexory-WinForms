using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblSubtitulo;

        private GroupBox gbCliente;
        private GroupBox gbProducto;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private Label label6;
        private Label label7;
        private Label label9;

        private ComboBox cboclientes;
        private ComboBox cbocondicionIVA;
        private ComboBox cbocondicionVenta;
        private ComboBox cboproducto;

        private TextBox txtdomicilio;
        private TextBox txtlocalidad;
        private TextBox txtprecio;
        private TextBox txtcantidad;

        private DataGridView dgvventas;

        private DataGridViewTextBoxColumn productoCodigo;
        private DataGridViewTextBoxColumn detalleproducto;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn subtotal;

        private Button btnnuevo;
        private Button btnguardar;
        private Button btncargar;
        private Button btnimprimir;
        private Button btnvolver;

        private Panel panelTotales;

        private Label lblSubtotal;
        private Label lblIVA;
        private Label lblTotal;

        private Label lblSubtotalValor;
        private Label lblIvaValor;
        private Label lblTotalValor;

        /// <summary>
        /// Limpiar recursos
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboclientes = new System.Windows.Forms.ComboBox();
            this.txtdomicilio = new System.Windows.Forms.TextBox();
            this.txtlocalidad = new System.Windows.Forms.TextBox();
            this.cbocondicionIVA = new System.Windows.Forms.ComboBox();
            this.cbocondicionVenta = new System.Windows.Forms.ComboBox();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboproducto = new System.Windows.Forms.ComboBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.dgvventas = new System.Windows.Forms.DataGridView();
            this.productoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btncargar = new System.Windows.Forms.Button();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.btnvolver = new System.Windows.Forms.Button();
            this.panelTotales = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSubtotalValor = new System.Windows.Forms.Label();
            this.lblIvaValor = new System.Windows.Forms.Label();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.gbCliente.SuspendLayout();
            this.gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).BeginInit();
            this.panelTotales.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblSubtitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1403, 86);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(34, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(154, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "NEXORY";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(185)))), ((int)(((byte)(195)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 56);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(300, 20);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Plataforma inteligente de gestión comercial";
            // 
            // gbCliente
            // 
            this.gbCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.gbCliente.Controls.Add(this.label1);
            this.gbCliente.Controls.Add(this.label2);
            this.gbCliente.Controls.Add(this.label3);
            this.gbCliente.Controls.Add(this.label4);
            this.gbCliente.Controls.Add(this.label5);
            this.gbCliente.Controls.Add(this.cboclientes);
            this.gbCliente.Controls.Add(this.txtdomicilio);
            this.gbCliente.Controls.Add(this.txtlocalidad);
            this.gbCliente.Controls.Add(this.cbocondicionIVA);
            this.gbCliente.Controls.Add(this.cbocondicionVenta);
            this.gbCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.gbCliente.ForeColor = System.Drawing.Color.White;
            this.gbCliente.Location = new System.Drawing.Point(30, 101);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(500, 278);
            this.gbCliente.TabIndex = 1;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "Datos del Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Domicilio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(25, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Localidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(25, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Condición IVA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(25, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Condición Venta:";
            // 
            // cboclientes
            // 
            this.cboclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.cboclientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboclientes.ForeColor = System.Drawing.Color.White;
            this.cboclientes.Location = new System.Drawing.Point(190, 42);
            this.cboclientes.Name = "cboclientes";
            this.cboclientes.Size = new System.Drawing.Size(280, 28);
            this.cboclientes.TabIndex = 5;
            this.cboclientes.SelectedIndexChanged += new System.EventHandler(this.Cboclientes_SelectedIndexChanged);
            // 
            // txtdomicilio
            // 
            this.txtdomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.txtdomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdomicilio.ForeColor = System.Drawing.Color.White;
            this.txtdomicilio.Location = new System.Drawing.Point(190, 87);
            this.txtdomicilio.Name = "txtdomicilio";
            this.txtdomicilio.ReadOnly = true;
            this.txtdomicilio.Size = new System.Drawing.Size(280, 27);
            this.txtdomicilio.TabIndex = 6;
            // 
            // txtlocalidad
            // 
            this.txtlocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.txtlocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlocalidad.ForeColor = System.Drawing.Color.White;
            this.txtlocalidad.Location = new System.Drawing.Point(190, 132);
            this.txtlocalidad.Name = "txtlocalidad";
            this.txtlocalidad.ReadOnly = true;
            this.txtlocalidad.Size = new System.Drawing.Size(280, 27);
            this.txtlocalidad.TabIndex = 7;
            // 
            // cbocondicionIVA
            // 
            this.cbocondicionIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.cbocondicionIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocondicionIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbocondicionIVA.ForeColor = System.Drawing.Color.White;
            this.cbocondicionIVA.Location = new System.Drawing.Point(190, 177);
            this.cbocondicionIVA.Name = "cbocondicionIVA";
            this.cbocondicionIVA.Size = new System.Drawing.Size(280, 28);
            this.cbocondicionIVA.TabIndex = 8;
            // 
            // cbocondicionVenta
            // 
            this.cbocondicionVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.cbocondicionVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocondicionVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbocondicionVenta.ForeColor = System.Drawing.Color.White;
            this.cbocondicionVenta.Location = new System.Drawing.Point(190, 222);
            this.cbocondicionVenta.Name = "cbocondicionVenta";
            this.cbocondicionVenta.Size = new System.Drawing.Size(280, 28);
            this.cbocondicionVenta.TabIndex = 9;
            // 
            // gbProducto
            // 
            this.gbProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.gbProducto.Controls.Add(this.label6);
            this.gbProducto.Controls.Add(this.label7);
            this.gbProducto.Controls.Add(this.label9);
            this.gbProducto.Controls.Add(this.cboproducto);
            this.gbProducto.Controls.Add(this.txtcantidad);
            this.gbProducto.Controls.Add(this.txtprecio);
            this.gbProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.gbProducto.ForeColor = System.Drawing.Color.White;
            this.gbProducto.Location = new System.Drawing.Point(30, 407);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(500, 182);
            this.gbProducto.TabIndex = 2;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Agregar Producto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(25, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(25, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cantidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(25, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Precio:";
            // 
            // cboproducto
            // 
            this.cboproducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.cboproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboproducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboproducto.ForeColor = System.Drawing.Color.White;
            this.cboproducto.Location = new System.Drawing.Point(190, 42);
            this.cboproducto.Name = "cboproducto";
            this.cboproducto.Size = new System.Drawing.Size(280, 28);
            this.cboproducto.TabIndex = 3;
            this.cboproducto.SelectedIndexChanged += new System.EventHandler(this.Cboproducto_SelectedIndexChanged);
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.txtcantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcantidad.ForeColor = System.Drawing.Color.White;
            this.txtcantidad.Location = new System.Drawing.Point(190, 92);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(120, 27);
            this.txtcantidad.TabIndex = 4;
            // 
            // txtprecio
            // 
            this.txtprecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.txtprecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprecio.ForeColor = System.Drawing.Color.White;
            this.txtprecio.Location = new System.Drawing.Point(190, 142);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.ReadOnly = true;
            this.txtprecio.Size = new System.Drawing.Size(120, 27);
            this.txtprecio.TabIndex = 5;
            // 
            // dgvventas
            // 
            this.dgvventas.AllowUserToAddRows = false;
            this.dgvventas.AllowUserToDeleteRows = false;
            this.dgvventas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvventas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvventas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.dgvventas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvventas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvventas.ColumnHeadersHeight = 40;
            this.dgvventas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productoCodigo,
            this.detalleproducto,
            this.cantidad,
            this.precio,
            this.subtotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvventas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvventas.EnableHeadersVisualStyles = false;
            this.dgvventas.Location = new System.Drawing.Point(560, 112);
            this.dgvventas.MultiSelect = false;
            this.dgvventas.Name = "dgvventas";
            this.dgvventas.ReadOnly = true;
            this.dgvventas.RowHeadersVisible = false;
            this.dgvventas.RowHeadersWidth = 51;
            this.dgvventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvventas.Size = new System.Drawing.Size(818, 477);
            this.dgvventas.TabIndex = 3;
            // 
            // productoCodigo
            // 
            this.productoCodigo.HeaderText = "Código";
            this.productoCodigo.MinimumWidth = 6;
            this.productoCodigo.Name = "productoCodigo";
            this.productoCodigo.ReadOnly = true;
            // 
            // detalleproducto
            // 
            this.detalleproducto.HeaderText = "Descripción";
            this.detalleproducto.MinimumWidth = 6;
            this.detalleproducto.Name = "detalleproducto";
            this.detalleproducto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.btnnuevo.FlatAppearance.BorderSize = 0;
            this.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnuevo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnnuevo.ForeColor = System.Drawing.Color.White;
            this.btnnuevo.Location = new System.Drawing.Point(30, 658);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(130, 45);
            this.btnnuevo.TabIndex = 5;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.Btnnuevo_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.btnguardar.FlatAppearance.BorderSize = 0;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.Location = new System.Drawing.Point(182, 659);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(130, 45);
            this.btnguardar.TabIndex = 6;
            this.btnguardar.Text = "Agregar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.Btnguardar_Click);
            // 
            // btncargar
            // 
            this.btncargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.btncargar.FlatAppearance.BorderSize = 0;
            this.btncargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncargar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btncargar.ForeColor = System.Drawing.Color.White;
            this.btncargar.Location = new System.Drawing.Point(329, 659);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(180, 45);
            this.btncargar.TabIndex = 7;
            this.btncargar.Text = "Guardar Factura";
            this.btncargar.UseVisualStyleBackColor = false;
            this.btncargar.Click += new System.EventHandler(this.Btncargar_Click);
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(0)))), ((int)(((byte)(238)))));
            this.btnimprimir.FlatAppearance.BorderSize = 0;
            this.btnimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnimprimir.ForeColor = System.Drawing.Color.White;
            this.btnimprimir.Location = new System.Drawing.Point(531, 658);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(130, 45);
            this.btnimprimir.TabIndex = 8;
            this.btnimprimir.Text = "Imprimir";
            this.btnimprimir.UseVisualStyleBackColor = false;
            this.btnimprimir.Click += new System.EventHandler(this.Btnimprimir_Click);
            // 
            // btnvolver
            // 
            this.btnvolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnvolver.FlatAppearance.BorderSize = 0;
            this.btnvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvolver.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnvolver.ForeColor = System.Drawing.Color.White;
            this.btnvolver.Location = new System.Drawing.Point(682, 659);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(130, 45);
            this.btnvolver.TabIndex = 9;
            this.btnvolver.Text = "Volver";
            this.btnvolver.UseVisualStyleBackColor = false;
            this.btnvolver.Click += new System.EventHandler(this.Btnvolver_Click);
            // 
            // panelTotales
            // 
            this.panelTotales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.panelTotales.Controls.Add(this.lblSubtotal);
            this.panelTotales.Controls.Add(this.lblIVA);
            this.panelTotales.Controls.Add(this.lblTotal);
            this.panelTotales.Controls.Add(this.lblSubtotalValor);
            this.panelTotales.Controls.Add(this.lblIvaValor);
            this.panelTotales.Controls.Add(this.lblTotalValor);
            this.panelTotales.Location = new System.Drawing.Point(1088, 609);
            this.panelTotales.Name = "panelTotales";
            this.panelTotales.Size = new System.Drawing.Size(290, 105);
            this.panelTotales.TabIndex = 4;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtotal.Location = new System.Drawing.Point(20, 15);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(63, 19);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblIVA.Location = new System.Drawing.Point(20, 45);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(33, 19);
            this.lblIVA.TabIndex = 1;
            this.lblIVA.Text = "IVA:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTotal.Location = new System.Drawing.Point(20, 75);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 19);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "TOTAL:";
            // 
            // lblSubtotalValor
            // 
            this.lblSubtotalValor.AutoSize = true;
            this.lblSubtotalValor.ForeColor = System.Drawing.Color.White;
            this.lblSubtotalValor.Location = new System.Drawing.Point(180, 15);
            this.lblSubtotalValor.Name = "lblSubtotalValor";
            this.lblSubtotalValor.Size = new System.Drawing.Size(48, 19);
            this.lblSubtotalValor.TabIndex = 3;
            this.lblSubtotalValor.Text = "$ 0.00";
            // 
            // lblIvaValor
            // 
            this.lblIvaValor.AutoSize = true;
            this.lblIvaValor.ForeColor = System.Drawing.Color.White;
            this.lblIvaValor.Location = new System.Drawing.Point(180, 45);
            this.lblIvaValor.Name = "lblIvaValor";
            this.lblIvaValor.Size = new System.Drawing.Size(48, 19);
            this.lblIvaValor.TabIndex = 4;
            this.lblIvaValor.Text = "$ 0.00";
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.lblTotalValor.Location = new System.Drawing.Point(180, 75);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(53, 20);
            this.lblTotalValor.TabIndex = 5;
            this.lblTotalValor.Text = "$ 0.00";
            // 
            // Inicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1403, 781);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbProducto);
            this.Controls.Add(this.dgvventas);
            this.Controls.Add(this.panelTotales);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.btnvolver);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEXORY";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvventas)).EndInit();
            this.panelTotales.ResumeLayout(false);
            this.panelTotales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}