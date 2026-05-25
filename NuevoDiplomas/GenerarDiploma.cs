using NuevoDiplomas.Clases;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


namespace NuevoDiplomas
{
    public partial class GenerarDiploma : Form
    {
        public GenerarDiploma()
        {
            InitializeComponent();
        }

        private void GenerarDiploma_Load(object sender, EventArgs e)
        {
            CargarCursos();

            dgvDiplomas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiplomas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiplomas.MultiSelect = false;
            dgvDiplomas.ReadOnly = true;
            dgvDiplomas.AllowUserToAddRows = false;
        }
        private void CargarCursos()
        {
            string query = @"
                SELECT IdCurso, NombreCurso
                FROM Curso
                WHERE Activo = 1
                ORDER BY NombreCurso";

            cmbCurso.DataSource = Consultas.Consultar(query);
            cmbCurso.DisplayMember = "NombreCurso";
            cmbCurso.ValueMember = "IdCurso";
            cmbCurso.SelectedIndex = -1;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarDiplomasPorCurso();
        }
        private void CargarDiplomasPorCurso()
        {
            if (cmbCurso.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un curso.");
                return;
            }

            string query = @"
                SELECT
                    i.IdInscripcion,
                    a.Nombre + ' ' + a.Apellidos AS Alumno,
                    c.NombreCurso,
                    c.FechaCurso,
                    c.Instructor
                FROM Inscripcion i
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                INNER JOIN Curso c ON c.IdCurso = i.IdCurso
                WHERE i.IdCurso = @IdCurso
                ORDER BY a.Apellidos, a.Nombre";

            var parametros = new Dictionary<string, object>
            {
                { "@IdCurso", cmbCurso.SelectedValue }
            };

            dgvDiplomas.DataSource = Consultas.Consultar(query, parametros);

            if (dgvDiplomas.Columns["IdInscripcion"] != null)
                dgvDiplomas.Columns["IdInscripcion"].Visible = false;

            if (dgvDiplomas.Columns["Alumno"] != null)
                dgvDiplomas.Columns["Alumno"].HeaderText = "Alumno";

            if (dgvDiplomas.Columns["NombreCurso"] != null)
                dgvDiplomas.Columns["NombreCurso"].HeaderText = "Curso";

            if (dgvDiplomas.Columns["FechaCurso"] != null)
                dgvDiplomas.Columns["FechaCurso"].HeaderText = "Fecha";

            if (dgvDiplomas.Columns["Instructor"] != null)
                dgvDiplomas.Columns["Instructor"].HeaderText = "Instructor";
        }

        private bool GenerarDiplomaDesdeBD(int idInscripcion, bool mostrarMensajes = true)
        {
            string query = @"
                SELECT TOP 1
                    a.Nombre + ' ' + a.Apellidos AS NombreCompleto,
                    c.NombreCurso,
                    c.FechaCurso,
                    ISNULL(c.Instructor, 'Instructor') AS NombrePonente
                FROM Inscripcion i
                INNER JOIN Alumno a ON a.IdAlumno = i.IdAlumno
                INNER JOIN Curso c ON c.IdCurso = i.IdCurso
                WHERE i.IdInscripcion = @IdInscripcion";

            var parametros = new Dictionary<string, object>
            {
                { "@IdInscripcion", idInscripcion }
            };

            DataTable dt = Consultas.Consultar(query, parametros);

            if (dt.Rows.Count == 0)
            {
                if (mostrarMensajes)
                    MessageBox.Show("No se encontró información.");

                return false;
            }

            DataRow row = dt.Rows[0];

            string nombre = row["NombreCompleto"].ToString();
            string curso = row["NombreCurso"].ToString();
            string nombrePonente = row["NombrePonente"].ToString();

            DateTime fechaCurso = Convert.ToDateTime(row["FechaCurso"]);

            string dia = fechaCurso.Day.ToString();
            string mes = fechaCurso.ToString("MMMM", new CultureInfo("es-MX"));
            string anio = fechaCurso.Year.ToString();

            mes = char.ToUpper(mes[0]) + mes.Substring(1);

            string carpetaDiplomas = Path.Combine(
     Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
     "DiplomasGenerados"
 );

            // Crear carpeta si no existe
            if (!Directory.Exists(carpetaDiplomas))
            {
                Directory.CreateDirectory(carpetaDiplomas);
            }

            string ruta = Path.Combine(
                carpetaDiplomas,
                $"Diploma_{nombre.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            );

            GenerarPDF(nombre, curso, dia, mes, anio, ruta, nombrePonente);

            if (mostrarMensajes)
            {
                MessageBox.Show("Diploma generado correctamente.");

                Process.Start(new ProcessStartInfo(ruta)
                {
                    UseShellExecute = true
                });
            }

            return true;
        }

        private void GenerarPDF(
            string nombre,
            string curso,
            string dia,
            string mes,
            string anio,
            string ruta,
            string nombrePonente)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                string nombrePlantilla;

                switch (curso.Trim())
                {
                    case "CONTPAQi Nóminas®":
                        nombrePlantilla = "NOMINAS.png";
                        break;

                    case "CONTPAQi Contabilidad®":
                        nombrePlantilla = "CONTABILIDAD.png";
                        break;


                    case "CONTPAQi Comercial Premium®":
                        nombrePlantilla = "COMERCIALP.png";
                        break;

                    default:
                        nombrePlantilla = "CONTABILIDAD.png";
                        break;
                }

                string rutaPlantilla = Path.Combine(
                    Application.StartupPath,
                    "PlantillasDiplomas",
                    nombrePlantilla
                
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

                                col.Item().Height(225);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(320);

                                    row.RelativeItem()
                                        .AlignLeft()
                                        .Text(nombre)
                                        .FontSize(27)
                                        .Bold()
                                        .Italic()
                                        .FontColor(Colors.Black);
                                });

                                col.Item().Height(65);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(300);

                                    row.ConstantItem(500)
                                        .AlignLeft()
                                        .Text(curso)
                                        .FontSize(18)
                                        .FontColor(Colors.Black);
                                });

                                col.Item().Height(25);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(330);

                                    row.ConstantItem(400)
                                        .AlignLeft()
                                        .Text($"{dia} de {mes} de {anio}")
                                        .FontSize(18)
                                        .FontColor(Colors.Black);
                                });

                                col.Item().Height(118);

                                col.Item().Row(row =>
                                {
                                    row.ConstantItem(690);

                                    row.ConstantItem(220).Column(firma =>
                                    {
                                        firma.Item()
                                            .AlignCenter()
                                            .Text(nombrePonente)
                                            .FontSize(10)
                                            .FontColor(Colors.Black);

                                        firma.Item()
                                            .AlignCenter()
                                            .Text("Instructor")
                                            .FontSize(12)
                                            .Bold()
                                            .FontColor(Colors.Black);
                                    });
                                });
                            });
                        });
                    });
                })
                .GeneratePdf(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF:\n\n" + ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvDiplomas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un alumno.");
                return;
            }

            int idInscripcion = Convert.ToInt32(
                dgvDiplomas.CurrentRow.Cells["IdInscripcion"].Value
            );

            GenerarDiplomaDesdeBD(idInscripcion, true);
        }

        private void btnGenerarTodos_Click(object sender, EventArgs e)
        {
            if (dgvDiplomas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros cargados.");
                return;
            }

            int generados = 0;

            foreach (DataGridViewRow row in dgvDiplomas.Rows)
            {
                if (row.IsNewRow) continue;

                int idInscripcion = Convert.ToInt32(
                    row.Cells["IdInscripcion"].Value
                );

                if (GenerarDiplomaDesdeBD(idInscripcion, false))
                    generados++;
            }

            MessageBox.Show($"Se generaron {generados} diplomas correctamente.");
        }
    }
}
