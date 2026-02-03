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
            dataGridView1 = new DataGridView();
            lblSelect = new Label();
            comboValoracion = new ComboBox();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(739, 300);
            dataGridView1.TabIndex = 0;
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
            // 
            // GestionValoraciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBorrar);
            Controls.Add(comboValoracion);
            Controls.Add(lblSelect);
            Controls.Add(dataGridView1);
            Name = "GestionValoraciones";
            Text = "Valoraciones/Reseñas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblSelect;
        private ComboBox comboValoracion;
        private Button btnBorrar;
    }
}