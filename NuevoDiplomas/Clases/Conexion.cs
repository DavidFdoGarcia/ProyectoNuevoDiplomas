using System;
using System.IO;
using System.Windows.Forms;

namespace NuevoDiplomas.Clases
{
    internal class Conexion
    {
        public static Microsoft.Data.SqlClient.SqlConnection Conectar()
        {
            string ruta = Path.Combine(Application.StartupPath, "config.ini");

            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta,
@"[database]
server=.\SQLEXPRESS
database=NDiplomas");
            }

            Ini ini = new Ini(ruta);

            string server = ini.Leer("database", "server").Trim();
            string database = ini.Leer("database", "database").Trim();

            string cadena =
                $"Data Source={server};" +
                $"Initial Catalog={database};" +
                $"Integrated Security=True;" +
                $"TrustServerCertificate=True;";

            var cn = new Microsoft.Data.SqlClient.SqlConnection(cadena);

            cn.Open();

            return cn;
        }
    }
}