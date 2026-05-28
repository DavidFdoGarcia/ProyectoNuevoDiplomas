namespace NuevoDiplomas
{
    partial class Configuracion
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
            txtBaseDatos = new TextBox();
            txtServidor = new TextBox();
            btnProbar = new Button();
            btnGuardar = new Button();
            btnSalir = new Button();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Servidor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "Base de Datos";
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Location = new Point(98, 64);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(100, 23);
            txtBaseDatos.TabIndex = 2;
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(92, 26);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(100, 23);
            txtServidor.TabIndex = 3;
            // 
            // btnProbar
            // 
            btnProbar.Location = new Point(234, 22);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(75, 23);
            btnProbar.TabIndex = 4;
            btnProbar.Text = "Probar";
            btnProbar.UseVisualStyleBackColor = true;
            btnProbar.Click += btnProbar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(234, 60);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(234, 99);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(92, 101);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(98, 139);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 8;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 101);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 7;
            label4.Text = "Usuario";
            // 
            // Configuracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 190);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(btnProbar);
            Controls.Add(txtServidor);
            Controls.Add(txtBaseDatos);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Configuracion";
            Text = "Configuracion";
            Load += Configuracion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtBaseDatos;
        private TextBox txtServidor;
        private Button btnProbar;
        private Button btnGuardar;
        private Button btnSalir;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Label label3;
        private Label label4;
    }
}