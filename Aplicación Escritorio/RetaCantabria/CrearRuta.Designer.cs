namespace RetaCantabria
{
    partial class CrearRuta
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
            lblNombre = new Label();
            lbl = new Label();
            lblDistancia = new Label();
            lblTemporada = new Label();
            lblZona = new Label();
            lblRecomendaciones = new Label();
            comboTemporada = new ComboBox();
            txtNombre = new TextBox();
            txtDistancia = new TextBox();
            txtZona = new TextBox();
            txtRecomendaciones = new TextBox();
            gbAccesibilidad = new GroupBox();
            rbNoAccesibilidad = new RadioButton();
            rbSiAccesibilidad = new RadioButton();
            gbFamiliar = new GroupBox();
            rbNoFamiliar = new RadioButton();
            rbSiFamiliar = new RadioButton();
            gbClasificacion = new GroupBox();
            rbLineal = new RadioButton();
            rbCircular = new RadioButton();
            btnCrear = new Button();
            numericHoras = new NumericUpDown();
            numericMinutos = new NumericUpDown();
            numericSegundos = new NumericUpDown();
            btnGPX = new Button();
            lblDuracionHoras = new Label();
            lblDuracionMins = new Label();
            gbAccesibilidad.SuspendLayout();
            gbFamiliar.SuspendLayout();
            gbClasificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericHoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMinutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSegundos).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(96, 17);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(134, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de la ruta:";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(96, 228);
            lbl.Name = "lbl";
            lbl.Size = new Size(72, 20);
            lbl.TabIndex = 1;
            lbl.Text = "Duración:";
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Location = new Point(96, 125);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(108, 20);
            lblDistancia.TabIndex = 2;
            lblDistancia.Text = "Distancia total:";
            // 
            // lblTemporada
            // 
            lblTemporada.AutoSize = true;
            lblTemporada.Location = new Point(96, 435);
            lblTemporada.Name = "lblTemporada";
            lblTemporada.Size = new Size(184, 20);
            lblTemporada.TabIndex = 4;
            lblTemporada.Text = "Temporada recomendada:";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(489, 228);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(122, 20);
            lblZona.TabIndex = 7;
            lblZona.Text = "Zona geográfica:";
            // 
            // lblRecomendaciones
            // 
            lblRecomendaciones.AutoSize = true;
            lblRecomendaciones.Location = new Point(489, 325);
            lblRecomendaciones.Name = "lblRecomendaciones";
            lblRecomendaciones.Size = new Size(205, 20);
            lblRecomendaciones.TabIndex = 8;
            lblRecomendaciones.Text = "Recomendaciones de equipo:";
            // 
            // comboTemporada
            // 
            comboTemporada.FormattingEnabled = true;
            comboTemporada.Location = new Point(105, 487);
            comboTemporada.Margin = new Padding(3, 4, 3, 4);
            comboTemporada.Name = "comboTemporada";
            comboTemporada.Size = new Size(138, 28);
            comboTemporada.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(96, 65);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(211, 27);
            txtNombre.TabIndex = 10;
            // 
            // txtDistancia
            // 
            txtDistancia.Location = new Point(96, 176);
            txtDistancia.Margin = new Padding(3, 4, 3, 4);
            txtDistancia.Name = "txtDistancia";
            txtDistancia.Size = new Size(121, 27);
            txtDistancia.TabIndex = 11;
            // 
            // txtZona
            // 
            txtZona.Location = new Point(489, 264);
            txtZona.Margin = new Padding(3, 4, 3, 4);
            txtZona.Name = "txtZona";
            txtZona.Size = new Size(165, 27);
            txtZona.TabIndex = 12;
            // 
            // txtRecomendaciones
            // 
            txtRecomendaciones.Location = new Point(489, 373);
            txtRecomendaciones.Margin = new Padding(3, 4, 3, 4);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.Size = new Size(295, 151);
            txtRecomendaciones.TabIndex = 13;
            // 
            // gbAccesibilidad
            // 
            gbAccesibilidad.Controls.Add(rbNoAccesibilidad);
            gbAccesibilidad.Controls.Add(rbSiAccesibilidad);
            gbAccesibilidad.Location = new Point(489, 13);
            gbAccesibilidad.Margin = new Padding(3, 4, 3, 4);
            gbAccesibilidad.Name = "gbAccesibilidad";
            gbAccesibilidad.Padding = new Padding(3, 4, 3, 4);
            gbAccesibilidad.Size = new Size(166, 79);
            gbAccesibilidad.TabIndex = 15;
            gbAccesibilidad.TabStop = false;
            gbAccesibilidad.Text = "Accesibilidad:";
            // 
            // rbNoAccesibilidad
            // 
            rbNoAccesibilidad.AutoSize = true;
            rbNoAccesibilidad.Location = new Point(83, 29);
            rbNoAccesibilidad.Margin = new Padding(3, 4, 3, 4);
            rbNoAccesibilidad.Name = "rbNoAccesibilidad";
            rbNoAccesibilidad.Size = new Size(50, 24);
            rbNoAccesibilidad.TabIndex = 1;
            rbNoAccesibilidad.TabStop = true;
            rbNoAccesibilidad.Text = "No";
            rbNoAccesibilidad.UseVisualStyleBackColor = true;
            // 
            // rbSiAccesibilidad
            // 
            rbSiAccesibilidad.AutoSize = true;
            rbSiAccesibilidad.Location = new Point(17, 29);
            rbSiAccesibilidad.Margin = new Padding(3, 4, 3, 4);
            rbSiAccesibilidad.Name = "rbSiAccesibilidad";
            rbSiAccesibilidad.Size = new Size(42, 24);
            rbSiAccesibilidad.TabIndex = 0;
            rbSiAccesibilidad.TabStop = true;
            rbSiAccesibilidad.Text = "Si";
            rbSiAccesibilidad.UseVisualStyleBackColor = true;
            // 
            // gbFamiliar
            // 
            gbFamiliar.Controls.Add(rbNoFamiliar);
            gbFamiliar.Controls.Add(rbSiFamiliar);
            gbFamiliar.Location = new Point(489, 121);
            gbFamiliar.Margin = new Padding(3, 4, 3, 4);
            gbFamiliar.Name = "gbFamiliar";
            gbFamiliar.Padding = new Padding(3, 4, 3, 4);
            gbFamiliar.Size = new Size(166, 81);
            gbFamiliar.TabIndex = 15;
            gbFamiliar.TabStop = false;
            gbFamiliar.Text = "Ruta Familiar:";
            // 
            // rbNoFamiliar
            // 
            rbNoFamiliar.AutoSize = true;
            rbNoFamiliar.Location = new Point(83, 29);
            rbNoFamiliar.Margin = new Padding(3, 4, 3, 4);
            rbNoFamiliar.Name = "rbNoFamiliar";
            rbNoFamiliar.Size = new Size(50, 24);
            rbNoFamiliar.TabIndex = 2;
            rbNoFamiliar.TabStop = true;
            rbNoFamiliar.Text = "No";
            rbNoFamiliar.UseVisualStyleBackColor = true;
            // 
            // rbSiFamiliar
            // 
            rbSiFamiliar.AutoSize = true;
            rbSiFamiliar.Location = new Point(17, 29);
            rbSiFamiliar.Margin = new Padding(3, 4, 3, 4);
            rbSiFamiliar.Name = "rbSiFamiliar";
            rbSiFamiliar.Size = new Size(42, 24);
            rbSiFamiliar.TabIndex = 2;
            rbSiFamiliar.TabStop = true;
            rbSiFamiliar.Text = "Si";
            rbSiFamiliar.UseVisualStyleBackColor = true;
            // 
            // gbClasificacion
            // 
            gbClasificacion.Controls.Add(rbLineal);
            gbClasificacion.Controls.Add(rbCircular);
            gbClasificacion.Location = new Point(96, 329);
            gbClasificacion.Margin = new Padding(3, 4, 3, 4);
            gbClasificacion.Name = "gbClasificacion";
            gbClasificacion.Padding = new Padding(3, 4, 3, 4);
            gbClasificacion.Size = new Size(229, 91);
            gbClasificacion.TabIndex = 17;
            gbClasificacion.TabStop = false;
            gbClasificacion.Text = "Clasificación:";
            // 
            // rbLineal
            // 
            rbLineal.AutoSize = true;
            rbLineal.Location = new Point(114, 43);
            rbLineal.Margin = new Padding(3, 4, 3, 4);
            rbLineal.Name = "rbLineal";
            rbLineal.Size = new Size(69, 24);
            rbLineal.TabIndex = 1;
            rbLineal.TabStop = true;
            rbLineal.Text = "Lineal";
            rbLineal.UseVisualStyleBackColor = true;
            // 
            // rbCircular
            // 
            rbCircular.AutoSize = true;
            rbCircular.Location = new Point(25, 43);
            rbCircular.Margin = new Padding(3, 4, 3, 4);
            rbCircular.Name = "rbCircular";
            rbCircular.Size = new Size(80, 24);
            rbCircular.TabIndex = 0;
            rbCircular.TabStop = true;
            rbCircular.Text = "Circular";
            rbCircular.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(74, 82, 90);
            btnCrear.FlatAppearance.BorderColor = Color.Crimson;
            btnCrear.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnCrear.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.ForeColor = SystemColors.ButtonHighlight;
            btnCrear.Location = new Point(699, 548);
            btnCrear.Margin = new Padding(3, 4, 3, 4);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(86, 31);
            btnCrear.TabIndex = 18;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // numericHoras
            // 
            numericHoras.Location = new Point(96, 265);
            numericHoras.Margin = new Padding(3, 4, 3, 4);
            numericHoras.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericHoras.Name = "numericHoras";
            numericHoras.Size = new Size(47, 27);
            numericHoras.TabIndex = 19;
            // 
            // numericMinutos
            // 
            numericMinutos.Location = new Point(162, 265);
            numericMinutos.Margin = new Padding(3, 4, 3, 4);
            numericMinutos.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericMinutos.Name = "numericMinutos";
            numericMinutos.Size = new Size(47, 27);
            numericMinutos.TabIndex = 20;
            // 
            // numericSegundos
            // 
            numericSegundos.Location = new Point(227, 265);
            numericSegundos.Margin = new Padding(3, 4, 3, 4);
            numericSegundos.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericSegundos.Name = "numericSegundos";
            numericSegundos.Size = new Size(47, 27);
            numericSegundos.TabIndex = 21;
            // 
            // btnGPX
            // 
            btnGPX.BackColor = Color.FromArgb(74, 82, 90);
            btnGPX.FlatAppearance.BorderColor = Color.Crimson;
            btnGPX.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnGPX.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnGPX.FlatStyle = FlatStyle.Flat;
            btnGPX.ForeColor = SystemColors.ButtonHighlight;
            btnGPX.Location = new Point(489, 548);
            btnGPX.Margin = new Padding(3, 4, 3, 4);
            btnGPX.Name = "btnGPX";
            btnGPX.Size = new Size(147, 31);
            btnGPX.TabIndex = 22;
            btnGPX.Text = "Cargar desde GPX";
            btnGPX.UseVisualStyleBackColor = false;
            btnGPX.Click += btnGPX_Click;
            // 
            // lblDuracionHoras
            // 
            lblDuracionHoras.AutoSize = true;
            lblDuracionHoras.Location = new Point(145, 271);
            lblDuracionHoras.Name = "lblDuracionHoras";
            lblDuracionHoras.Size = new Size(12, 20);
            lblDuracionHoras.TabIndex = 23;
            lblDuracionHoras.Text = ":";
            // 
            // lblDuracionMins
            // 
            lblDuracionMins.AutoSize = true;
            lblDuracionMins.Location = new Point(213, 271);
            lblDuracionMins.Name = "lblDuracionMins";
            lblDuracionMins.Size = new Size(12, 20);
            lblDuracionMins.TabIndex = 24;
            lblDuracionMins.Text = ":";
            // 
            // CrearRuta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(lblDuracionMins);
            Controls.Add(lblDuracionHoras);
            Controls.Add(btnGPX);
            Controls.Add(numericSegundos);
            Controls.Add(numericMinutos);
            Controls.Add(numericHoras);
            Controls.Add(btnCrear);
            Controls.Add(gbClasificacion);
            Controls.Add(gbAccesibilidad);
            Controls.Add(gbFamiliar);
            Controls.Add(txtRecomendaciones);
            Controls.Add(txtZona);
            Controls.Add(txtDistancia);
            Controls.Add(txtNombre);
            Controls.Add(comboTemporada);
            Controls.Add(lblRecomendaciones);
            Controls.Add(lblZona);
            Controls.Add(lblTemporada);
            Controls.Add(lblDistancia);
            Controls.Add(lbl);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CrearRuta";
            Text = "CrearRuta";
            gbAccesibilidad.ResumeLayout(false);
            gbAccesibilidad.PerformLayout();
            gbFamiliar.ResumeLayout(false);
            gbFamiliar.PerformLayout();
            gbClasificacion.ResumeLayout(false);
            gbClasificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericHoras).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMinutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSegundos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lbl;
        private Label lblDistancia;
        private Label lblClasificacion;
        private Label lblTemporada;
        private Label lblAccesibilidad;
        private Label lblFamiliar;
        private Label lblZona;
        private Label lblRecomendaciones;
        private Button btnGPX;
        private Label lblDuracionHoras;
        private Label lblDuracionMins;
        internal TextBox txtNombre;
        internal TextBox txtDistancia;
        internal NumericUpDown numericHoras;
        internal NumericUpDown numericMinutos;
        internal NumericUpDown numericSegundos;
        internal ComboBox comboTemporada;
        internal TextBox txtZona;
        internal TextBox txtRecomendaciones;
        internal GroupBox gbAccesibilidad;
        internal GroupBox gbFamiliar;
        internal GroupBox gbClasificacion;
        internal RadioButton rbNoAccesibilidad;
        internal RadioButton rbSiAccesibilidad;
        internal RadioButton rbNoFamiliar;
        internal RadioButton rbSiFamiliar;
        internal RadioButton rbLineal;
        internal RadioButton rbCircular;
        internal Button btnCrear;
    }
}