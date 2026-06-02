namespace NuevoDiplomas
{
    partial class GenerarDiploma
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
            cmbCurso = new ComboBox();
            dgvDiplomas = new DataGridView();
            btnCargar = new Button();
            btnGenerar = new Button();
            btnGenerarTodos = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDiplomas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 30);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Curso";
            // 
            // cmbCurso
            // 
            cmbCurso.FormattingEnabled = true;
            cmbCurso.Location = new Point(88, 22);
            cmbCurso.Name = "cmbCurso";
            cmbCurso.Size = new Size(121, 23);
            cmbCurso.TabIndex = 1;
            // 
            // dgvDiplomas
            // 
            dgvDiplomas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiplomas.Location = new Point(24, 116);
            dgvDiplomas.Name = "dgvDiplomas";
            dgvDiplomas.Size = new Size(565, 321);
            dgvDiplomas.TabIndex = 2;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(292, 30);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(669, 116);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnGenerarTodos
            // 
            btnGenerarTodos.Location = new Point(669, 190);
            btnGenerarTodos.Name = "btnGenerarTodos";
            btnGenerarTodos.Size = new Size(99, 49);
            btnGenerarTodos.TabIndex = 5;
            btnGenerarTodos.Text = "Generar Todos";
            btnGenerarTodos.UseVisualStyleBackColor = true;
            btnGenerarTodos.Click += btnGenerarTodos_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(221, 87);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(275, 23);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 90);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Buscar";
            // 
            // GenerarDiploma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 521);
            Controls.Add(label2);
            Controls.Add(txtBuscar);
            Controls.Add(btnGenerarTodos);
            Controls.Add(btnGenerar);
            Controls.Add(btnCargar);
            Controls.Add(dgvDiplomas);
            Controls.Add(cmbCurso);
            Controls.Add(label1);
            Name = "GenerarDiploma";
            Text = "GenerarDiploma";
            Load += GenerarDiploma_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiplomas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCurso;
        private DataGridView dgvDiplomas;
        private Button btnCargar;
        private Button btnGenerar;
        private Button btnGenerarTodos;
        private TextBox txtBuscar;
        private Label label2;
    }
}