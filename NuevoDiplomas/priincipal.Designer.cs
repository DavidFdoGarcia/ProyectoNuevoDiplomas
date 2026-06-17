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
            btnGenerarPonencia = new Button();
            SuspendLayout();
            // 
            // btnConfig
            // 
            btnConfig.Location = new Point(461, 301);
            btnConfig.Margin = new Padding(3, 4, 3, 4);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(104, 56);
            btnConfig.TabIndex = 0;
            btnConfig.Text = "Configuracion";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnAlumno
            // 
            btnAlumno.Location = new Point(31, 31);
            btnAlumno.Margin = new Padding(3, 4, 3, 4);
            btnAlumno.Name = "btnAlumno";
            btnAlumno.Size = new Size(86, 31);
            btnAlumno.TabIndex = 1;
            btnAlumno.Text = "Alumno";
            btnAlumno.UseVisualStyleBackColor = true;
            btnAlumno.Click += btnAlumno_Click;
            // 
            // btnInscripcion
            // 
            btnInscripcion.Location = new Point(162, 31);
            btnInscripcion.Margin = new Padding(3, 4, 3, 4);
            btnInscripcion.Name = "btnInscripcion";
            btnInscripcion.Size = new Size(86, 31);
            btnInscripcion.TabIndex = 2;
            btnInscripcion.Text = "Inscripcion";
            btnInscripcion.UseVisualStyleBackColor = true;
            btnInscripcion.Click += btnInscripcion_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(328, 44);
            btnGenerar.Margin = new Padding(3, 4, 3, 4);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(86, 31);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnGenerarPonencia
            // 
            btnGenerarPonencia.Location = new Point(54, 127);
            btnGenerarPonencia.Name = "btnGenerarPonencia";
            btnGenerarPonencia.Size = new Size(93, 103);
            btnGenerarPonencia.TabIndex = 4;
            btnGenerarPonencia.Text = "Generar Ponencia";
            btnGenerarPonencia.UseVisualStyleBackColor = true;
            btnGenerarPonencia.Click += btnGenerarPonencia_Click;
            // 
            // priincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 413);
            Controls.Add(btnGenerarPonencia);
            Controls.Add(btnGenerar);
            Controls.Add(btnInscripcion);
            Controls.Add(btnAlumno);
            Controls.Add(btnConfig);
            Margin = new Padding(3, 4, 3, 4);
            Name = "priincipal";
            Text = "priincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfig;
        private Button btnAlumno;
        private Button btnInscripcion;
        private Button btnGenerar;
        private Button btnGenerarPonencia;
    }
}