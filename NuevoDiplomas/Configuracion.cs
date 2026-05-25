using NuevoDiplomas.Clases;
using System;
using System.IO;
using System.Windows.Forms;

namespace NuevoDiplomas
{
    public partial class Configuracion : Form
    {
        Ini ini = new Ini(Path.Combine(Application.StartupPath, "config.ini"));

        public Configuracion()
        {
            InitializeComponent();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena =
                    $"Data Source={txtServidor.Text.Trim()};" +
                    $"Initial Catalog={txtBaseDatos.Text.Trim()};" +
                    $"Integrated Security=True;" +
                    $"TrustServerCertificate=True;";

                using (System.Data.SqlClient.SqlConnection cn =
                       new System.Data.SqlClient.SqlConnection(cadena))
                {
                    cn.Open();

                    MessageBox.Show(
                        "Conexión exitosa.",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error de conexión:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ini.Escribir("database", "server", txtServidor.Text.Trim());
            ini.Escribir("database", "database", txtBaseDatos.Text.Trim());

            MessageBox.Show(
                "Configuración guardada correctamente.",
                "Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            txtServidor.Text = ini.Leer("database", "server");
            txtBaseDatos.Text = ini.Leer("database", "database");
        }
    }
}