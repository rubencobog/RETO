namespace RetaCantabria
{
    partial class CrearUsuario
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblEmail = new Label();
            lblContrasena = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(120, 35);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(120, 121);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(120, 204);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(120, 285);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(70, 15);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 65);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(122, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(120, 148);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(144, 23);
            txtApellido.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 233);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(169, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 314);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(169, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(167, 391);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 23);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 450);
            Controls.Add(btnRegistrar);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblContrasena);
            Controls.Add(lblEmail);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "CrearUsuario";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblContrasena;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegistrar;
    }
}