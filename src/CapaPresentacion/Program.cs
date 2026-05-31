using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());


            {
                ConexionBD conexionBD = new ConexionBD();

                using (SqlConnection conexion = conexionBD.AbrirConexion())
                {
                    // Aquí puedes usar la conexión para realizar operaciones en la base de datos
                    Console.WriteLine("Conexión exitosa!");
                } // La conexión se cerrará automáticamente al salir del bloque 'using'
            }
        }
    }
}
