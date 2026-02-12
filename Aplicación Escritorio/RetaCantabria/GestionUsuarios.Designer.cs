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
            dgvUsuarios.Location = new Point(66, 68);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(778, 425);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // Eliminar
            // 
            Eliminar.BackColor = Color.FromArgb(74, 82, 90);
            Eliminar.FlatAppearance.BorderColor = Color.Crimson;
            Eliminar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            Eliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            Eliminar.FlatStyle = FlatStyle.Flat;
            Eliminar.ForeColor = SystemColors.ButtonHighlight;
            Eliminar.Location = new Point(759, 515);
            Eliminar.Margin = new Padding(3, 4, 3, 4);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(86, 31);
            Eliminar.TabIndex = 1;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(74, 82, 90);
            btnEditar.FlatAppearance.BorderColor = Color.Crimson;
            btnEditar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnEditar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = SystemColors.ButtonHighlight;
            btnEditar.Location = new Point(646, 515);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(86, 31);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnPermisos
            // 
            btnPermisos.BackColor = Color.FromArgb(74, 82, 90);
            btnPermisos.FlatAppearance.BorderColor = Color.Crimson;
            btnPermisos.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnPermisos.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnPermisos.FlatStyle = FlatStyle.Flat;
            btnPermisos.ForeColor = SystemColors.ButtonHighlight;
            btnPermisos.Location = new Point(472, 515);
            btnPermisos.Margin = new Padding(3, 4, 3, 4);
            btnPermisos.Name = "btnPermisos";
            btnPermisos.Size = new Size(143, 31);
            btnPermisos.TabIndex = 3;
            btnPermisos.Text = "Cambiar Permisos";
            btnPermisos.UseVisualStyleBackColor = true;
            btnPermisos.Click += btnPermisos_Click;
            // 
            // comboPermisos
            // 
            comboPermisos.FormattingEnabled = true;
            comboPermisos.Location = new Point(472, 548);
            comboPermisos.Margin = new Padding(3, 4, 3, 4);
            comboPermisos.Name = "comboPermisos";
            comboPermisos.Size = new Size(142, 28);
            comboPermisos.TabIndex = 4;
            // 
            // GestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(comboPermisos);
            Controls.Add(btnPermisos);
            Controls.Add(btnEditar);
            Controls.Add(Eliminar);
            Controls.Add(dgvUsuarios);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GestionUsuarios";
            Text = "Usuarios";
            Load += GestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal DataGridView dgvUsuarios;
        internal Button Eliminar;
        internal Button btnEditar;
        internal Button btnPermisos;
        internal ComboBox comboPermisos;
    }
}