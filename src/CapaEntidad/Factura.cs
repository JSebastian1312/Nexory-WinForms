using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaEntidad
{
    /// <summary>
    /// Representa una factura completa dentro del sistema de facturación.
    /// 
    /// Incluye:
    /// - Encabezado (cliente, empresa, fecha)
    /// - Lógica fiscal (tipo de comprobante)
    /// - Totales (subtotal, IVA, total)
    /// - Detalle de ítems
    /// 
    /// Además, gestiona:
    /// - Cálculos de importes
    /// - Generación de número de comprobante
    /// - Persistencia en base de datos con transacción
    /// </summary>
    public class Factura
    {
        #region === DEPENDENCIAS ===

        /// <summary>
        /// Acceso a la base de datos.
        /// </summary>
        private readonly ConexionBD conexion = new ConexionBD();

        #endregion

        #region === CAMPOS PRIVADOS ===

        private int _facturaId;
        private Cliente _cliente;
        private Empresa _empresa;
        private DateTime _fecha;
        private CondicionVenta _condicionVenta;
        private List<DetalleFactura> _listaDetalles = new List<DetalleFactura>();

        private decimal _total;
        private decimal _subtotal;
        private decimal _iva;

        private string _tipoFactura;
        private string _numeroFactura;
        private string _observaciones;

        #endregion

        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único de la factura (generado en base de datos).
        /// </summary>
        public int FacturaId { get => _facturaId; private set => _facturaId = value; }

        /// <summary>
        /// Cliente al que se le emite la factura.
        /// </summary>
        public Cliente Cliente { get => _cliente; set => _cliente = value; }

        /// <summary>
        /// Empresa emisora de la factura.
        /// </summary>
        public Empresa Empresa { get => _empresa; set => _empresa = value; }

        /// <summary>
        /// Fecha de emisión del comprobante.
        /// </summary>
        public DateTime Fecha { get => _fecha; set => _fecha = value; }

        /// <summary>
        /// Condición comercial de la operación (contado, cuenta corriente, etc.).
        /// </summary>
        public CondicionVenta CondicionVenta { get => _condicionVenta; set => _condicionVenta = value; }

        /// <summary>
        /// Lista de ítems incluidos en la factura.
        /// </summary>
        public List<DetalleFactura> ListaDetalles
        {
            get => _listaDetalles;
            set => _listaDetalles = value ?? new List<DetalleFactura>();
        }

        /// <summary>
        /// Total final de la factura.
        /// </summary>
        public decimal Total { get => _total; private set => _total = value; }

        /// <summary>
        /// Subtotal sin impuestos.
        /// </summary>
        public decimal Subtotal { get => _subtotal; private set => _subtotal = value; }

        /// <summary>
        /// Importe de IVA calculado.
        /// </summary>
        public decimal Iva { get => _iva; private set => _iva = value; }

        /// <summary>
        /// Tipo de factura (A, B, etc.) según condición fiscal.
        /// </summary>
        public string TipoFactura { get => _tipoFactura; private set => _tipoFactura = value; }

        /// <summary>
        /// Número de factura generado (simulado en este sistema).
        /// </summary>
        public string NumeroFactura { get => _numeroFactura; private set => _numeroFactura = value; }

        /// <summary>
        /// Observaciones adicionales del comprobante.
        /// </summary>
        public string Observaciones { get => _observaciones; set => _observaciones = value; }

        #endregion

        #region === CONSTRUCTOR ===

        /// <summary>
        /// Inicializa una nueva factura con la fecha actual.
        /// </summary>
        public Factura()
        {
            Fecha = DateTime.Now;
        }

        #endregion

        #region === LÓGICA DE NEGOCIO ===

        /// <summary>
        /// Determina el tipo de factura según la condición de IVA del cliente.
        /// 
        /// Regla simplificada:
        /// - Responsable Inscripto → Factura A
        /// - Otros → Factura B
        /// </summary>
        public void DeterminarTipoFactura(int condicionIvaId)
        {
            TipoFactura = condicionIvaId == 1 ? "A" : "B";
        }

        /// <summary>
        /// Genera un número de factura ficticio.
        /// 
        /// Nota: En un entorno real, este número debería provenir de AFIP
        /// o de una secuencia controlada en base de datos.
        /// </summary>
        public void GenerarNumeroFactura()
        {
            int numero = new Random().Next(100000, 999999);

            NumeroFactura = TipoFactura == "A"
                ? $"0033-000{numero}"
                : $"0025-000{numero}";
        }

        /// <summary>
        /// Calcula el subtotal sumando todos los detalles.
        /// </summary>
        public void CalcularSubtotal()
        {
            decimal suma = 0;

            foreach (var detalle in ListaDetalles)
                suma += detalle.CalcularSubtotal();

            Subtotal = Math.Round(suma, 2);
        }

        /// <summary>
        /// Calcula el IVA aplicando una alícuota fija del 21%.
        /// </summary>
        public void CalcularIva()
        {
            Iva = Math.Round(Subtotal * 0.21m, 2);
        }

        /// <summary>
        /// Calcula el total final de la factura.
        /// </summary>
        public void CalcularTotal()
        {
            Total = Math.Round(Subtotal + Iva, 2);
        }

        /// <summary>
        /// Ejecuta todos los cálculos necesarios antes de guardar.
        /// </summary>
        private void EjecutarCalculos()
        {
            if (ListaDetalles == null || ListaDetalles.Count == 0)
                throw new InvalidOperationException("La factura debe contener al menos un detalle.");

            CalcularSubtotal();
            CalcularIva();
            CalcularTotal();
        }

        #endregion

        #region === PERSISTENCIA ===

        /// <summary>
        /// Guarda la factura y sus detalles en la base de datos.
        /// 
        /// El proceso se ejecuta dentro de una transacción SQL para garantizar:
        /// - Consistencia: o se guarda todo o no se guarda nada
        /// - Integridad: evita facturas incompletas
        /// </summary>
        /// <returns>ID de la factura generada.</returns>
        public int Guardar()
        {
            if (Cliente == null)
                throw new InvalidOperationException("Debe asignarse un cliente a la factura.");

            if (Empresa == null)
                throw new InvalidOperationException("Debe asignarse una empresa a la factura.");

            if (Cliente.CondicionIVA == null)
                throw new InvalidOperationException("El cliente debe tener una condición de IVA válida.");

            // Determinar lógica fiscal antes de guardar
            DeterminarTipoFactura(Cliente.CondicionIVA.CondicionIVAID);
            GenerarNumeroFactura();

            // Calcular totales
            EjecutarCalculos();

            using (SqlConnection conn = conexion.AbrirConexion())
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    const string queryFactura = @"
                        INSERT INTO Factura (
                            ClienteID, EmpresaID, Fecha, TipoFactura,
                            CondicionVentaID, SubTotal, Iva, Total,
                            CAE, FechaVencimientoCAE, Observaciones, CondicionIvaID
                        )
                        OUTPUT INSERTED.FacturaId
                        VALUES (
                            @ClienteID, @EmpresaID, @Fecha, @TipoFactura,
                            @CondicionVentaID, @SubTotal, @Iva, @Total,
                            @CAE, @FechaVencimientoCAE, @Observaciones, @CondicionIvaID
                        )";

                    using (SqlCommand cmd = new SqlCommand(queryFactura, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", Cliente.ClienteID);
                        cmd.Parameters.AddWithValue("@EmpresaID", Empresa.EmpresaID);
                        cmd.Parameters.AddWithValue("@Fecha", Fecha);
                        cmd.Parameters.AddWithValue("@TipoFactura", TipoFactura);
                        cmd.Parameters.AddWithValue("@CondicionVentaID", CondicionVenta?.CondicionVentaID ?? 0);

                        cmd.Parameters.AddWithValue("@SubTotal", Subtotal);
                        cmd.Parameters.AddWithValue("@Iva", Iva);
                        cmd.Parameters.AddWithValue("@Total", Total);

                        // En este sistema se reutiliza como identificador visual
                        cmd.Parameters.AddWithValue("@CAE", NumeroFactura);
                        cmd.Parameters.AddWithValue("@FechaVencimientoCAE", DateTime.Now.AddMonths(1));

                        cmd.Parameters.AddWithValue("@Observaciones", Observaciones ?? string.Empty);
                        cmd.Parameters.AddWithValue("@CondicionIvaID", Cliente.CondicionIVA.CondicionIVAID);

                        FacturaId = (int)cmd.ExecuteScalar();
                    }

                    // Guardado de detalles (misma transacción)
                    foreach (var detalle in ListaDetalles)
                        detalle.Guardar(conn, FacturaId, transaction);

                    transaction.Commit();
                    return FacturaId;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al guardar la factura: " + ex.Message);
                }
            }
        }

        #endregion
    }
}