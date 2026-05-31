using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Clase responsable de gestionar la conexión a la base de datos SQL Server.
    /// 
    /// Centraliza el acceso a la cadena de conexión y provee métodos reutilizables
    /// para abrir, cerrar y validar conexiones, así como para obtener datos en formato DataSet.
    /// 
    /// Esta clase es utilizada por las capas superiores (Entidad y Presentación).
    /// </summary>
    public class ConexionBD
    {
        #region === CONFIGURACIÓN ===

        /// <summary>
        /// Cadena de conexión obtenida desde app.config.
        /// </summary>
        private readonly string connectionString;

        #endregion

        #region === CONSTRUCTOR ===

        /// <summary>
        /// Inicializa la clase leyendo la cadena de conexión desde el archivo de configuración.
        /// </summary>
        /// <exception cref="Exception">
        /// Se lanza si no se encuentra la cadena de conexión.
        /// </exception>
        public ConexionBD()
        {
            try
            {
                connectionString = ConfigurationManager
                    .ConnectionStrings["DB_Facturacion"]
                    ?.ConnectionString;

                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new Exception(
                        "No se encontró la cadena de conexión 'DB_Facturacion' en app.config.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer la cadena de conexión: " + ex.Message);
            }
        }

        #endregion

        #region === MÉTODOS DE CONEXIÓN ===

        /// <summary>
        /// Crea y abre una conexión SQL.
        /// 
        /// El consumidor de este método es responsable de cerrarla o utilizar 'using'.
        /// </summary>
        /// <returns>Instancia de SqlConnection abierta.</returns>
        public SqlConnection AbrirConexion()
        {
            try
            {
                var conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error al abrir la conexión con la base de datos: " + ex.Message);
            }
        }

        /// <summary>
        /// Cierra una conexión SQL si se encuentra abierta.
        /// </summary>
        /// <param name="conn">Conexión a cerrar.</param>
        public void CerrarConexion(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        /// <summary>
        /// Verifica si la conexión a la base de datos es válida.
        /// </summary>
        /// <param name="mensaje">Mensaje de resultado.</param>
        /// <returns>True si la conexión es exitosa, false en caso contrario.</returns>
        public bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (SqlConnection conn = AbrirConexion())
                {
                    mensaje = "Conexión exitosa a la base de datos.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al conectar: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region === MÉTODOS PARA REPORTES (DATASETS) ===

        /// <summary>
        /// Obtiene un DataSet completo de facturas con sus relaciones.
        /// 
        /// Diseñado específicamente para alimentar reportes (Crystal Reports).
        /// </summary>
        public DataSet ObtenerFacturas()
        {
            DataSet ds = new DataSet();

            const string query = @"
                SELECT 
                    F.FacturaID, F.Fecha, F.TipoFactura, F.CAE, F.FechaVencimientoCAE,
                    F.SubTotal, F.Iva, F.Total, F.Observaciones,

                    C.ClienteID,
                    C.Nombre AS ClienteNombre,
                    C.CUIT_CUIL AS ClienteCUIT_CUIL,
                    C.Domicilio AS ClienteDomicilio,
                    L1.Nombre AS ClienteLocalidad,
                    P1.Nombre AS ClienteProvincia,

                    E.EmpresaID,
                    E.Nombre AS EmpresaNombre,
                    E.CUIT AS EmpresaCUIT,
                    E.Domicilio AS EmpresaDomicilio,
                    L2.Nombre AS EmpresaLocalidad,
                    P2.Nombre AS EmpresaProvincia,

                    CV.Descripcion AS CondicionVenta,
                    CI.Descripcion AS CondicionIVA,

                    DF.DetalleFacturaID,
                    DF.Codigo AS ProductoCodigo,
                    DF.Descripcion AS ProductoDescripcion,
                    DF.Cantidad,
                    DF.Subtotal AS DetalleSubtotal

                FROM Factura F
                INNER JOIN Cliente C ON F.ClienteID = C.ClienteID
                INNER JOIN Empresa E ON F.EmpresaID = E.EmpresaID
                INNER JOIN Localidad L1 ON C.LocalidadID = L1.LocalidadID
                INNER JOIN Provincia P1 ON L1.ProvinciaID = P1.ProvinciaID
                INNER JOIN Localidad L2 ON E.LocalidadID = L2.LocalidadID
                INNER JOIN Provincia P2 ON L2.ProvinciaID = P2.ProvinciaID
                INNER JOIN CondicionVenta CV ON F.CondicionVentaID = CV.CondicionVentaID
                INNER JOIN CondicionIVA CI ON F.CondicionIVAID = CI.CondicionIVAID
                INNER JOIN DetalleFactura DF ON F.FacturaID = DF.FacturaID
                ORDER BY F.Fecha DESC;";

            using (SqlConnection conn = AbrirConexion())
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                da.Fill(ds, "Facturas");
            }

            return ds;
        }

        /// <summary>
        /// Obtiene clientes junto con datos de la empresa.
        /// 
        /// Utilizado para reportes de clientes.
        /// </summary>
        public DataSet ObtenerClientesConEmpresa()
        {
            DataSet ds = new DataSet();

            const string query = @"
                SELECT 
                    C.ClienteID,
                    C.Nombre AS ClienteNombre,
                    C.CUIT_CUIL AS ClienteCUIT_CUIL,
                    C.Domicilio AS ClienteDomicilio,
                    L1.Nombre AS ClienteLocalidad,
                    P1.Nombre AS ClienteProvincia,
                    CV.Descripcion AS ClienteCondicionVenta,
                    CI.Descripcion AS ClienteCondicionIVA,

                    E.EmpresaID,
                    E.Nombre AS EmpresaNombre,
                    E.CUIT AS EmpresaCUIT,
                    E.Domicilio AS EmpresaDomicilio,
                    L2.Nombre AS EmpresaLocalidad,
                    P2.Nombre AS EmpresaProvincia,
                    CIE.Descripcion AS EmpresaCondicionIVA

                FROM Cliente C
                INNER JOIN Localidad L1 ON C.LocalidadID = L1.LocalidadID
                INNER JOIN Provincia P1 ON L1.ProvinciaID = P1.ProvinciaID
                INNER JOIN CondicionVenta CV ON C.CondicionVentaID = CV.CondicionVentaID
                INNER JOIN CondicionIVA CI ON C.CondicionIVAID = CI.CondicionIVAID

                CROSS JOIN (
                    SELECT TOP 1 * FROM Empresa ORDER BY EmpresaID
                ) E

                INNER JOIN Localidad L2 ON E.LocalidadID = L2.LocalidadID
                INNER JOIN Provincia P2 ON L2.ProvinciaID = P2.ProvinciaID
                INNER JOIN CondicionIVA CIE ON E.CondicionIVAID = CIE.CondicionIVAID

                WHERE C.Activo = 1
                ORDER BY C.Nombre;";

            using (SqlConnection conn = AbrirConexion())
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                da.Fill(ds, "Cliente");
            }

            return ds;
        }

        /// <summary>
        /// Obtiene productos junto con información de la empresa.
        /// 
        /// Utilizado para reportes de productos.
        /// </summary>
        public DataSet ObtenerProductosConEmpresa()
        {
            DataSet ds = new DataSet();

            const string query = @"
                SELECT
                    P.ProductoID,
                    P.Codigo AS ProductoCodigo,
                    P.Descripcion AS ProductoDescripcion,
                    P.Precio AS ProductoPrecio,

                    E.EmpresaID,
                    E.Nombre AS EmpresaNombre,
                    E.CUIT AS EmpresaCUIT,
                    E.Domicilio AS EmpresaDomicilio,
                    L2.Nombre AS EmpresaLocalidad,
                    P2.Nombre AS EmpresaProvincia,
                    CIE.Descripcion AS EmpresaCondicionIVA

                FROM Producto P

                CROSS JOIN (
                    SELECT TOP 1 * FROM Empresa ORDER BY EmpresaID
                ) E

                INNER JOIN Localidad L2 ON E.LocalidadID = L2.LocalidadID
                INNER JOIN Provincia P2 ON L2.ProvinciaID = P2.ProvinciaID
                INNER JOIN CondicionIVA CIE ON E.CondicionIVAID = CIE.CondicionIVAID

                ORDER BY P.Descripcion;";

            using (SqlConnection conn = AbrirConexion())
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                da.Fill(ds, "Producto");
            }

            return ds;
        }

        #endregion
    }
}