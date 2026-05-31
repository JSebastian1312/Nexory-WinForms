using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaPresentacion.Factura1;
using CapaPresentacion.Factura1.DataSetFacturaTableAdapters;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CapaPresentacion
{
    /// <summary>
    /// Pantalla principal de facturación
    /// Diseño profesional estilo Nexory
    /// </summary>
    public partial class Inicio : Form
    {
        // =====================================================
        // CAMPOS
        // =====================================================

        private readonly ConexionBD conexion;
        private readonly DataSetFactura dataSet;

        private List<Producto> listaProductos;
        private List<Cliente> listaClientes;

        private int ultimoFacturaID = 0;
        private bool cargandoForm = false;

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public Inicio()
        {
            InitializeComponent();

            conexion = new ConexionBD();
            dataSet = new DataSetFactura();
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                cargandoForm = true;

                ConfigurarEstiloVisual();

                CargarClientes();
                CargarProductos();
                CargarCondicionesIVA();
                CargarCondicionesVenta();

                cargandoForm = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al inicializar el formulario:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // ESTILO VISUAL
        // =====================================================

        private void ConfigurarEstiloVisual()
        {
            dgvventas.EnableHeadersVisualStyles = false;

            dgvventas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
            dgvventas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvventas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            dgvventas.DefaultCellStyle.BackColor = Color.FromArgb(32, 32, 32);
            dgvventas.DefaultCellStyle.ForeColor = Color.White;

            dgvventas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(38, 38, 38);

            dgvventas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(124, 58, 237);

            dgvventas.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvventas.GridColor = Color.FromArgb(55, 55, 55);

            dgvventas.RowTemplate.Height = 35;

            dgvventas.BorderStyle = BorderStyle.None;
        }

        // =====================================================
        // CARGA DE DATOS
        // =====================================================

        public void CargarClientes(int seleccionarClienteID = 0)
        {
            listaClientes = Cliente.ObtenerClientes() ?? new List<Cliente>();

            listaClientes.Insert(0, new Cliente
            {
                ClienteID = 0,
                Nombre = "-- Seleccione un cliente --"
            });

            cboclientes.DataSource = listaClientes;
            cboclientes.DisplayMember = "Nombre";
            cboclientes.ValueMember = "ClienteID";

            SeleccionarItemCombo(cboclientes, seleccionarClienteID);
        }

        public void CargarProductos()
        {
            listaProductos = new Producto().ObtenerProductos() ?? new List<Producto>();

            listaProductos.Insert(0, new Producto
            {
                ProductoID = 0,
                Descripcion = "-- Seleccione un producto --"
            });

            cboproducto.DataSource = listaProductos;
            cboproducto.DisplayMember = "Descripcion";
            cboproducto.ValueMember = "ProductoID";

            SeleccionarPrimerItem(cboproducto);
        }

        private void CargarCondicionesIVA()
        {
            var lista =
                CondicionIVA.ObtenerCondicionesIVA(conexion)
                ?? new List<CondicionIVA>();

            lista.Insert(0, new CondicionIVA
            {
                CondicionIVAID = 0,
                Descripcion = "-- Seleccione una condición IVA --"
            });

            cbocondicionIVA.DataSource = lista;
            cbocondicionIVA.DisplayMember = "Descripcion";
            cbocondicionIVA.ValueMember = "CondicionIVAID";

            if (cbocondicionIVA.Items.Count > 0)
                cbocondicionIVA.SelectedIndex = 0;
        }

        private void CargarCondicionesVenta()
        {
            var lista =
                CondicionVenta.ObtenerCondicionesVenta()
                ?? new List<CondicionVenta>();

            lista.Insert(0, new CondicionVenta
            {
                CondicionVentaID = 0,
                Descripcion = "-- Seleccione una condición de venta --"
            });

            cbocondicionVenta.DataSource = lista;
            cbocondicionVenta.DisplayMember = "Descripcion";
            cbocondicionVenta.ValueMember = "CondicionVentaID";

            if (cbocondicionVenta.Items.Count > 0)
                cbocondicionVenta.SelectedIndex = 0;
        }

        // =====================================================
        // EVENTOS
        // =====================================================

        private void Cboclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoForm) return;

            if (cboclientes.SelectedItem is Cliente cliente &&
                cliente.ClienteID > 0)
            {
                txtdomicilio.Text = cliente.Domicilio;
                txtlocalidad.Text = cliente.Localidad;

                cbocondicionIVA.SelectedValue = cliente.CondicionIVAID;
                cbocondicionVenta.SelectedValue = cliente.CondicionVentaID;
            }
            else
            {
                LimpiarDatosCliente();
            }
        }

        private void Cboproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoForm) return;

            if (cboproducto.SelectedItem is Producto producto &&
                producto.ProductoID > 0)
            {
                txtprecio.Text = producto.Precio.ToString("N2");
            }
            else
            {
                txtprecio.Clear();
            }
        }

        // =====================================================
        // AGREGAR PRODUCTO
        // =====================================================

        private void Btnguardar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngresoProducto())
                return;

            Producto producto = (Producto)cboproducto.SelectedItem;

            int cantidad = int.Parse(txtcantidad.Text);

            decimal subtotal = producto.Precio * cantidad;

            dgvventas.Rows.Add(
                producto.Codigo,
                producto.Descripcion,
                cantidad,
                producto.Precio.ToString("N2"),
                subtotal.ToString("N2")
            );
            ActualizarTotalesVisuales();
            LimpiarCamposProducto();
        }

        // =====================================================
        // NUEVO
        // =====================================================

        private void Btnnuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // =====================================================
        // GUARDAR FACTURA
        // =====================================================

        private void Btncargar_Click(object sender, EventArgs e)
        {
            GuardarFactura();
        }

        private void GuardarFactura()
        {
            try
            {
                if (!(cboclientes.SelectedItem is Cliente cliente) ||
                    cliente.ClienteID == 0)
                {
                    MessageBox.Show(
                        "Seleccione un cliente válido.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Empresa empresa = Empresa.BuscarPorID(1);

                if (empresa == null)
                {
                    MessageBox.Show(
                        "Empresa no encontrada.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                Factura factura = new Factura
                {
                    Cliente = cliente,
                    Empresa = empresa,
                    Fecha = DateTime.Now,
                    CondicionVenta = new CondicionVenta
                    {
                        CondicionVentaID =
                            Convert.ToInt32(cbocondicionVenta.SelectedValue)
                    }
                };

                factura.DeterminarTipoFactura(
                    Convert.ToInt32(cbocondicionIVA.SelectedValue)
                );

                foreach (DataGridViewRow row in dgvventas.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    factura.ListaDetalles.Add(new DetalleFactura
                    {
                        Producto = new Producto
                        {
                            Codigo =
                                row.Cells["productoCodigo"].Value.ToString(),

                            Descripcion =
                                row.Cells["detalleproducto"].Value.ToString(),

                            Precio =
                                Convert.ToDecimal(
                                    row.Cells["precio"].Value
                                )
                        },

                        Cantidad =
                            Convert.ToInt32(
                                row.Cells["cantidad"].Value
                            )
                    });
                }

                factura.CalcularSubtotal();
                factura.CalcularIva();
                factura.CalcularTotal();

                ultimoFacturaID = factura.Guardar();

                if (ultimoFacturaID <= 0)
                {
                    MessageBox.Show(
                        "No se pudo guardar la factura.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    $"Factura #{ultimoFacturaID} guardada exitosamente.",
                    "Factura guardada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarClientes(cliente.ClienteID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al guardar factura:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // IMPRIMIR
        // =====================================================

        private void Btnimprimir_Click(object sender, EventArgs e)
        {
            ImprimirFactura();
        }

        private void ImprimirFactura()
        {
            if (ultimoFacturaID == 0)
            {
                MessageBox.Show(
                    "No hay factura para imprimir.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                DataSetFactura ds = new DataSetFactura();

                ds.EnforceConstraints = false;

                using (var conn = conexion.AbrirConexion())
                {
                    var adapter = new DataTable1TableAdapter();

                    adapter.Connection = conn;

                    adapter.Fill(ds.DataTable1, ultimoFacturaID);
                }

                if (ds.DataTable1.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron datos.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string condicionIVA =
                    ds.DataTable1.Rows[0]["CondicionIVA"].ToString();

                string ruta = System.IO.Path.Combine(
                    Application.StartupPath,
                    "Factura1",
                    condicionIVA == "Responsable Inscripto"
                        ? "FacturaReports.rpt"
                        : "CrystalReportB.rpt"
                );

                ReportDocument rpt = new ReportDocument();

                rpt.Load(ruta, OpenReportMethod.OpenReportByTempCopy);

                rpt.SetDataSource(ds);

                FormFactura frm = new FormFactura(ds);

                frm.crystalReportViewer1.ReportSource = rpt;

                frm.ShowDialog();

                rpt.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al imprimir factura:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // VOLVER
        // =====================================================

        private void Btnvolver_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea volver al menú principal?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // =====================================================
        // MÉTODOS AUXILIARES
        // =====================================================

        private bool ValidarIngresoProducto()
        {
            if (cboclientes.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Seleccione un cliente.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (cboproducto.SelectedIndex == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (!int.TryParse(txtcantidad.Text, out int cantidad) ||
                cantidad <= 0)
            {
                MessageBox.Show(
                    "Ingrese una cantidad válida.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void LimpiarDatosCliente()
        {
            txtdomicilio.Clear();
            txtlocalidad.Clear();
        }

        private void LimpiarCamposProducto()
        {
            txtcantidad.Clear();
            txtprecio.Clear();

            SeleccionarPrimerItem(cboproducto);

            txtcantidad.Focus();
        }

        private void ActualizarTotalesVisuales()
        {
            decimal subtotalGeneral = 0m;

            foreach (DataGridViewRow row in dgvventas.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object valorCelda = row.Cells["subtotal"].Value;

                if (valorCelda != null)
                {
                    string texto = valorCelda.ToString()
                        .Replace("$", "")
                        .Replace(".", "")
                        .Trim();

                    texto = texto.Replace(",", ".");

                    if (decimal.TryParse(
                        texto,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out decimal subtotalFila))
                    {
                        subtotalGeneral += subtotalFila;
                    }
                }
            }

            decimal iva = subtotalGeneral * 0.21m;
            decimal total = subtotalGeneral + iva;

            lblSubtotalValor.Text = "$ " + subtotalGeneral.ToString("N2");
            lblIvaValor.Text = "$ " + iva.ToString("N2");
            lblTotalValor.Text = "$ " + total.ToString("N2");
        }

        private void LimpiarFormulario()
        {
            LimpiarDatosCliente();
            LimpiarCamposProducto();

            dgvventas.Rows.Clear();

            lblSubtotalValor.Text = "$ 0.00";
            lblIvaValor.Text = "$ 0.00";
            lblTotalValor.Text = "$ 0.00";

            SeleccionarPrimerItem(cboclientes);
            SeleccionarPrimerItem(cbocondicionIVA);
            SeleccionarPrimerItem(cbocondicionVenta);

            ultimoFacturaID = 0;
        }

        private void SeleccionarPrimerItem(ComboBox combo)
        {
            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        private void SeleccionarItemCombo(ComboBox combo, int id)
        {
            foreach (var item in combo.Items)
            {
                var prop =
                    item.GetType().GetProperty(combo.ValueMember);

                if (prop != null &&
                    Convert.ToInt32(prop.GetValue(item)) == id)
                {
                    combo.SelectedItem = item;
                    return;
                }
            }

            if (combo.Items.Count > 0)
                combo.SelectedIndex = 0;
        }
    }
}