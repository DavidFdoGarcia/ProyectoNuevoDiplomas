using NuevoDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NuevoDiplomas
{
    public partial class Inscripcion : Form
    {
        public Inscripcion()
        {
            InitializeComponent();
        }

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            dtpFechaInscripcion.Value = DateTime.Now;

            CargarCursos();
            CargarAlumnos();
            CargarInscripciones();
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
                    Nombre + ' ' + Apellidos AS NombreCompleto
                FROM Alumno
                WHERE Activo = 1
                ORDER BY Apellidos, Nombre";

            cmbAlumno.DataSource = Consultas.Consultar(query);
            cmbAlumno.DisplayMember = "NombreCompleto";
            cmbAlumno.ValueMember = "IdAlumno";
            cmbAlumno.SelectedIndex = -1;
        }

        private void CargarInscripciones()
        {
            string query = @"
                SELECT 
                    i.IdInscripcion,
                    c.NombreCurso,
                    a.Nombre + ' ' + a.Apellidos AS Alumno,
                    i.FechaInscripcion,
                    i.IdCurso,
                    i.IdAlumno
                FROM Inscripcion i
                INNER JOIN Curso c ON i.IdCurso = c.IdCurso
                INNER JOIN Alumno a ON i.IdAlumno = a.IdAlumno
                ORDER BY i.FechaInscripcion DESC";

            dgvInscripciones.DataSource = Consultas.Consultar(query);

            if (dgvInscripciones.Columns["IdCurso"] != null)
                dgvInscripciones.Columns["IdCurso"].Visible = false;

            if (dgvInscripciones.Columns["IdAlumno"] != null)
                dgvInscripciones.Columns["IdAlumno"].Visible = false;
        }

        private void Limpiar()
        {
            txtID.Clear();
            cmbCurso.SelectedIndex = -1;
            cmbAlumno.SelectedIndex = -1;
            dtpFechaInscripcion.Value = DateTime.Now;
        }

        private bool ValidarCampos()
        {
            if (cmbCurso.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un curso.");
                return false;
            }

            if (cmbAlumno.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un alumno.");
                return false;
            }

            return true;
        }

        private bool YaExisteInscripcion()
        {
            string query = @"
                SELECT COUNT(*)
                FROM Inscripcion
                WHERE IdCurso = @IdCurso
                AND IdAlumno = @IdAlumno";

            var parametros = new Dictionary<string, object>
            {
                {"@IdCurso", cmbCurso.SelectedValue},
                {"@IdAlumno", cmbAlumno.SelectedValue}
            };

            int total = Convert.ToInt32(Consultas.EjecutarEscalar(query, parametros));

            return total > 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (YaExisteInscripcion())
            {
                MessageBox.Show("Este alumno ya está inscrito en este curso.");
                return;
            }

            string query = @"
                INSERT INTO Inscripcion
                (IdCurso, IdAlumno, FechaInscripcion)
                VALUES
                (@IdCurso, @IdAlumno, @FechaInscripcion)";

            var parametros = new Dictionary<string, object>
            {
                {"@IdCurso", cmbCurso.SelectedValue},
                {"@IdAlumno", cmbAlumno.SelectedValue},
                {"@FechaInscripcion", dtpFechaInscripcion.Value}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Inscripción guardada correctamente.");
            Limpiar();
            CargarInscripciones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecciona una inscripción.");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar esta inscripción?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.No) return;

            string query = @"
                DELETE FROM Inscripcion
                WHERE IdInscripcion = @IdInscripcion";

            var parametros = new Dictionary<string, object>
            {
                {"@IdInscripcion", Convert.ToInt32(txtID.Text)}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Inscripción eliminada correctamente.");
            Limpiar();
            CargarInscripciones();
        }

        private void dgvInscripciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvInscripciones.Rows[e.RowIndex];

            txtID.Text = fila.Cells["IdInscripcion"].Value.ToString();
            cmbCurso.SelectedValue = Convert.ToInt32(fila.Cells["IdCurso"].Value);
            cmbAlumno.SelectedValue = Convert.ToInt32(fila.Cells["IdAlumno"].Value);
            dtpFechaInscripcion.Value = Convert.ToDateTime(fila.Cells["FechaInscripcion"].Value);
        }

        private void btnInscribirTodos_Click(object sender, EventArgs e)
        {
            if (cmbCurso.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un curso.");
                return;
            }

            string query = @"
        INSERT INTO Inscripcion (IdAlumno, IdCurso, FechaInscripcion)
        SELECT 
            a.IdAlumno,
            @IdCurso,
            GETDATE()
        FROM Alumno a
        WHERE a.Activo = 1
        AND NOT EXISTS (
            SELECT 1
            FROM Inscripcion i
            WHERE i.IdAlumno = a.IdAlumno
            AND i.IdCurso = @IdCurso
        )";

            var parametros = new Dictionary<string, object>
    {
        { "@IdCurso", cmbCurso.SelectedValue }
    };

            int insertados = Consultas.Ejecutar(query, parametros);

            MessageBox.Show($"Se inscribieron {insertados} alumnos al curso.");

            CargarInscripciones();
        }
    }
}
