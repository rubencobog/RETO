namespace RetaCantabria
{
    partial class AgregarRutaCalendario
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
            dgvRutasDisponibles = new DataGridView();
            btnInsertarRuta = new Button();
            btnCancelar = new Button();
            lblDetalles = new Label();
            lblRecomendaciones = new Label();
            txtDetalles = new TextBox();
            txtRecomendaciones = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRutasDisponibles).BeginInit();
            SuspendLayout();
            // 
            // dgvRutasDisponibles
            // 
            dgvRutasDisponibles.BackgroundColor = SystemColors.Window;
            dgvRutasDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutasDisponibles.Location = new Point(29, 46);
            dgvRutasDisponibles.Margin = new Padding(4, 5, 4, 5);
            dgvRutasDisponibles.Name = "dgvRutasDisponibles";
            dgvRutasDisponibles.RowHeadersWidth = 51;
            dgvRutasDisponibles.Size = new Size(460, 448);
            dgvRutasDisponibles.TabIndex = 0;
            // 
            // btnInsertarRuta
            // 
            btnInsertarRuta.BackColor = Color.FromArgb(74, 82, 90);
            btnInsertarRuta.FlatAppearance.BorderColor = Color.Crimson;
            btnInsertarRuta.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnInsertarRuta.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnInsertarRuta.FlatStyle = FlatStyle.Flat;
            btnInsertarRuta.ForeColor = SystemColors.ButtonHighlight;
            btnInsertarRuta.Location = new Point(853, 543);
            btnInsertarRuta.Margin = new Padding(4, 5, 4, 5);
            btnInsertarRuta.Name = "btnInsertarRuta";
            btnInsertarRuta.Size = new Size(112, 36);
            btnInsertarRuta.TabIndex = 1;
            btnInsertarRuta.Text = "Añadir";
            btnInsertarRuta.UseVisualStyleBackColor = false;
            btnInsertarRuta.Click += btnInsertarRuta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(74, 82, 90);
            btnCancelar.FlatAppearance.BorderColor = Color.Crimson;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(691, 543);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(113, 36);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Location = new Point(591, 47);
            lblDetalles.Margin = new Padding(4, 0, 4, 0);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(74, 23);
            lblDetalles.TabIndex = 3;
            lblDetalles.Text = "Detalles:";
            // 
            // lblRecomendaciones
            // 
            lblRecomendaciones.AutoSize = true;
            lblRecomendaciones.Location = new Point(591, 297);
            lblRecomendaciones.Margin = new Padding(4, 0, 4, 0);
            lblRecomendaciones.Name = "lblRecomendaciones";
            lblRecomendaciones.Size = new Size(152, 23);
            lblRecomendaciones.TabIndex = 4;
            lblRecomendaciones.Text = "Recomendaciones:";
            // 
            // txtDetalles
            // 
            txtDetalles.Location = new Point(591, 75);
            txtDetalles.Margin = new Padding(4, 5, 4, 5);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.Size = new Size(374, 179);
            txtDetalles.TabIndex = 5;
            // 
            // txtRecomendaciones
            // 
            txtRecomendaciones.Location = new Point(591, 325);
            txtRecomendaciones.Margin = new Padding(4, 5, 4, 5);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.Size = new Size(374, 169);
            txtRecomendaciones.TabIndex = 6;
            // 
            // AgregarRutaCalendario
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 690);
            Controls.Add(txtRecomendaciones);
            Controls.Add(txtDetalles);
            Controls.Add(lblRecomendaciones);
            Controls.Add(lblDetalles);
            Controls.Add(btnCancelar);
            Controls.Add(btnInsertarRuta);
            Controls.Add(dgvRutasDisponibles);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AgregarRutaCalendario";
            Text = "Rutas Disponibles";
            Load += AgregarRutaCalendario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRutasDisponibles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutasDisponibles;
        private Button btnInsertarRuta;
        private Button btnCancelar;
        private Label lblDetalles;
        private Label lblRecomendaciones;
        private TextBox txtDetalles;
        private TextBox txtRecomendaciones;
    }
}