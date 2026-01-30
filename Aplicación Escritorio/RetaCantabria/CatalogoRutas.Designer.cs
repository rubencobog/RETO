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
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(34, 401);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(89, 23);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear Ruta";
            btnCrear.UseVisualStyleBackColor = true;
            // 
            // CatalogoRutas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrear);
            Controls.Add(btnDescarga);
            Controls.Add(btnValorar);
            Controls.Add(btnResena);
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
        private Button btnResena;
        private Button btnValorar;
        private Button btnDescarga;
        private Button btnCrear;
    }
}