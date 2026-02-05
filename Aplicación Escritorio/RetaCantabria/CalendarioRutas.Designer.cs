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
            calendar.Location = new Point(44, 27);
            calendar.Name = "calendar";
            calendar.TabIndex = 0;
            calendar.DateChanged += calendar_DateChanged;
            // 
            // dgvRutaCalendar
            // 
            dgvRutaCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutaCalendar.Location = new Point(283, 61);
            dgvRutaCalendar.Name = "dgvRutaCalendar";
            dgvRutaCalendar.Size = new Size(457, 53);
            dgvRutaCalendar.TabIndex = 1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(614, 133);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(126, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar ruta del día";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnInsertarNueva
            // 
            btnInsertarNueva.Location = new Point(451, 133);
            btnInsertarNueva.Name = "btnInsertarNueva";
            btnInsertarNueva.Size = new Size(132, 23);
            btnInsertarNueva.TabIndex = 3;
            btnInsertarNueva.Text = "Añadir nueva ruta";
            btnInsertarNueva.UseVisualStyleBackColor = true;
            btnInsertarNueva.Click += btnInsertarNueva_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(283, 27);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 15);
            lblFecha.TabIndex = 4;
            // 
            // CalendarioRutas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFecha);
            Controls.Add(btnInsertarNueva);
            Controls.Add(btnEliminar);
            Controls.Add(dgvRutaCalendar);
            Controls.Add(calendar);
            Name = "CalendarioRutas";
            Text = "Calendario";
            ((System.ComponentModel.ISupportInitialize)dgvRutaCalendar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar calendar;
        private DataGridView dgvRutaCalendar;
        private Button btnEliminar;
        private Button btnInsertarNueva;
        private Label lblFecha;
    }
}