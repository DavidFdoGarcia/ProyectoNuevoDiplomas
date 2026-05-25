namespace NuevoDiplomas
{
    partial class priincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConfig = new Button();
            btnAlumno = new Button();
            btnInscripcion = new Button();
            btnGenerar = new Button();
            SuspendLayout();
            // 
            // btnConfig
            // 
            btnConfig.Location = new Point(403, 226);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(91, 42);
            btnConfig.TabIndex = 0;
            btnConfig.Text = "Configuracion";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnAlumno
            // 
            btnAlumno.Location = new Point(27, 23);
            btnAlumno.Name = "btnAlumno";
            btnAlumno.Size = new Size(75, 23);
            btnAlumno.TabIndex = 1;
            btnAlumno.Text = "Alumno";
            btnAlumno.UseVisualStyleBackColor = true;
            btnAlumno.Click += btnAlumno_Click;
            // 
            // btnInscripcion
            // 
            btnInscripcion.Location = new Point(142, 23);
            btnInscripcion.Name = "btnInscripcion";
            btnInscripcion.Size = new Size(75, 23);
            btnInscripcion.TabIndex = 2;
            btnInscripcion.Text = "Inscripcion";
            btnInscripcion.UseVisualStyleBackColor = true;
            btnInscripcion.Click += btnInscripcion_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(251, 23);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // priincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 310);
            Controls.Add(btnGenerar);
            Controls.Add(btnInscripcion);
            Controls.Add(btnAlumno);
            Controls.Add(btnConfig);
            Name = "priincipal";
            Text = "priincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfig;
        private Button btnAlumno;
        private Button btnInscripcion;
        private Button btnGenerar;
    }
}