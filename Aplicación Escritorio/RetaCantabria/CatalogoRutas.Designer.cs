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
            btnResena = new Button();
            btnValorar = new Button();
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
            btnEnviarGPX = new Button();
            btnGenerarGPX = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRutas).BeginInit();
            panelAdmin.SuspendLayout();
            panel1.SuspendLayout();
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
            // btnResena
            // 
            btnResena.Location = new Point(775, 535);
            btnResena.Margin = new Padding(3, 4, 3, 4);
            btnResena.Name = "btnResena";
            btnResena.Size = new Size(86, 31);
            btnResena.TabIndex = 2;
            btnResena.Text = "Reseñar";
            btnResena.UseVisualStyleBackColor = true;
            btnResena.Click += btnResena_Click;
            // 
            // btnValorar
            // 
            btnValorar.Location = new Point(658, 535);
            btnValorar.Margin = new Padding(3, 4, 3, 4);
            btnValorar.Name = "btnValorar";
            btnValorar.Size = new Size(86, 31);
            btnValorar.TabIndex = 3;
            btnValorar.Text = "Valorar";
            btnValorar.UseVisualStyleBackColor = true;
            btnValorar.Click += btnValorar_Click;
            // 
            // btnDescarga
            // 
            btnDescarga.Location = new Point(501, 535);
            btnDescarga.Margin = new Padding(3, 4, 3, 4);
            btnDescarga.Name = "btnDescarga";
            btnDescarga.Size = new Size(125, 31);
            btnDescarga.TabIndex = 4;
            btnDescarga.Text = "Descargar Ficha";
            btnDescarga.UseVisualStyleBackColor = true;
            btnDescarga.Click += btnDescarga_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(39, 535);
            btnCrear.Margin = new Padding(3, 4, 3, 4);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(102, 31);
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
            panelAdmin.Location = new Point(39, 65);
            panelAdmin.Margin = new Padding(3, 4, 3, 4);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(235, 101);
            panelAdmin.TabIndex = 6;
            // 
            // btnGestionValoraciones
            // 
            btnGestionValoraciones.Location = new Point(8, 56);
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
            btnValidar.Location = new Point(169, 535);
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
            btnCalendario.Location = new Point(325, 535);
            btnCalendario.Margin = new Padding(3, 4, 3, 4);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Size = new Size(149, 31);
            btnCalendario.TabIndex = 8;
            btnCalendario.Text = "Calendario de Rutas";
            btnCalendario.UseVisualStyleBackColor = true;
            btnCalendario.Click += btnCalendario_Click;
            //
            // comboFiltro
            // 
            comboFiltro.FormattingEnabled = true;
            comboFiltro.Items.AddRange(new object[] { "Circular", "Lineal", "Accesible", "Familiar", "Media de 4 estrellas o mas" });
            comboFiltro.Location = new Point(710, 23);
            comboFiltro.Name = "comboFiltro";
            comboFiltro.Size = new Size(151, 28);
            comboFiltro.TabIndex = 9;
            comboFiltro.SelectedIndexChanged += comboFiltro_SelectedIndexChanged;
            // 
            // lblRutas
            // 
            lblRutas.AutoSize = true;
            lblRutas.BorderStyle = BorderStyle.Fixed3D;
            lblRutas.Location = new Point(429, 23);
            lblRutas.Name = "lblRutas";
            lblRutas.Size = new Size(55, 22);
            lblRutas.TabIndex = 10;
            lblRutas.Text = "RUTAS";
            // 
            // btnMenuAdmin
            // 
            btnMenuAdmin.FlatStyle = FlatStyle.System;
            btnMenuAdmin.Location = new Point(39, 23);
            btnMenuAdmin.Name = "btnMenuAdmin";
            btnMenuAdmin.Size = new Size(58, 29);
            btnMenuAdmin.TabIndex = 11;
            btnMenuAdmin.Text = ". . .";
            btnMenuAdmin.UseVisualStyleBackColor = true;
            btnMenuAdmin.Click += btnMenuAdmin_Click;
            // btnEnviarGPX
            // 
            btnEnviarGPX.Location = new Point(3, 4);
            btnEnviarGPX.Name = "btnEnviarGPX";
            btnEnviarGPX.Size = new Size(87, 27);
            btnEnviarGPX.TabIndex = 9;
            btnEnviarGPX.Text = "Enviar GPX";
            btnEnviarGPX.UseVisualStyleBackColor = true;
            btnEnviarGPX.Click += btnEnviarGPX_Click;
            // 
            // btnGenerarGPX
            // 
            btnGenerarGPX.Location = new Point(105, 3);
            btnGenerarGPX.Name = "btnGenerarGPX";
            btnGenerarGPX.Size = new Size(114, 28);
            btnGenerarGPX.TabIndex = 10;
            btnGenerarGPX.Text = "Generar GPX";
            btnGenerarGPX.UseVisualStyleBackColor = true;
            btnGenerarGPX.Click += btnGenerarGPX_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnEnviarGPX);
            panel1.Controls.Add(btnGenerarGPX);
            panel1.Location = new Point(417, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 34);
            panel1.TabIndex = 11;
            // 
            // CatalogoRutas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnMenuAdmin);
            Controls.Add(lblRutas);
            Controls.Add(comboFiltro);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnCalendario);
            Controls.Add(btnValidar);
            Controls.Add(panelAdmin);
            Controls.Add(btnCrear);
            Controls.Add(btnDescarga);
            Controls.Add(btnValorar);
            Controls.Add(btnResena);
            Controls.Add(lblFiltro);
            Controls.Add(dgvRutas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CatalogoRutas";
            Text = "Catálogo";
            ((System.ComponentModel.ISupportInitialize)dgvRutas).EndInit();
            panelAdmin.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutas;
        private Label lblFiltro;
        private Button btnResena;
        private Button btnValorar;
        private Button btnDescarga;
        private Button btnCrear;
        private Panel panelAdmin;
        private Button btnUsuarios;
        private Button btnValidar;
        private Button btnGestionValoraciones;
        private Button btnCalendario;
        private ComboBox comboFiltro;
        private Label lblRutas;
        private Button btnMenuAdmin;
        private Button btnEnviarGPX;
        private Button btnGenerarGPX;
        private Panel panel1;
    }
}