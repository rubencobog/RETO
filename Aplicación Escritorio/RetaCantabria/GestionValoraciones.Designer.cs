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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvValRes = new DataGridView();
            lblSelect = new Label();
            comboValoracion = new ComboBox();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvValRes).BeginInit();
            SuspendLayout();
            // 
            // dgvValRes
            // 
            dgvValRes.AllowUserToResizeColumns = false;
            dgvValRes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvValRes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvValRes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvValRes.BackgroundColor = Color.White;
            dgvValRes.BorderStyle = BorderStyle.None;
            dgvValRes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvValRes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvValRes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(220, 20, 60);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvValRes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvValRes.EnableHeadersVisualStyles = false;
            dgvValRes.Location = new Point(33, 97);
            dgvValRes.Margin = new Padding(3, 4, 3, 4);
            dgvValRes.Name = "dgvValRes";
            dgvValRes.RowHeadersWidth = 51;
            dgvValRes.Size = new Size(845, 400);
            dgvValRes.TabIndex = 0;
            dgvValRes.CellDoubleClick += dgvValRes_CellDoubleClick;
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.Location = new Point(189, 48);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new Size(80, 20);
            lblSelect.TabIndex = 1;
            lblSelect.Text = "Selecciona";
            // 
            // comboValoracion
            // 
            comboValoracion.FlatStyle = FlatStyle.Flat;
            comboValoracion.FormattingEnabled = true;
            comboValoracion.Items.AddRange(new object[] { "Valoraciones", "Reseñas" });
            comboValoracion.Location = new Point(33, 44);
            comboValoracion.Margin = new Padding(3, 4, 3, 4);
            comboValoracion.Name = "comboValoracion";
            comboValoracion.Size = new Size(138, 28);
            comboValoracion.TabIndex = 3;
            comboValoracion.SelectedIndexChanged += comboValoracion_SelectedIndexChanged;
            // 
            // btnBorrar
            // 
            btnBorrar.BackColor = Color.FromArgb(74, 82, 90);
            btnBorrar.FlatAppearance.BorderColor = Color.Crimson;
            btnBorrar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnBorrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.ForeColor = SystemColors.ButtonHighlight;
            btnBorrar.Location = new Point(793, 525);
            btnBorrar.Margin = new Padding(3, 4, 3, 4);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(86, 31);
            btnBorrar.TabIndex = 4;
            btnBorrar.Text = "Eliminar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // GestionValoraciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnBorrar);
            Controls.Add(comboValoracion);
            Controls.Add(lblSelect);
            Controls.Add(dgvValRes);
            Margin = new Padding(3, 4, 3, 4);
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