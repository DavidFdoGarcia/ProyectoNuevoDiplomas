namespace NuevoDiplomas
{
    partial class FrmPonencia
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
            txtIdPonencia = new TextBox();
            txtNombrePonente = new TextBox();
            label2 = new Label();
            txtTema = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dtpFecha = new DateTimePicker();
            label5 = new Label();
            txtDuracion = new TextBox();
            chkActivo = new CheckBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            label6 = new Label();
            txtBuscar = new TextBox();
            dgvPonencias = new DataGridView();
            btnGenerar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPonencias).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 35);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // txtIdPonencia
            // 
            txtIdPonencia.Location = new Point(130, 35);
            txtIdPonencia.Name = "txtIdPonencia";
            txtIdPonencia.Size = new Size(89, 27);
            txtIdPonencia.TabIndex = 1;
            // 
            // txtNombrePonente
            // 
            txtNombrePonente.Location = new Point(130, 99);
            txtNombrePonente.Name = "txtNombrePonente";
            txtNombrePonente.Size = new Size(89, 27);
            txtNombrePonente.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 99);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 2;
            label2.Text = "Ponente";
            // 
            // txtTema
            // 
            txtTema.Location = new Point(130, 168);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(89, 27);
            txtTema.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 168);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 4;
            label3.Text = "Tema";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(255, 54);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 6;
            label4.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(343, 54);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(262, 125);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 4;
            label5.Text = "Duración";
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(345, 125);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(89, 27);
            txtDuracion.TabIndex = 5;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(391, 198);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 8;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(42, 729);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(188, 729);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(341, 729);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(487, 730);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 247);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 4;
            label6.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(130, 247);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(377, 27);
            txtBuscar.TabIndex = 5;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvPonencias
            // 
            dgvPonencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPonencias.Location = new Point(31, 320);
            dgvPonencias.Name = "dgvPonencias";
            dgvPonencias.RowHeadersWidth = 51;
            dgvPonencias.Size = new Size(816, 376);
            dgvPonencias.TabIndex = 10;
            dgvPonencias.CellClick += dgvPonencias_CellClick;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(721, 730);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(106, 29);
            btnGenerar.TabIndex = 9;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // FrmPonencia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1439, 794);
            Controls.Add(dgvPonencias);
            Controls.Add(btnGenerar);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(chkActivo);
            Controls.Add(dtpFecha);
            Controls.Add(label4);
            Controls.Add(txtDuracion);
            Controls.Add(txtBuscar);
            Controls.Add(txtTema);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtNombrePonente);
            Controls.Add(label2);
            Controls.Add(txtIdPonencia);
            Controls.Add(label1);
            Name = "FrmPonencia";
            Text = "FrmPonencia";
            Load += FrmPonencia_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPonencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdPonencia;
        private TextBox txtNombrePonente;
        private Label label2;
        private TextBox txtTema;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpFecha;
        private Label label5;
        private TextBox txtDuracion;
        private CheckBox chkActivo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label label6;
        private TextBox txtBuscar;
        private DataGridView dgvPonencias;
        private Button btnGenerar;
    }
}