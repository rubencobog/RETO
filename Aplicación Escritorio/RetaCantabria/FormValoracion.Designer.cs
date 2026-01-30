namespace RetaCantabria
{
    partial class FormValoracion
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
            lblDificultad = new Label();
            lblBelleza = new Label();
            lblInteres = new Label();
            numUDDif = new NumericUpDown();
            numUDBelleza = new NumericUpDown();
            numUDInteres = new NumericUpDown();
            btnEnviar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numUDDif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUDBelleza).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUDInteres).BeginInit();
            SuspendLayout();
            // 
            // lblDificultad
            // 
            lblDificultad.AutoSize = true;
            lblDificultad.Location = new Point(239, 39);
            lblDificultad.Name = "lblDificultad";
            lblDificultad.Size = new Size(61, 15);
            lblDificultad.TabIndex = 0;
            lblDificultad.Text = "Dificultad:";
            // 
            // lblBelleza
            // 
            lblBelleza.AutoSize = true;
            lblBelleza.Location = new Point(243, 130);
            lblBelleza.Name = "lblBelleza";
            lblBelleza.Size = new Size(46, 15);
            lblBelleza.TabIndex = 1;
            lblBelleza.Text = "Belleza:";
            // 
            // lblInteres
            // 
            lblInteres.AutoSize = true;
            lblInteres.Location = new Point(223, 223);
            lblInteres.Name = "lblInteres";
            lblInteres.Size = new Size(90, 15);
            lblInteres.TabIndex = 2;
            lblInteres.Text = "Interés Cultural:";
            // 
            // numUDDif
            // 
            numUDDif.Location = new Point(206, 69);
            numUDDif.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numUDDif.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUDDif.Name = "numUDDif";
            numUDDif.Size = new Size(120, 23);
            numUDDif.TabIndex = 3;
            numUDDif.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numUDBelleza
            // 
            numUDBelleza.Location = new Point(206, 161);
            numUDBelleza.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numUDBelleza.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUDBelleza.Name = "numUDBelleza";
            numUDBelleza.Size = new Size(120, 23);
            numUDBelleza.TabIndex = 4;
            numUDBelleza.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numUDInteres
            // 
            numUDInteres.Location = new Point(206, 256);
            numUDInteres.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numUDInteres.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUDInteres.Name = "numUDInteres";
            numUDInteres.Size = new Size(120, 23);
            numUDInteres.TabIndex = 5;
            numUDInteres.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(276, 342);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 6;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(181, 342);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormValoracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 402);
            Controls.Add(btnCancelar);
            Controls.Add(btnEnviar);
            Controls.Add(numUDInteres);
            Controls.Add(numUDBelleza);
            Controls.Add(numUDDif);
            Controls.Add(lblInteres);
            Controls.Add(lblBelleza);
            Controls.Add(lblDificultad);
            Name = "FormValoracion";
            Text = "Valoracion";
            ((System.ComponentModel.ISupportInitialize)numUDDif).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUDBelleza).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUDInteres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDificultad;
        private Label lblBelleza;
        private Label lblInteres;
        private NumericUpDown numUDDif;
        private NumericUpDown numUDBelleza;
        private NumericUpDown numUDInteres;
        private Button btnEnviar;
        private Button btnCancelar;
    }
}