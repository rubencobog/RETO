namespace RetaCantabria
{
    partial class GestionUsuarios
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
            dgvUsuarios = new DataGridView();
            Eliminar = new Button();
            btnEditar = new Button();
            btnPermisos = new Button();
            comboPermisos = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(58, 51);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(681, 319);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(664, 386);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(75, 23);
            Eliminar.TabIndex = 1;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(565, 386);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnPermisos
            // 
            btnPermisos.Location = new Point(412, 386);
            btnPermisos.Name = "btnPermisos";
            btnPermisos.Size = new Size(125, 23);
            btnPermisos.TabIndex = 3;
            btnPermisos.Text = "Cambiar Permisos";
            btnPermisos.UseVisualStyleBackColor = true;
            btnPermisos.Click += btnPermisos_Click;
            // 
            // comboPermisos
            // 
            comboPermisos.FormattingEnabled = true;
            comboPermisos.Location = new Point(412, 405);
            comboPermisos.Name = "comboPermisos";
            comboPermisos.Size = new Size(125, 23);
            comboPermisos.TabIndex = 4;
            // 
            // GestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboPermisos);
            Controls.Add(btnPermisos);
            Controls.Add(btnEditar);
            Controls.Add(Eliminar);
            Controls.Add(dgvUsuarios);
            Name = "GestionUsuarios";
            Text = "Usuarios";
            Load += GestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button Eliminar;
        private Button btnEditar;
        private Button btnPermisos;
        private ComboBox comboPermisos;
    }
}