using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Clase encargada de gestionar las operaciones de acceso a datos
    /// relacionadas con la entidad Cliente.
    /// 
    /// Implementa operaciones CRUD (Create, Read, Update, Delete lógico)
    /// y consultas auxiliares para UI.
    /// </summary>
    public class ClienteDatos
    {
        private readonly ConexionBD conexion = new ConexionBD();
        private readonly LocalidadDatos localidadDatos = new LocalidadDatos();

        // =============================================================
        // INSERTAR CLIENTE
        // =============================================================
        /// <summary>
        /// Inserta un nuevo cliente en la base de datos.
        /// Si la localidad no existe, la crea automáticamente.
        /// </summary>
        /// <returns>True si la operación fue exitosa, caso contrario False.</returns>
        public bool AgregarCliente(
            string nombre,
            string cuit_cuil,
            string domicilio,
            string localidadNombre,
            int condicionIVAID,
            int condicionVentaID)
        {
            try
            {
                int localidadID = localidadDatos.ObtenerOAgregarLocalidad(localidadNombre);

                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Cliente 
                      (Nombre, CUIT_CUIL, Domicilio, LocalidadID, CondicionIVAID, CondicionVentaID, Activo)
                      VALUES
                      (@Nombre, @CUIT, @Domicilio, @LocalidadID, @CondicionIVAID, @CondicionVentaID, 1)",
                    conn))
                {
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@CUIT", SqlDbType.VarChar, 50).Value = cuit_cuil;
                    cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 200).Value = domicilio;
                    cmd.Parameters.Add("@LocalidadID", SqlDbType.Int).Value = localidadID;
                    cmd.Parameters.Add("@CondicionIVAID", SqlDbType.Int).Value = condicionIVAID;
                    cmd.Parameters.Add("@CondicionVentaID", SqlDbType.Int).Value = condicionVentaID;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                // ⚠️ En producción esto debería loguearse (archivo/log system)
                throw new Exception("Error al agregar el cliente: " + ex.Message, ex);
            }
        }

        // =============================================================
        // ACTUALIZAR CLIENTE
        // =============================================================
        /// <summary>
        /// Actualiza los datos de un cliente existente.
        /// Solo se permite modificar clientes activos.
        /// </summary>
        public bool ActualizarCliente(
            int clienteID,
            string nombre,
            string cuit_cuil,
            string domicilio,
            string localidadNombre,
            int condicionIVAID,
            int condicionVentaID)
        {
            try
            {
                int localidadID = localidadDatos.ObtenerOAgregarLocalidad(localidadNombre);

                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Cliente SET 
                        Nombre = @Nombre,
                        CUIT_CUIL = @CUIT,
                        Domicilio = @Domicilio,
                        LocalidadID = @LocalidadID,
                        CondicionIVAID = @CondicionIVAID,
                        CondicionVentaID = @CondicionVentaID
                      WHERE ClienteID = @ClienteID AND Activo = 1",
                    conn))
                {
                    cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@CUIT", SqlDbType.VarChar, 50).Value = cuit_cuil;
                    cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar, 200).Value = domicilio;
                    cmd.Parameters.Add("@LocalidadID", SqlDbType.Int).Value = localidadID;
                    cmd.Parameters.Add("@CondicionIVAID", SqlDbType.Int).Value = condicionIVAID;
                    cmd.Parameters.Add("@CondicionVentaID", SqlDbType.Int).Value = condicionVentaID;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente: " + ex.Message, ex);
            }
        }

        // =============================================================
        // ELIMINAR CLIENTE (LÓGICO)
        // =============================================================
        /// <summary>
        /// Realiza una eliminación lógica del cliente (Activo = 0).
        /// No elimina físicamente el registro para mantener integridad histórica.
        /// </summary>
        public bool EliminarCliente(int clienteID)
        {
            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Cliente SET Activo = 0 WHERE ClienteID = @ID",
                    conn))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = clienteID;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message, ex);
            }
        }

        // =============================================================
        // OBTENER CLIENTES ACTIVOS
        // =============================================================
        /// <summary>
        /// Devuelve todos los clientes activos en formato DataTable.
        /// Ideal para vinculación directa con DataGridView.
        /// </summary>
        public DataTable ObtenerClientes()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                        C.ClienteID,
                        C.Nombre,
                        C.CUIT_CUIL,
                        C.Domicilio,
                        L.Nombre AS Localidad,
                        C.CondicionIVAID,
                        C.CondicionVentaID
                      FROM Cliente C
                      LEFT JOIN Localidad L ON C.LocalidadID = L.LocalidadID
                      WHERE C.Activo = 1
                      ORDER BY C.Nombre",
                    conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message, ex);
            }

            return tabla;
        }

        // =============================================================
        // OBTENER CLIENTE POR ID
        // =============================================================
        /// <summary>
        /// Devuelve un cliente específico por ID.
        /// </summary>
        public DataRow ObtenerClientePorID(int clienteID)
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT * FROM Cliente 
                      WHERE ClienteID = @ID AND Activo = 1",
                    conn))
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = clienteID;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }

                return tabla.Rows.Count > 0 ? tabla.Rows[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente por ID: " + ex.Message, ex);
            }
        }

        // =============================================================
        // OBTENER LOCALIDADES
        // =============================================================
        /// <summary>
        /// Devuelve una lista de nombres de localidades.
        /// Utilizado principalmente para poblar ComboBox.
        /// </summary>
        public List<string> ObtenerLocalidades()
        {
            List<string> localidades = new List<string>();

            try
            {
                DataTable dt = localidadDatos.ObtenerLocalidades();

                foreach (DataRow row in dt.Rows)
                {
                    localidades.Add(row["Nombre"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener localidades: " + ex.Message, ex);
            }

            return localidades;
        }

        // =============================================================
        // MÉTODOS COMPATIBLES (WRAPPERS)
        // =============================================================
        /// <summary>
        /// Método alias para mantener compatibilidad con otras capas.
        /// </summary>
        public bool ModificarCliente(
            int clienteID,
            string nombre,
            string cuit_cuil,
            string domicilio,
            string localidadNombre,
            int condicionIVAID,
            int condicionVentaID)
        {
            return ActualizarCliente(clienteID, nombre, cuit_cuil, domicilio, localidadNombre, condicionIVAID, condicionVentaID);
        }

        /// <summary>
        /// Método alias para mantener compatibilidad con UI.
        /// </summary>
        public DataTable ObtenerClientesTabla()
        {
            return ObtenerClientes();
        }
    }
}