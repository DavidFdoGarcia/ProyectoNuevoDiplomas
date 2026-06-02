namespace NuevoDiplomas
{
    partial class Inscripcion
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            cmbCurso = new ComboBox();
            cmbAlumno = new ComboBox();
            dtpFechaInscripcion = new DateTimePicker();
            dgvInscripciones = new DataGridView();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnInscribirTodos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 54);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Curso";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 90);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Alumno";
            // 
            // txtID
            // 
            txtID.Location = new Point(48, 6);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 3;
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(48, 51);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(121, 23);
            cmbCurso.TabIndex = 4;
            // 
            // cmbAlumno
            // 
            cmbAlumno.FormattingEnabled = true;
            cmbAlumno.Location = new Point(57, 87);
            cmbAlumno.Name = "cmbAlumno";
            cmbAlumno.Size = new Size(121, 23);
            cmbAlumno.TabIndex = 5;
            // 
            // dtpFechaInscripcion
            // 
            dtpFechaInscripcion.Location = new Point(228, 24);
            dtpFechaInscripcion.Name = "dtpFechaInscripcion";
            dtpFechaInscripcion.Size = new Size(200, 23);
            dtpFechaInscripcion.TabIndex = 6;
            // 
            // dgvInscripciones
            // 
            dgvInscripciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInscripciones.Location = new Point(8, 129);
            dgvInscripciones.Name = "dgvInscripciones";
            dgvInscripciones.Size = new Size(929, 379);
            dgvInscripciones.TabIndex = 7;
            dgvInscripciones.CellClick += dgvInscripciones_CellClick;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(8, 541);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(108, 53);
            btnNuevo.TabIndex = 8;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(170, 541);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 53);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(315, 541);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 53);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnInscribirTodos
            // 
            btnInscribirTodos.Location = new Point(500, 556);
            btnInscribirTodos.Name = "btnInscribirTodos";
            btnInscribirTodos.Size = new Size(93, 47);
            btnInscribirTodos.TabIndex = 11;
            btnInscribirTodos.Text = "Inscribir todos";
            btnInscribirTodos.UseVisualStyleBackColor = true;
            btnInscribirTodos.Click += btnInscribirTodos_Click;
            // 
            // Inscripcion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 647);
            Controls.Add(btnInscribirTodos);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvInscripciones);
            Controls.Add(dtpFechaInscripcion);
            Controls.Add(cmbAlumno);
            Controls.Add(cmbCurso);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Inscripcion";
            Text = "Inscripcion";
            Load += Inscripcion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInscripciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtID;
        private ComboBox cmbCurso;
        private ComboBox cmbAlumno;
        private DateTimePicker dtpFechaInscripcion;
        private DataGridView dgvInscripciones;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnInscribirTodos;
    }
}