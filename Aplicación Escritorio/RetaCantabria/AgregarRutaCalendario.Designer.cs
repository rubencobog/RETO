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
            dgvRutasDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutasDisponibles.Location = new Point(443, 22);
            dgvRutasDisponibles.Name = "dgvRutasDisponibles";
            dgvRutasDisponibles.Size = new Size(309, 316);
            dgvRutasDisponibles.TabIndex = 0;
            // 
            // btnInsertarRuta
            // 
            btnInsertarRuta.Location = new Point(536, 385);
            btnInsertarRuta.Name = "btnInsertarRuta";
            btnInsertarRuta.Size = new Size(81, 23);
            btnInsertarRuta.TabIndex = 1;
            btnInsertarRuta.Text = "Añadir";
            btnInsertarRuta.UseVisualStyleBackColor = true;
            btnInsertarRuta.Click += btnInsertarRuta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(643, 385);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Location = new Point(44, 22);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(51, 15);
            lblDetalles.TabIndex = 3;
            lblDetalles.Text = "Detalles:";
            // 
            // lblRecomendaciones
            // 
            lblRecomendaciones.AutoSize = true;
            lblRecomendaciones.Location = new Point(44, 200);
            lblRecomendaciones.Name = "lblRecomendaciones";
            lblRecomendaciones.Size = new Size(107, 15);
            lblRecomendaciones.TabIndex = 4;
            lblRecomendaciones.Text = "Recomendaciones:";
            // 
            // txtDetalles
            // 
            txtDetalles.Location = new Point(44, 45);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.Size = new Size(292, 118);
            txtDetalles.TabIndex = 5;
            // 
            // txtRecomendaciones
            // 
            txtRecomendaciones.Location = new Point(44, 227);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.Size = new Size(292, 111);
            txtRecomendaciones.TabIndex = 6;
            // 
            // AgregarRutaCalendario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtRecomendaciones);
            Controls.Add(txtDetalles);
            Controls.Add(lblRecomendaciones);
            Controls.Add(lblDetalles);
            Controls.Add(btnCancelar);
            Controls.Add(btnInsertarRuta);
            Controls.Add(dgvRutasDisponibles);
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