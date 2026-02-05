namespace RetaCantabria
{
    partial class GestionValoraciones
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
            dgvValRes = new DataGridView();
            lblSelect = new Label();
            comboValoracion = new ComboBox();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvValRes).BeginInit();
            SuspendLayout();
            // 
            // dgvValRes
            // 
            dgvValRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvValRes.Location = new Point(29, 73);
            dgvValRes.Name = "dgvValRes";
            dgvValRes.RowHeadersWidth = 51;
            dgvValRes.Size = new Size(739, 300);
            dgvValRes.TabIndex = 0;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Location = new Point(165, 36);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(63, 15);
            lblSelect.TabIndex = 1;
            lblSelect.Text = "Selecciona";
            // 
            // comboValoracion
            // 
            comboValoracion.FormattingEnabled = true;
            comboValoracion.Items.AddRange(new object[] { "Valoraciones", "Reseñas" });
            comboValoracion.Location = new Point(29, 33);
            comboValoracion.Name = "comboValoracion";
            comboValoracion.Size = new Size(121, 23);
            comboValoracion.TabIndex = 3;
            comboValoracion.SelectedIndexChanged += comboValoracion_SelectedIndexChanged;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(694, 394);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 4;
            btnBorrar.Text = "Eliminar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // GestionValoraciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBorrar);
            Controls.Add(comboValoracion);
            Controls.Add(lblSelect);
            Controls.Add(dgvValRes);
            Name = "GestionValoraciones";
            Text = "Valoraciones/Reseñas";
            ((System.ComponentModel.ISupportInitialize)dgvValRes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvValRes;
        private Label lblSelect;
        private ComboBox comboValoracion;
        private Button btnBorrar;
    }
}