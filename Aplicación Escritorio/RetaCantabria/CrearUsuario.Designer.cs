using RetaCantabria.Properties;

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
            pictureUsuario = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureUsuario).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(139, 196);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(139, 272);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(139, 347);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(141, 423);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(83, 20);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Location = new Point(141, 220);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(193, 27);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Location = new Point(141, 296);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(193, 27);
            txtApellido.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(141, 371);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 27);
            txtEmail.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(143, 447);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(193, 27);
            txtPassword.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(74, 82, 90);
            btnRegistrar.FlatAppearance.BorderColor = Color.Crimson;
            btnRegistrar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnRegistrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.ForeColor = SystemColors.ButtonHighlight;
            btnRegistrar.Location = new Point(180, 521);
            btnRegistrar.Margin = new Padding(3, 4, 3, 4);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(114, 31);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // pictureUsuario
            // 
            pictureUsuario.Image = Resources.crear_usuario;
            pictureUsuario.Location = new Point(143, 26);
            pictureUsuario.Name = "pictureUsuario";
            pictureUsuario.Size = new Size(191, 152);
            pictureUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            pictureUsuario.TabIndex = 9;
            pictureUsuario.TabStop = false;
            // 
            // CrearUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 600);
            Controls.Add(pictureUsuario);
            Controls.Add(btnRegistrar);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblContrasena);
            Controls.Add(lblEmail);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CrearUsuario";
            Text = "Registro";
            Load += CrearUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureUsuario).EndInit();
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
        private PictureBox pictureUsuario;
    }
}