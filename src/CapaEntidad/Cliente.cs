using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CapaDatos;

namespace CapaEntidad
{
    /// <summary>
    /// Representa un cliente dentro del sistema de facturación.
    /// 
    /// Esta entidad encapsula la información fiscal y comercial necesaria
    /// para la emisión de comprobantes, incluyendo su condición impositiva
    /// y condiciones de venta asociadas.
    /// </summary>
    public class Cliente
    {
        #region === PROPIEDADES ===

        /// <summary>
        /// Identificador único del cliente en la base de datos.
        /// </summary>
        public int ClienteID { get; set; }

        /// <summary>
        /// Nombre o razón social del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// CUIT o CUIL del cliente (identificación fiscal).
        /// </summary>
        public string CuitCuil { get; set; }

        /// <summary>
        /// Dirección física del cliente.
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del cliente (valor descriptivo).
        /// </summary>
        public string Localidad { get; set; }

        /// <summary>
        /// Provincia del cliente (valor descriptivo).
        /// </summary>
        public string Provincia { get; set; }

        /// <summary>
        /// Identificador de la condición frente al IVA.
        /// </summary>
        public int CondicionIVAID { get; set; }

        /// <summary>
        /// Identificador de la condición de venta (contado, cuenta corriente, etc.).
        /// </summary>
        public int CondicionVentaID { get; set; }

        /// <summary>
        /// Objeto de navegación que representa la condición de IVA del cliente.
        /// </summary>
        public CondicionIVA CondicionIVA { get; set; }

        #endregion

        #region === CONSTRUCTOR ===

        public Cliente() { }

        #endregion

        #region === MÉTODOS SOBRESCRITOS ===

        /// <summary>
        /// Representación textual del cliente.
        /// Utilizado principalmente en controles de UI como ComboBox.
        /// </summary>
        public override string ToString()
        {
            return Nombre ?? string.Empty;
        }

        #endregion

        #region === MÉTODOS DE ACCESO A DATOS ===

        /// <summary>
        /// Obtiene la lista completa de clientes activos desde la base de datos.
        /// 
        /// Incluye información de ubicación (localidad y provincia) y
        /// vincula la condición de IVA correspondiente.
        /// </summary>
        /// <returns>Lista de clientes activos.</returns>
        public static List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>();
            var conexion = new ConexionBD();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                const string query = @"
                    SELECT 
                        c.ClienteID,
                        c.Nombre,
                        c.CUIT_CUIL,
                        c.Domicilio,
                        l.Nombre AS Localidad,
                        ISNULL(p.Nombre, '') AS Provincia,
                        c.CondicionIVAID,
                        c.CondicionVentaID
                    FROM Cliente c
                    LEFT JOIN Localidad l ON c.LocalidadID = l.LocalidadID
                    LEFT JOIN Provincia p ON l.ProvinciaID = p.ProvinciaID
                    WHERE c.Activo = 1
                    ORDER BY c.Nombre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            ClienteID = reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            CuitCuil = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Domicilio = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Localidad = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Provincia = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            CondicionIVAID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            CondicionVentaID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7)
                        });
                    }
                }

                // Vinculación de objeto de navegación (Condición IVA)
                VincularCondicionesIVA(clientes, conexion);
            }

            return clientes;
        }

        /// <summary>
        /// Obtiene un cliente activo específico a partir de su ID.
        /// </summary>
        /// <param name="id">Identificador del cliente.</param>
        /// <returns>Instancia de Cliente o null si no existe.</returns>
        public static Cliente ObtenerClientePorID(int id)
        {
            Cliente cliente = null;
            var conexion = new ConexionBD();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                const string query = @"
                    SELECT 
                        c.ClienteID,
                        c.Nombre,
                        c.CUIT_CUIL,
                        c.Domicilio,
                        l.Nombre AS Localidad,
                        ISNULL(p.Nombre, '') AS Provincia,
                        c.CondicionIVAID,
                        c.CondicionVentaID
                    FROM Cliente c
                    LEFT JOIN Localidad l ON c.LocalidadID = l.LocalidadID
                    LEFT JOIN Provincia p ON l.ProvinciaID = p.ProvinciaID
                    WHERE c.ClienteID = @id AND c.Activo = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteID = reader.GetInt32(0),
                                Nombre = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                CuitCuil = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Domicilio = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Localidad = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                Provincia = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                                CondicionIVAID = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                CondicionVentaID = reader.IsDBNull(7) ? 0 : reader.GetInt32(7)
                            };
                        }
                    }
                }

                if (cliente != null)
                {
                    VincularCondicionesIVA(new List<Cliente> { cliente }, conexion);
                }
            }

            return cliente;
        }

        /// <summary>
        /// Obtiene los clientes activos en formato DataTable.
        /// 
        /// Este método está orientado a su uso en componentes de UI
        /// como DataGridView, donde se requiere binding directo.
        /// </summary>
        /// <returns>DataTable con clientes activos.</returns>
        public static DataTable ObtenerClientesTabla()
        {
            var dt = new DataTable();
            var conexion = new ConexionBD();

            using (SqlConnection conn = conexion.AbrirConexion())
            {
                const string query = @"
                    SELECT 
                        c.ClienteID,
                        c.Nombre,
                        c.CUIT_CUIL,
                        c.Domicilio,
                        l.Nombre AS Localidad,
                        c.CondicionIVAID,
                        c.CondicionVentaID
                    FROM Cliente c
                    LEFT JOIN Localidad l ON c.LocalidadID = l.LocalidadID
                    WHERE c.Activo = 1
                    ORDER BY c.Nombre";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        #endregion

        #region === MÉTODOS PRIVADOS ===

        /// <summary>
        /// Vincula las condiciones de IVA a cada cliente para evitar múltiples consultas.
        /// 
        /// Este enfoque mejora la eficiencia al realizar una sola consulta
        /// y reutilizar los datos en memoria.
        /// </summary>
        private static void VincularCondicionesIVA(List<Cliente> clientes, ConexionBD conexion)
        {
            try
            {
                var listaCondIVA = CondicionIVA.ObtenerCondicionesIVA(conexion);

                foreach (var cli in clientes)
                {
                    cli.CondicionIVA = listaCondIVA
                        .FirstOrDefault(c => c.CondicionIVAID == cli.CondicionIVAID);
                }
            }
            catch
            {
                // Se evita que un fallo en la carga de condiciones afecte la carga principal de clientes.
            }
        }

        #endregion
    }
}
