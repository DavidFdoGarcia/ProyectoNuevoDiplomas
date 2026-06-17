using NuevoDiplomas.Clases;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NuevoDiplomas
{
    public partial class FrmPonencia : Form
    {
        public FrmPonencia()
        {
            InitializeComponent();
        }

        private void FrmPonencia_Load(object sender, EventArgs e)
        {
            txtIdPonencia.Enabled = false;
            chkActivo.Checked = true;
            dtpFecha.Value = DateTime.Now;

            CargarPonencias();
        }
        private void CargarPonencias(string buscar = "")
        {
            string query = @"
                SELECT
                    IdPonencia,
                    NombrePonente,
                    Tema,
                    Fecha,
                    Duracion,
                    Activo
                FROM Ponencia
                WHERE
                    NombrePonente LIKE @Buscar
                    OR Tema LIKE @Buscar
                    OR Duracion LIKE @Buscar
                ORDER BY Fecha DESC";

            var parametros = new Dictionary<string, object>
            {
                {"@Buscar", "%" + buscar + "%"}
            };

            dgvPonencias.DataSource = Consultas.Consultar(query, parametros);
        }

        private void Limpiar()
        {
            txtIdPonencia.Clear();
            txtNombrePonente.Clear();
            txtTema.Clear();
            txtDuracion.Clear();
            dtpFecha.Value = DateTime.Now;
            chkActivo.Checked = true;
            txtNombrePonente.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombrePonente.Text))
            {
                MessageBox.Show("Escribe el nombre del ponente.");
                txtNombrePonente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTema.Text))
            {
                MessageBox.Show("Escribe el tema.");
                txtTema.Focus();
                return false;
            }

            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string query = @"
                INSERT INTO Ponencia
                (NombrePonente, Tema, Fecha, Duracion, Activo)
                VALUES
                (@NombrePonente, @Tema, @Fecha, @Duracion, @Activo)";

            var parametros = new Dictionary<string, object>
            {
                {"@NombrePonente", txtNombrePonente.Text.Trim()},
                {"@Tema", txtTema.Text.Trim()},
                {"@Fecha", dtpFecha.Value.Date},
                {"@Duracion", txtDuracion.Text.Trim()},
                {"@Activo", chkActivo.Checked}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Ponencia guardada correctamente.");
            Limpiar();
            CargarPonencias();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPonencia.Text))
            {
                MessageBox.Show("Selecciona una ponencia.");
                return;
            }

            if (!ValidarCampos()) return;

            string query = @"
                UPDATE Ponencia SET
                    NombrePonente = @NombrePonente,
                    Tema = @Tema,
                    Fecha = @Fecha,
                    Duracion = @Duracion,
                    Activo = @Activo
                WHERE IdPonencia = @IdPonencia";

            var parametros = new Dictionary<string, object>
            {
                {"@IdPonencia", Convert.ToInt32(txtIdPonencia.Text)},
                {"@NombrePonente", txtNombrePonente.Text.Trim()},
                {"@Tema", txtTema.Text.Trim()},
                {"@Fecha", dtpFecha.Value.Date},
                {"@Duracion", txtDuracion.Text.Trim()},
                {"@Activo", chkActivo.Checked}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Ponencia modificada correctamente.");
            Limpiar();
            CargarPonencias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPonencia.Text))
            {
                MessageBox.Show("Selecciona una ponencia.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas desactivar esta ponencia?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No) return;

            string query = @"
                UPDATE Ponencia
                SET Activo = 0
                WHERE IdPonencia = @IdPonencia";

            var parametros = new Dictionary<string, object>
            {
                {"@IdPonencia", Convert.ToInt32(txtIdPonencia.Text)}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Ponencia desactivada correctamente.");
            Limpiar();
            CargarPonencias();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarPonencias(txtBuscar.Text.Trim());
        }

        private void dgvPonencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvPonencias.Rows[e.RowIndex];

            txtIdPonencia.Text = fila.Cells["IdPonencia"].Value.ToString();
            txtNombrePonente.Text = fila.Cells["NombrePonente"].Value.ToString();
            txtTema.Text = fila.Cells["Tema"].Value.ToString();
            dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
            txtDuracion.Text = fila.Cells["Duracion"].Value.ToString();
            chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIdPonencia.Text))
            {
                MessageBox.Show("Selecciona una ponencia.");
                return;
            }

            int idPonencia = Convert.ToInt32(txtIdPonencia.Text);

            GenerarReconocimientoDesdeBD(idPonencia);
        }
        private void GenerarReconocimientoDesdeBD(int idPonencia)
        {
            string query = @"
        SELECT
            NombrePonente,
            Tema,
            Fecha,
            Duracion
        FROM Ponencia
        WHERE IdPonencia = @IdPonencia";

            var parametros = new Dictionary<string, object>
    {
        {"@IdPonencia", idPonencia}
    };

            DataTable dt = Consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la ponencia.");
                return;
            }

            DataRow row = dt.Rows[0];

            string nombrePonente = row["NombrePonente"].ToString();
            string tema = row["Tema"].ToString();
            string duracion = row["Duracion"].ToString();

            DateTime fecha = Convert.ToDateTime(row["Fecha"]);

            string fechaTexto = fecha.ToString(
                "dd 'de' MMMM 'de' yyyy",
                new CultureInfo("es-MX"));

            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "ReconocimientosPonentes");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(
                carpeta,
                $"Reconocimiento_{nombrePonente.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            GenerarPDFReconocimiento(
                nombrePonente,
                tema,
                duracion,
                fechaTexto,
                ruta);

            MessageBox.Show("Reconocimiento generado correctamente.");

            Process.Start(new ProcessStartInfo(ruta)
            {
                UseShellExecute = true
            });
        }

        private void GenerarPDFReconocimiento(
            string nombrePonente,
            string tema,
            string duracion,
            string fechaTexto,
            string ruta)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                FontManager.RegisterFont(
    File.OpenRead(
        Path.Combine(
            Application.StartupPath,
            "Fuentes",
            "Andasia.otf")));

                string rutaPlantilla = Path.Combine(
                    Application.StartupPath,
                    "PlantillasDiplomas",
                    "ReconocimientoPonente.png"
                );

                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró la plantilla:\n" + rutaPlantilla);
                    return;
                }

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(0);

                        page.Content().Layers(layers =>
                        {
                            layers.PrimaryLayer()
                                .Image(rutaPlantilla)
                                .FitArea();

                            layers.Layer().Column(col =>
                            {
                                col.Spacing(0);

                                // Nombre ponente
                                col.Item().Height(240);

                                col.Item().AlignCenter()
                                    .Text(nombrePonente)
                                    .FontFamily("Andasia")
                                    .FontSize(37)
                                    /*.Bold()
                                    .Italic()
                                    .FontColor(Colors.Black)*/;

                                // Tema
                                col.Item().Height(35);

                                col.Item().AlignCenter()
                                    .Text(tema)
                                    .FontSize(20)
                                    .Bold()
                                    .FontColor(Colors.Black);

                                // Duración y fecha en el mismo renglón
                                col.Item().PaddingTop(10).PaddingLeft(220).PaddingRight(220).Row(row =>
                                {
                                    row.ConstantItem(250)
      .AlignLeft()
      .Text("Con una duración de " + duracion + ", el día: ")
      .FontSize(16);

                                    row.RelativeItem()
                                        .AlignRight()
                                        .Text(fechaTexto)
                                        .FontSize(16)
                                        .FontColor(Colors.Black);
                                });
                            });
                        });
                    });
                })
                .GeneratePdf(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reconocimiento:\n\n" + ex.Message);
            }
        }
    }
}
