namespace RetaCantabria
{
    partial class CalendarioRutas
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
            calendar = new MonthCalendar();
            dgvRutaCalendar = new DataGridView();
            btnEliminar = new Button();
            btnInsertarNueva = new Button();
            lblFecha = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRutaCalendar).BeginInit();
            SuspendLayout();
            // 
            // calendar
            // 
            calendar.Location = new Point(143, 36);
            calendar.Margin = new Padding(10, 12, 10, 12);
            calendar.Name = "calendar";
            calendar.TabIndex = 0;
            calendar.TitleBackColor = SystemColors.ButtonShadow;
            calendar.DateSelected += calendar_DateSelected;
            // 
            // dgvRutaCalendar
            // 
            dgvRutaCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutaCalendar.Location = new Point(523, 81);
            dgvRutaCalendar.Margin = new Padding(3, 4, 3, 4);
            dgvRutaCalendar.Name = "dgvRutaCalendar";
            dgvRutaCalendar.RowHeadersWidth = 51;
            dgvRutaCalendar.Size = new Size(330, 321);
            dgvRutaCalendar.TabIndex = 1;
            dgvRutaCalendar.CellDoubleClick += dgvRutaCalendar_CellDoubleClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(74, 82, 90);
            btnEliminar.FlatAppearance.BorderColor = Color.Crimson;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = SystemColors.ButtonHighlight;
            btnEliminar.Location = new Point(710, 436);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(144, 31);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar ruta del día";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnInsertarNueva
            // 
            btnInsertarNueva.BackColor = Color.FromArgb(74, 82, 90);
            btnInsertarNueva.FlatAppearance.BorderColor = Color.Crimson;
            btnInsertarNueva.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnInsertarNueva.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnInsertarNueva.FlatStyle = FlatStyle.Flat;
            btnInsertarNueva.ForeColor = SystemColors.ButtonHighlight;
            btnInsertarNueva.Location = new Point(523, 436);
            btnInsertarNueva.Margin = new Padding(3, 4, 3, 4);
            btnInsertarNueva.Name = "btnInsertarNueva";
            btnInsertarNueva.Size = new Size(151, 31);
            btnInsertarNueva.TabIndex = 3;
            btnInsertarNueva.Text = "Añadir nueva ruta";
            btnInsertarNueva.UseVisualStyleBackColor = true;
            btnInsertarNueva.Click += btnInsertarNueva_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(523, 36);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 20);
            lblFecha.TabIndex = 4;
            // 
            // CalendarioRutas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(914, 600);
            Controls.Add(lblFecha);
            Controls.Add(btnInsertarNueva);
            Controls.Add(btnEliminar);
            Controls.Add(dgvRutaCalendar);
            Controls.Add(calendar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CalendarioRutas";
            Text = "Calendario";
            ((System.ComponentModel.ISupportInitialize)dgvRutaCalendar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInsertarNueva;
        internal MonthCalendar calendar;
        internal DataGridView dgvRutaCalendar;
        internal Button btnEliminar;
        internal Label lblFecha;
    }
}