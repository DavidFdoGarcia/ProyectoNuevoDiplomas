using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NuevoDiplomas.Clases
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            string ruta =
                Path.Combine(
                    Application.StartupPath,
                    "config.ini");

            if (!File.Exists(ruta))
            {
                File.WriteAllText(
                    ruta,

@"[database]
server=127.0.0.1,1433
database=NDiplomas
user=ndiplomas_user
password=12345");
            }

            Ini ini = new Ini(ruta);

            string server =
                ini.Leer("database", "server").Trim();

            string database =
                ini.Leer("database", "database").Trim();

            string user =
                ini.Leer("database", "user").Trim();

            string password =
                ini.Leer("database", "password").Trim();

            string cadena =
                $"Data Source={server};" +
                $"Initial Catalog={database};" +
                $"User ID={user};" +
                $"Password={password};" +
                $"TrustServerCertificate=True;";

            SqlConnection cn =
                new SqlConnection(cadena);

            cn.Open();

            return cn;
        }
    }
}