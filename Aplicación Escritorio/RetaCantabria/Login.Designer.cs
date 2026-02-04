namespace RetaCantabria
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIniciar = new Button();
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnRegistrarse = new Button();
            lblRegistrate = new Label();
            labelEntrar = new LinkLabel();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(342, 341);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(100, 23);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Sesión";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(369, 79);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(354, 214);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(313, 97);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(154, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.HideSelection = false;
            txtPassword.Location = new Point(313, 242);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(154, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(702, 12);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(88, 23);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // lblRegistrate
            // 
            lblRegistrate.AutoSize = true;
            lblRegistrate.Location = new Point(545, 16);
            lblRegistrate.Name = "lblRegistrate";
            lblRegistrate.Size = new Size(135, 15);
            lblRegistrate.TabIndex = 6;
            lblRegistrate.Text = "¿Eres nuevo? ¡Regístrate!";
            // 
            // labelEntrar
            // 
            labelEntrar.AutoSize = true;
            labelEntrar.LinkColor = Color.FromArgb(64, 64, 64);
            labelEntrar.Location = new Point(666, 417);
            labelEntrar.Name = "labelEntrar";
            labelEntrar.Size = new Size(113, 15);
            labelEntrar.TabIndex = 7;
            labelEntrar.TabStop = true;
            labelEntrar.Text = "Entrar sin registrarse";
            labelEntrar.LinkClicked += labelEntrar_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelEntrar);
            Controls.Add(lblRegistrate);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(btnIniciar);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnRegistrarse;
        private Label lblRegistrate;
        private LinkLabel labelEntrar;
    }
}
