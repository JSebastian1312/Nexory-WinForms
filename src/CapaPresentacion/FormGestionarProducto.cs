using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario de gestión de productos adaptado a la línea visual oscura NEXORY.
    /// Implementa operaciones CRUD blindadas mediante accesos seguros por índice.
    /// </summary>
    public partial class FormGestionarProducto : Form
    {
        // =========================================================
        // ATRIBUTOS Y LOGICA DE NEGOCIO
        // =========================================================
        private readonly ProductoDatos productoDatos;
        private readonly Producto productoEntidad;

        private const string PLACEHOLDER_DESCRIPCION = "Descripción del producto";
        private const string PLACEHOLDER_PRECIO = "Precio";

        /// <summary>
        /// Evento que notifica la actualización del catálogo a otras pantallas.
        /// </summary>
        public event Action ProductosActualizados;

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public FormGestionarProducto()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                productoDatos = new ProductoDatos();
                productoEntidad = new Producto();

                InicializarFormulario();
            }
        }

        // =========================================================
        // INICIALIZACIÓN Y CONFIGURACIÓN VISUAL
        // =========================================================
        private void InicializarFormulario()
        {
            ConfigurarPlaceholders();
            AsociarEventosPaint();
            CargarProductosEnGrilla();
        }

        private void AsociarEventosPaint()
        {
            txtDescripcion.Paint += TextBox_PaintShadow;
            txtPrecio.Paint += TextBox_PaintShadow;
        }

        private void ConfigurarPlaceholders()
        {
            ConfigurarPlaceholder(txtDescripcion, PLACEHOLDER_DESCRIPCION);
            ConfigurarPlaceholder(txtPrecio, PLACEHOLDER_PRECIO);
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

        // =========================================================
        // EFECTOS HOVER CENTRALIZADOS (NEXORY STYLE)
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
                if (btn == btnEliminar)
                    btn.BackColor = Color.FromArgb(180, 50, 50);
                else
                    btn.BackColor = Color.FromArgb(32, 32, 40);
            }
        }

        // =========================================================
        // MANEJO DE LA GRILLA (SEGURO POR ÍNDICES)
        // =========================================================
        private void CargarProductosEnGrilla()
        {
            try
            {
                // Apagamos temporalmente el evento de selección para evitar efectos colaterales nulos
                this.dgvProductos.SelectionChanged -= new EventHandler(this.DgvProductos_SelectionChanged);

                dgvProductos.Rows.Clear();
                List<Producto> productos = productoEntidad.ObtenerProductos();

                if (productos != null)
                {
                    foreach (var p in productos)
                    {
                        dgvProductos.Rows.Add(
                            p.ProductoID,
                            p.Codigo,
                            p.Descripcion,
                            p.Precio
                        );
                    }
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar productos", ex);
            }
            finally
            {
                // Reasociamos el evento de manera segura
                this.dgvProductos.SelectionChanged += new EventHandler(this.DgvProductos_SelectionChanged);

                if (dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.ClearSelection();
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvProductos_SelectionChanged(sender, e);
        }

        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            var fila = dgvProductos.SelectedRows[0];

            // Accesos blindados por número de columna posicional para evitar caídas de runtime
            if (fila.Cells[2].Value != null)
            {
                txtDescripcion.Text = fila.Cells[2].Value.ToString();
                txtDescripcion.ForeColor = Color.White;
            }

            if (fila.Cells[3].Value != null)
            {
                txtPrecio.Text = fila.Cells[3].Value.ToString();
                txtPrecio.ForeColor = Color.White;
            }
        }

        // =========================================================
        // OPERACIONES CRUD
        // =========================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = ObtenerTextoValido(txtDescripcion, PLACEHOLDER_DESCRIPCION);
                decimal precio = ObtenerPrecioValido(txtPrecio);

                if (productoDatos.AgregarProducto(descripcion, precio))
                {
                    MostrarInfo("Producto agregado correctamente.");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al agregar producto", ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int productoID = ObtenerProductoSeleccionado();
                decimal nuevoPrecio = ObtenerPrecioValido(txtPrecio);

                if (productoDatos.ActualizarPrecio(productoID, nuevoPrecio))
                {
                    MostrarInfo("Precio actualizado correctamente.");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar producto", ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int productoID = ObtenerProductoSeleccionado();

                if (!Confirmar("¿Desea eliminar este producto?"))
                    return;

                if (productoDatos.EliminarProducto(productoID))
                {
                    MostrarInfo("Producto eliminado correctamente.");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al eliminar producto", ex);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =========================================================
        // VALIDACIONES Y LOGICA AUXILIAR
        // =========================================================
        private int ObtenerProductoSeleccionado()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                throw new Exception("Debe seleccionar un producto de la lista.");

            // Celda [0] representa la columna ID
            var cellValue = dgvProductos.SelectedRows[0].Cells[0].Value;
            if (cellValue == null || cellValue == DBNull.Value)
                throw new Exception("La fila seleccionada no posee un ID de producto válido.");

            return Convert.ToInt32(cellValue);
        }

        private string ObtenerTextoValido(TextBox txt, string placeholder)
        {
            string texto = txt.Text.Trim();

            if (string.IsNullOrEmpty(texto) || texto == placeholder)
                throw new Exception("Debe ingresar una descripción válida.");

            return texto;
        }

        private decimal ObtenerPrecioValido(TextBox txt)
        {
            if (!decimal.TryParse(txt.Text.Trim(), out decimal precio) || precio <= 0)
                throw new Exception("Debe ingresar un precio numérico válido y mayor a cero.");

            return precio;
        }

        private void Refrescar()
        {
            CargarProductosEnGrilla();
            ProductosActualizados?.Invoke();
        }

        private void LimpiarCampos()
        {
            ConfigurarPlaceholders();
        }

        private void MostrarInfo(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarError(string contexto, Exception ex)
        {
            MessageBox.Show($"{contexto}:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}