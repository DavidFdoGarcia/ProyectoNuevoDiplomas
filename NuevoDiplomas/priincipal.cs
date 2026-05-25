using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NuevoDiplomas
{
    public partial class priincipal : Form
    {
        public priincipal()
        {
            InitializeComponent();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            config.Show();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            Alumno AL = new Alumno();
            AL.Show();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            Inscripcion ins = new Inscripcion();
            ins.Show();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarDiploma gd = new GenerarDiploma();
            gd.Show();
        }
    }
}
