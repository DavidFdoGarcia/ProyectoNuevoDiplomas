using System;
using System.Collections.Generic;
using System.ComponentModel;
using NuevoDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace NuevoDiplomas
{
    public partial class Alumno : Form
    {
        public Alumno()
        {
            InitializeComponent();
        }

        private void Alumno_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            chkActivo.Checked = true;
            CargarAlumnos();
            CargarCursos();
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
        private void CargarAlumnos()
        {
            string query = @"
                SELECT 
                    IdAlumno,
                    Nombre,
                    Apellidos,
                    Correo,
                    Telefono,
                    Activo
                FROM Alumno
                ORDER BY Apellidos, Nombre";

            dgvAlumnos.DataSource = Consultas.Consultar(query);
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Escribe el nombre del alumno.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Escribe los apellidos del alumno.");
                txtApellidos.Focus();
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

            if (ExisteAlumno())
            {
                MessageBox.Show("Ya existe un alumno registrado con ese correo o teléfono.");
                return;
            }

            string query = @"
        INSERT INTO Alumno
        (Nombre, Apellidos, Correo, Telefono, Activo)
        VALUES
        (@Nombre, @Apellidos, @Correo, @Telefono, @Activo);

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parametros = new Dictionary<string, object>
    {
        {"@Nombre", txtNombre.Text.Trim()},
        {"@Apellidos", txtApellidos.Text.Trim()},
        {"@Correo", txtCorreo.Text.Trim()},
        {"@Telefono", txtTelefono.Text.Trim()},
        {"@Activo", chkActivo.Checked}
    };

            int idAlumno = Convert.ToInt32(
                Consultas.EjecutarEscalar(query, parametros)
            );

            if (cmbCurso.SelectedIndex >= 0)
            {
                string queryInscripcion = @"
            IF NOT EXISTS (
                SELECT 1
                FROM Inscripcion
                WHERE IdAlumno = @IdAlumno
                AND IdCurso = @IdCurso
            )
            BEGIN
                INSERT INTO Inscripcion
                (IdAlumno, IdCurso, FechaInscripcion)
                VALUES
                (@IdAlumno, @IdCurso, GETDATE())
            END";

                var parametrosInscripcion = new Dictionary<string, object>
        {
            {"@IdAlumno", idAlumno},
            {"@IdCurso", cmbCurso.SelectedValue}
        };

                Consultas.Ejecutar(queryInscripcion, parametrosInscripcion);

                MessageBox.Show("Alumno guardado e inscrito correctamente.");
            }
            else
            {
                MessageBox.Show("Alumno guardado correctamente sin inscripción.");
            }

            Limpiar();
            CargarAlumnos();
        }
        private void CargarAlumnos(string buscar = "")
        {
            string query = @"
        SELECT
            IdAlumno,
            Nombre,
            Apellidos,
            Correo,
            Telefono,
            Activo
        FROM Alumno
        WHERE
            Nombre LIKE @Buscar
            OR Apellidos LIKE @Buscar
            OR Correo LIKE @Buscar
            OR Telefono LIKE @Buscar
        ORDER BY Apellidos, Nombre";

            var parametros = new Dictionary<string, object>
    {
        { "@Buscar", "%" + buscar + "%" }
    };

            dgvAlumnos.DataSource = Consultas.Consultar(query, parametros);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecciona un alumno para modificar.");
                return;
            }

            if (!ValidarCampos()) return;

            string query = @"
                UPDATE Alumno SET
                    Nombre = @Nombre,
                    Apellidos = @Apellidos,
                    Correo = @Correo,
                    Telefono = @Telefono,
                    Activo = @Activo
                WHERE IdAlumno = @IdAlumno";

            var parametros = new Dictionary<string, object>
            {
                {"@IdAlumno", Convert.ToInt32(txtID.Text)},
                {"@Nombre", txtNombre.Text.Trim()},
                {"@Apellidos", txtApellidos.Text.Trim()},
                {"@Correo", txtCorreo.Text.Trim()},
                {"@Telefono", txtTelefono.Text.Trim()},
                {"@Activo", chkActivo.Checked}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Alumno modificado correctamente.");
            Limpiar();
            CargarAlumnos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecciona un alumno para eliminar.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas desactivar este alumno?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No) return;

            string query = @"
                UPDATE Alumno 
                SET Activo = 0
                WHERE IdAlumno = @IdAlumno";

            var parametros = new Dictionary<string, object>
            {
                {"@IdAlumno", Convert.ToInt32(txtID.Text)}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Alumno desactivado correctamente.");
            Limpiar();
            CargarAlumnos();
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];

            txtID.Text = fila.Cells["IdAlumno"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            chkActivo.Checked = Convert.ToBoolean(fila.Cells["Activo"].Value);
        }
        private bool ExisteAlumno()
        {
            string query = @"
        SELECT COUNT(*)
        FROM Alumno
        WHERE Correo = @Correo
        OR Telefono = @Telefono";

            var parametros = new Dictionary<string, object>
    {
        {"@Correo", txtCorreo.Text.Trim()},
        {"@Telefono", txtTelefono.Text.Trim()}
    };

            int total = Convert.ToInt32(
                Consultas.EjecutarEscalar(query, parametros)
            );

            return total > 0;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarAlumnos(txtBuscar.Text.Trim());
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlumnos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.");
                    return;
                }

                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "ReportesDiplomas");

                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(
                    carpeta,
                    $"Alumnos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                using (XLWorkbook libro = new XLWorkbook())
                {
                    var hoja = libro.Worksheets.Add("Alumnos");

                    for (int i = 0; i < dgvAlumnos.Columns.Count; i++)
                    {
                        hoja.Cell(1, i + 1).Value =
                            dgvAlumnos.Columns[i].HeaderText;
                    }

                    for (int i = 0; i < dgvAlumnos.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvAlumnos.Columns.Count; j++)
                        {
                            hoja.Cell(i + 2, j + 1).Value =
                                dgvAlumnos.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    hoja.Columns().AdjustToContents();

                    libro.SaveAs(ruta);
                }

                MessageBox.Show("Archivo exportado correctamente.");

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(ruta)
                    {
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
