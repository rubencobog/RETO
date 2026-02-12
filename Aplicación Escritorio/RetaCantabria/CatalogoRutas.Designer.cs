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
            lblFiltro = new Label();
            btnDescarga = new Button();
            btnCrear = new Button();
            panelAdmin = new Panel();
            btnGestionValoraciones = new Button();
            btnUsuarios = new Button();
            btnValidar = new Button();
            btnCalendario = new Button();
            comboFiltro = new ComboBox();
            lblRutas = new Label();
            btnMenuAdmin = new Button();
            btnGenerarGPX = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRutas).BeginInit();
            panelAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRutas
            // 
            dgvRutas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutas.Location = new Point(39, 65);
            dgvRutas.Margin = new Padding(3, 4, 3, 4);
            dgvRutas.Name = "dgvRutas";
            dgvRutas.RowHeadersWidth = 51;
            dgvRutas.Size = new Size(822, 453);
            dgvRutas.TabIndex = 0;
            dgvRutas.CellDoubleClick += dgvRutas_CellDoubleClick;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Location = new Point(589, 23);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(103, 20);
            lblFiltro.TabIndex = 1;
            lblFiltro.Text = "Filtro de rutas:";
            // 
            // btnDescarga
            // 
            btnDescarga.BackColor = Color.FromArgb(74, 82, 90);
            btnDescarga.FlatAppearance.BorderColor = Color.Crimson;
            btnDescarga.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnDescarga.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnDescarga.FlatStyle = FlatStyle.Flat;
            btnDescarga.ForeColor = SystemColors.ButtonHighlight;
            btnDescarga.Location = new Point(569, 535);
            btnDescarga.Margin = new Padding(3, 4, 3, 4);
            btnDescarga.Name = "btnDescarga";
            btnDescarga.Size = new Size(141, 31);
            btnDescarga.TabIndex = 4;
            btnDescarga.Text = "Descargar Ficha";
            btnDescarga.UseVisualStyleBackColor = true;
            btnDescarga.Click += btnDescarga_Click;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(74, 82, 90);
            btnCrear.FlatAppearance.BorderColor = Color.Crimson;
            btnCrear.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCrear.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.ForeColor = SystemColors.ButtonHighlight;
            btnCrear.Location = new Point(388, 535);
            btnCrear.Margin = new Padding(3, 4, 3, 4);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(156, 31);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear Ruta";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // panelAdmin
            // 
            panelAdmin.BackgroundImageLayout = ImageLayout.Center;
            panelAdmin.BorderStyle = BorderStyle.Fixed3D;
            panelAdmin.Controls.Add(btnGestionValoraciones);
            panelAdmin.Controls.Add(btnUsuarios);
            panelAdmin.Location = new Point(39, 55);
            panelAdmin.Margin = new Padding(3, 4, 3, 4);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(239, 105);
            panelAdmin.TabIndex = 6;
            // 
            // btnGestionValoraciones
            // 
            btnGestionValoraciones.Location = new Point(3, 56);
            btnGestionValoraciones.Margin = new Padding(3, 4, 3, 4);
            btnGestionValoraciones.Name = "btnGestionValoraciones";
            btnGestionValoraciones.Size = new Size(225, 37);
            btnGestionValoraciones.TabIndex = 1;
            btnGestionValoraciones.Text = "Gestionar valoraciones/reseñas";
            btnGestionValoraciones.UseVisualStyleBackColor = true;
            btnGestionValoraciones.Click += btnGestionValoraciones_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(3, 8);
            btnUsuarios.Margin = new Padding(3, 4, 3, 4);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(225, 37);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Gestionar Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnValidar
            // 
            btnValidar.BackColor = Color.FromArgb(74, 82, 90);
            btnValidar.FlatAppearance.BorderColor = Color.Crimson;
            btnValidar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnValidar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnValidar.FlatStyle = FlatStyle.Flat;
            btnValidar.ForeColor = SystemColors.ButtonHighlight;
            btnValidar.Location = new Point(39, 535);
            btnValidar.Margin = new Padding(3, 4, 3, 4);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(131, 31);
            btnValidar.TabIndex = 7;
            btnValidar.Text = "Validar Ruta";
            btnValidar.UseVisualStyleBackColor = true;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnCalendario
            // 
            btnCalendario.BackColor = Color.FromArgb(74, 82, 90);
            btnCalendario.FlatAppearance.BorderColor = Color.Crimson;
            btnCalendario.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCalendario.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnCalendario.FlatStyle = FlatStyle.Flat;
            btnCalendario.ForeColor = SystemColors.ButtonHighlight;
            btnCalendario.Location = new Point(195, 535);
            btnCalendario.Margin = new Padding(3, 4, 3, 4);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Size = new Size(168, 31);
            btnCalendario.TabIndex = 8;
            btnCalendario.Text = "Calendario de Rutas";
            btnCalendario.UseVisualStyleBackColor = true;
            btnCalendario.Click += btnCalendario_Click;
            // 
            // comboFiltro
            // 
            comboFiltro.FormattingEnabled = true;
            comboFiltro.Items.AddRange(new object[] { "Todas", "Circular", "Lineal", "Accesible", "Familiar", "Media de 4 estrellas o mas" });
            comboFiltro.Location = new Point(710, 23);
            comboFiltro.Name = "comboFiltro";
            comboFiltro.Size = new Size(151, 28);
            comboFiltro.TabIndex = 9;
            comboFiltro.SelectedIndexChanged += comboFiltro_SelectedIndexChanged;
            // 
            // lblRutas
            // 
            lblRutas.AutoSize = true;
            lblRutas.BackColor = SystemColors.Control;
            lblRutas.BorderStyle = BorderStyle.FixedSingle;
            lblRutas.Location = new Point(429, 23);
            lblRutas.Name = "lblRutas";
            lblRutas.Size = new Size(55, 22);
            lblRutas.TabIndex = 10;
            lblRutas.Text = "RUTAS";
            // 
            // btnMenuAdmin
            // 
            btnMenuAdmin.BackColor = SystemColors.Window;
            btnMenuAdmin.FlatStyle = FlatStyle.Flat;
            btnMenuAdmin.Location = new Point(39, 23);
            btnMenuAdmin.Name = "btnMenuAdmin";
            btnMenuAdmin.Size = new Size(58, 29);
            btnMenuAdmin.TabIndex = 11;
            btnMenuAdmin.Text = ". . .";
            btnMenuAdmin.UseVisualStyleBackColor = false;
            btnMenuAdmin.Click += btnMenuAdmin_Click;
            // 
            // btnGenerarGPX
            // 
            btnGenerarGPX.BackColor = Color.FromArgb(74, 82, 90);
            btnGenerarGPX.FlatAppearance.BorderColor = Color.Crimson;
            btnGenerarGPX.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnGenerarGPX.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnGenerarGPX.FlatStyle = FlatStyle.Flat;
            btnGenerarGPX.ForeColor = SystemColors.ButtonHighlight;
            btnGenerarGPX.Location = new Point(735, 535);
            btnGenerarGPX.Name = "btnGenerarGPX";
            btnGenerarGPX.Size = new Size(126, 31);
            btnGenerarGPX.TabIndex = 10;
            btnGenerarGPX.Text = "Generar GPX";
            btnGenerarGPX.UseVisualStyleBackColor = true;
            btnGenerarGPX.Click += btnGenerarGPX_Click;
            // 
            // CatalogoRutas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 608);
            Controls.Add(btnGenerarGPX);
            Controls.Add(btnMenuAdmin);
            Controls.Add(lblRutas);
            Controls.Add(comboFiltro);
            Controls.Add(btnCalendario);
            Controls.Add(btnValidar);
            Controls.Add(panelAdmin);
            Controls.Add(btnCrear);
            Controls.Add(btnDescarga);
            Controls.Add(lblFiltro);
            Controls.Add(dgvRutas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CatalogoRutas";
            Text = "Catálogo";
            ((System.ComponentModel.ISupportInitialize)dgvRutas).EndInit();
            panelAdmin.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblFiltro;
        private Button btnUsuarios;
        private Button btnGestionValoraciones;
        private ComboBox comboFiltro;
        private Label lblRutas;
        internal DataGridView dgvRutas;
        internal Button btnDescarga;
        internal Button btnCrear;
        internal Button btnValidar;
        internal Button btnCalendario;
        internal Button btnMenuAdmin;
        internal Button btnGenerarGPX;
        internal Panel panelAdmin;
    }
}