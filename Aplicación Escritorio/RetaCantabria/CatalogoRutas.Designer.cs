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
            btnResena = new Button();
            btnValorar = new Button();
            btnDescarga = new Button();
            btnCrear = new Button();
            panelAdmin = new Panel();
            btnGestionValoraciones = new Button();
            btnUsuarios = new Button();
            btnValidar = new Button();
            btnCalendario = new Button();
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
            // btnResena
            // 
            btnResena.Location = new Point(678, 401);
            btnResena.Name = "btnResena";
            btnResena.Size = new Size(75, 23);
            btnResena.TabIndex = 2;
            btnResena.Text = "Reseñar";
            btnResena.UseVisualStyleBackColor = true;
            btnResena.Click += btnResena_Click;
            // 
            // btnValorar
            // 
            btnValorar.Location = new Point(576, 401);
            btnValorar.Name = "btnValorar";
            btnValorar.Size = new Size(75, 23);
            btnValorar.TabIndex = 3;
            btnValorar.Text = "Valorar";
            btnValorar.UseVisualStyleBackColor = true;
            btnValorar.Click += btnValorar_Click;
            // 
            // btnDescarga
            // 
            btnDescarga.Location = new Point(438, 401);
            btnDescarga.Name = "btnDescarga";
            btnDescarga.Size = new Size(109, 23);
            btnDescarga.TabIndex = 4;
            btnDescarga.Text = "Descargar Ficha";
            btnDescarga.UseVisualStyleBackColor = true;
            btnDescarga.Click += btnDescarga_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(34, 401);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(89, 23);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear Ruta";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // panelAdmin
            // 
            panelAdmin.Controls.Add(btnGestionValoraciones);
            panelAdmin.Controls.Add(btnUsuarios);
            panelAdmin.Location = new Point(34, 0);
            panelAdmin.Name = "panelAdmin";
            panelAdmin.Size = new Size(331, 34);
            panelAdmin.TabIndex = 6;
            // 
            // btnGestionValoraciones
            // 
            btnGestionValoraciones.Location = new Point(126, 3);
            btnGestionValoraciones.Name = "btnGestionValoraciones";
            btnGestionValoraciones.Size = new Size(197, 28);
            btnGestionValoraciones.TabIndex = 1;
            btnGestionValoraciones.Text = "Gestionar valoraciones/reseñas";
            btnGestionValoraciones.UseVisualStyleBackColor = true;
            btnGestionValoraciones.Click += btnGestionValoraciones_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(3, 3);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(117, 28);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Gestionar Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnValidar
            // 
            btnValidar.Location = new Point(148, 401);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(115, 23);
            btnValidar.TabIndex = 7;
            btnValidar.Text = "Validar Ruta";
            btnValidar.UseVisualStyleBackColor = true;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnCalendario
            // 
            btnCalendario.Location = new Point(284, 401);
            btnCalendario.Name = "btnCalendario";
            btnCalendario.Size = new Size(130, 23);
            btnCalendario.TabIndex = 8;
            btnCalendario.Text = "Calendario de Rutas";
            btnCalendario.UseVisualStyleBackColor = true;
            btnCalendario.Click += btnCalendario_Click;
            // 
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(btnCalendario);
            Controls.Add(btnValidar);
            Controls.Add(panelAdmin);
            Controls.Add(btnCrear);
            Controls.Add(btnDescarga);
            Controls.Add(btnValorar);
            Controls.Add(btnResena);
            Controls.Add(lblRutas);
            Controls.Add(dgvRutas);
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
        private Label lblRutas;
        private Button btnResena;
        private Button btnValorar;
        private Button btnDescarga;
        private Button btnCrear;
        private Panel panelAdmin;
        private Button btnUsuarios;
        private Button btnValidar;
        private Button btnGestionValoraciones;
        private Button btnCalendario;
        private Button btnEnviarGPX;
        private Button btnGenerarGPX;
        private Panel panel1;
    }
}