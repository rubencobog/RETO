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
            pictureLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnIniciar.BackColor = Color.LightSteelBlue;
            btnIniciar.FlatAppearance.BorderColor = Color.Crimson;
            btnIniciar.FlatAppearance.BorderSize = 2;
            btnIniciar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnIniciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.ForeColor = SystemColors.ButtonHighlight;
            btnIniciar.Location = new Point(414, 524);
            btnIniciar.Margin = new Padding(4, 5, 4, 5);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(310, 39);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Sesión";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(542, 285);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(518, 392);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(108, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(414, 315);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(310, 28);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.HideSelection = false;
            txtPassword.Location = new Point(414, 422);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(310, 32);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            btnRegistrarse.FlatAppearance.BorderSize = 2;
            btnRegistrarse.FlatStyle = FlatStyle.Flat;
            btnRegistrarse.Location = new Point(984, 35);
            btnRegistrarse.Margin = new Padding(4, 5, 4, 5);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(126, 39);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // lblRegistrate
            // 
            lblRegistrate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRegistrate.AutoSize = true;
            lblRegistrate.Location = new Point(760, 41);
            lblRegistrate.Margin = new Padding(4, 0, 4, 0);
            lblRegistrate.Name = "lblRegistrate";
            lblRegistrate.Size = new Size(220, 25);
            lblRegistrate.TabIndex = 6;
            lblRegistrate.Text = "¿Eres nuevo? ¡Regístrate!";
            // 
            // labelEntrar
            // 
            labelEntrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelEntrar.AutoSize = true;
            labelEntrar.LinkColor = Color.FromArgb(64, 64, 64);
            labelEntrar.Location = new Point(924, 538);
            labelEntrar.Margin = new Padding(4, 0, 4, 0);
            labelEntrar.Name = "labelEntrar";
            labelEntrar.Size = new Size(186, 25);
            labelEntrar.TabIndex = 7;
            labelEntrar.TabStop = true;
            labelEntrar.Text = "Entrar sin registrarse";
            labelEntrar.LinkClicked += labelEntrar_LinkClicked;
            // 
            // pictureLogo
            // 
            pictureLogo.Location = new Point(418, 0);
            pictureLogo.Margin = new Padding(4);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(306, 281);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 8;
            pictureLogo.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 658);
            Controls.Add(pictureLogo);
            Controls.Add(labelEntrar);
            Controls.Add(lblRegistrate);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(btnIniciar);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
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
        private PictureBox pictureLogo;
    }
}
