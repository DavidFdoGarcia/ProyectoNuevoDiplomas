namespace NuevoDiplomas
{
    partial class Alumno
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
            label4 = new Label();
            label5 = new Label();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            txtID = new TextBox();
            chkActivo = new CheckBox();
            dgvAlumnos = new DataGridView();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtBuscar = new TextBox();
            btnExportarExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 27);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 65);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 32);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Correo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(518, 27);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 65);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 4;
            label5.Text = "Apellidos";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(587, 24);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 5;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(308, 29);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(183, 23);
            txtCorreo.TabIndex = 6;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(308, 65);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(194, 23);
            txtApellidos.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(86, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(122, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtID
            // 
            txtID.Location = new Point(68, 19);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 9;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(560, 79);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 10;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Location = new Point(2, 143);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.Size = new Size(773, 353);
            dgvAlumnos.TabIndex = 11;
            dgvAlumnos.CellClick += dgvAlumnos_CellClick;
            dgvAlumnos.CellContentClick += dgvAlumnos_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(308, 502);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(214, 502);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(119, 502);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(18, 502);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 15;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(68, 114);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(434, 23);
            txtBuscar.TabIndex = 16;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Location = new Point(427, 502);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(75, 23);
            btnExportarExcel.TabIndex = 17;
            btnExportarExcel.Text = "Exportar";
            btnExportarExcel.UseCompatibleTextRendering = true;
            btnExportarExcel.UseVisualStyleBackColor = true;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // Alumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 569);
            Controls.Add(btnExportarExcel);
            Controls.Add(txtBuscar);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvAlumnos);
            Controls.Add(chkActivo);
            Controls.Add(txtID);
            Controls.Add(txtNombre);
            Controls.Add(txtApellidos);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Alumno";
            Text = "Alumno";
            Load += Alumno_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private TextBox txtID;
        private CheckBox chkActivo;
        private DataGridView dgvAlumnos;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtBuscar;
        private Button btnExportarExcel;
    }
}