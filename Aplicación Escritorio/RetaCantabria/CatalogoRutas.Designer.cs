namespace RetaCantabria
{
    partial class CatalogoRutas
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
            dgvRutas = new DataGridView();
            lblRutas = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRutas).BeginInit();
            SuspendLayout();
            // 
            // dgvRutas
            // 
            dgvRutas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutas.Location = new Point(34, 49);
            dgvRutas.Name = "dgvRutas";
            dgvRutas.Size = new Size(719, 340);
            dgvRutas.TabIndex = 0;
            // 
            // lblRutas
            // 
            lblRutas.AutoSize = true;
            lblRutas.Location = new Point(704, 19);
            lblRutas.Name = "lblRutas";
            lblRutas.Size = new Size(36, 15);
            lblRutas.TabIndex = 1;
            lblRutas.Text = "Rutas";
            // 
            // CatalogoRutas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRutas);
            Controls.Add(dgvRutas);
            Name = "CatalogoRutas";
            Text = "Catálogo";
            ((System.ComponentModel.ISupportInitialize)dgvRutas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutas;
        private Label lblRutas;
    }
}