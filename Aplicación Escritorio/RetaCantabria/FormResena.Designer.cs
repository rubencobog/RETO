namespace RetaCantabria
{
    partial class FormResena
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
            lblResena = new Label();
            txtResena = new TextBox();
            btnEnviar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblResena
            // 
            lblResena.AutoSize = true;
            lblResena.Location = new Point(67, 59);
            lblResena.Name = "lblResena";
            lblResena.Size = new Size(60, 15);
            lblResena.TabIndex = 0;
            lblResena.Text = "Reseña de";
            // 
            // txtResena
            // 
            txtResena.Location = new Point(67, 116);
            txtResena.Multiline = true;
            txtResena.Name = "txtResena";
            txtResena.Size = new Size(647, 229);
            txtResena.TabIndex = 1;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.FromArgb(74, 82, 90);
            btnEnviar.FlatAppearance.BorderColor = Color.Crimson;
            btnEnviar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnEnviar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.ForeColor = SystemColors.ButtonHighlight;
            btnEnviar.Location = new Point(639, 375);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(74, 82, 90);
            btnCancelar.FlatAppearance.BorderColor = Color.Crimson;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(533, 375);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormResena
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnEnviar);
            Controls.Add(txtResena);
            Controls.Add(lblResena);
            Name = "FormResena";
            Text = "Reseñas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResena;
        private TextBox txtResena;
        private Button btnEnviar;
        private Button btnCancelar;
    }
}