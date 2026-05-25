using System;
using System.Collections.Generic;
using System.ComponentModel;
using NuevoDiplomas.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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

            string query = @"
                INSERT INTO Alumno
                (Nombre, Apellidos, Correo, Telefono, Activo)
                VALUES
                (@Nombre, @Apellidos, @Correo, @Telefono, @Activo)";

            var parametros = new Dictionary<string, object>
            {
                {"@Nombre", txtNombre.Text.Trim()},
                {"@Apellidos", txtApellidos.Text.Trim()},
                {"@Correo", txtCorreo.Text.Trim()},
                {"@Telefono", txtTelefono.Text.Trim()},
                {"@Activo", chkActivo.Checked}
            };

            Consultas.Ejecutar(query, parametros);

            MessageBox.Show("Alumno guardado correctamente.");
            Limpiar();
            CargarAlumnos();
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
    }
}
