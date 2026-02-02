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
            lblNombre.Location = new Point(84, 13);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(106, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de la ruta:";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(84, 171);
            lbl.Name = "lbl";
            lbl.Size = new Size(58, 15);
            lbl.TabIndex = 1;
            lbl.Text = "Duración:";
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Location = new Point(84, 94);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(85, 15);
            lblDistancia.TabIndex = 2;
            lblDistancia.Text = "Distancia total:";
            // 
            // lblTemporada
            // 
            lblTemporada.AutoSize = true;
            lblTemporada.Location = new Point(84, 326);
            lblTemporada.Name = "lblTemporada";
            lblTemporada.Size = new Size(146, 15);
            lblTemporada.TabIndex = 4;
            lblTemporada.Text = "Temporada recomendada:";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(428, 171);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(96, 15);
            lblZona.TabIndex = 7;
            lblZona.Text = "Zona geográfica:";
            // 
            // lblRecomendaciones
            // 
            lblRecomendaciones.AutoSize = true;
            lblRecomendaciones.Location = new Point(428, 244);
            lblRecomendaciones.Name = "lblRecomendaciones";
            lblRecomendaciones.Size = new Size(163, 15);
            lblRecomendaciones.TabIndex = 8;
            lblRecomendaciones.Text = "Recomendaciones de equipo:";
            // 
            // comboTemporada
            // 
            comboTemporada.FormattingEnabled = true;
            comboTemporada.Location = new Point(92, 365);
            comboTemporada.Name = "comboTemporada";
            comboTemporada.Size = new Size(121, 23);
            comboTemporada.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(84, 49);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(185, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtDistancia
            // 
            txtDistancia.Location = new Point(84, 132);
            txtDistancia.Name = "txtDistancia";
            txtDistancia.Size = new Size(106, 23);
            txtDistancia.TabIndex = 11;
            // 
            // txtZona
            // 
            txtZona.Location = new Point(428, 198);
            txtZona.Name = "txtZona";
            txtZona.Size = new Size(145, 23);
            txtZona.TabIndex = 12;
            // 
            // txtRecomendaciones
            // 
            txtRecomendaciones.Location = new Point(428, 280);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.Size = new Size(259, 114);
            txtRecomendaciones.TabIndex = 13;
            // 
            // gbAccesibilidad
            // 
            gbAccesibilidad.Controls.Add(rbNoAccesibilidad);
            gbAccesibilidad.Controls.Add(rbSiAccesibilidad);
            gbAccesibilidad.Location = new Point(428, 10);
            gbAccesibilidad.Name = "gbAccesibilidad";
            gbAccesibilidad.Size = new Size(145, 59);
            gbAccesibilidad.TabIndex = 15;
            gbAccesibilidad.TabStop = false;
            gbAccesibilidad.Text = "Accesibilidad:";
            // 
            // rbNoAccesibilidad
            // 
            rbNoAccesibilidad.AutoSize = true;
            rbNoAccesibilidad.Location = new Point(73, 22);
            rbNoAccesibilidad.Name = "rbNoAccesibilidad";
            rbNoAccesibilidad.Size = new Size(41, 19);
            rbNoAccesibilidad.TabIndex = 1;
            rbNoAccesibilidad.TabStop = true;
            rbNoAccesibilidad.Text = "No";
            rbNoAccesibilidad.UseVisualStyleBackColor = true;
            // 
            // rbSiAccesibilidad
            // 
            rbSiAccesibilidad.AutoSize = true;
            rbSiAccesibilidad.Location = new Point(15, 22);
            rbSiAccesibilidad.Name = "rbSiAccesibilidad";
            rbSiAccesibilidad.Size = new Size(34, 19);
            rbSiAccesibilidad.TabIndex = 0;
            rbSiAccesibilidad.TabStop = true;
            rbSiAccesibilidad.Text = "Si";
            rbSiAccesibilidad.UseVisualStyleBackColor = true;
            // 
            // gbFamiliar
            // 
            gbFamiliar.Controls.Add(rbNoFamiliar);
            gbFamiliar.Controls.Add(rbSiFamiliar);
            gbFamiliar.Location = new Point(428, 91);
            gbFamiliar.Name = "gbFamiliar";
            gbFamiliar.Size = new Size(145, 61);
            gbFamiliar.TabIndex = 15;
            gbFamiliar.TabStop = false;
            gbFamiliar.Text = "Ruta Familiar:";
            // 
            // rbNoFamiliar
            // 
            rbNoFamiliar.AutoSize = true;
            rbNoFamiliar.Location = new Point(73, 22);
            rbNoFamiliar.Name = "rbNoFamiliar";
            rbNoFamiliar.Size = new Size(41, 19);
            rbNoFamiliar.TabIndex = 2;
            rbNoFamiliar.TabStop = true;
            rbNoFamiliar.Text = "No";
            rbNoFamiliar.UseVisualStyleBackColor = true;
            // 
            // rbSiFamiliar
            // 
            rbSiFamiliar.AutoSize = true;
            rbSiFamiliar.Location = new Point(15, 22);
            rbSiFamiliar.Name = "rbSiFamiliar";
            rbSiFamiliar.Size = new Size(34, 19);
            rbSiFamiliar.TabIndex = 2;
            rbSiFamiliar.TabStop = true;
            rbSiFamiliar.Text = "Si";
            rbSiFamiliar.UseVisualStyleBackColor = true;
            // 
            // gbClasificacion
            // 
            gbClasificacion.Controls.Add(rbLineal);
            gbClasificacion.Controls.Add(rbCircular);
            gbClasificacion.Location = new Point(84, 247);
            gbClasificacion.Name = "gbClasificacion";
            gbClasificacion.Size = new Size(200, 68);
            gbClasificacion.TabIndex = 17;
            gbClasificacion.TabStop = false;
            gbClasificacion.Text = "Clasificación:";
            // 
            // rbLineal
            // 
            rbLineal.AutoSize = true;
            rbLineal.Location = new Point(100, 32);
            rbLineal.Name = "rbLineal";
            rbLineal.Size = new Size(56, 19);
            rbLineal.TabIndex = 1;
            rbLineal.TabStop = true;
            rbLineal.Text = "Lineal";
            rbLineal.UseVisualStyleBackColor = true;
            // 
            // rbCircular
            // 
            rbCircular.AutoSize = true;
            rbCircular.Location = new Point(22, 32);
            rbCircular.Name = "rbCircular";
            rbCircular.Size = new Size(66, 19);
            rbCircular.TabIndex = 0;
            rbCircular.TabStop = true;
            rbCircular.Text = "Circular";
            rbCircular.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(612, 411);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 18;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // numericHoras
            // 
            numericHoras.Location = new Point(84, 199);
            numericHoras.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericHoras.Name = "numericHoras";
            numericHoras.Size = new Size(41, 23);
            numericHoras.TabIndex = 19;
            // 
            // numericMinutos
            // 
            numericMinutos.Location = new Point(142, 199);
            numericMinutos.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericMinutos.Name = "numericMinutos";
            numericMinutos.Size = new Size(41, 23);
            numericMinutos.TabIndex = 20;
            // 
            // numericSegundos
            // 
            numericSegundos.Location = new Point(199, 199);
            numericSegundos.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericSegundos.Name = "numericSegundos";
            numericSegundos.Size = new Size(41, 23);
            numericSegundos.TabIndex = 21;
            // 
            // btnGPX
            // 
            btnGPX.Location = new Point(428, 411);
            btnGPX.Name = "btnGPX";
            btnGPX.Size = new Size(114, 23);
            btnGPX.TabIndex = 22;
            btnGPX.Text = "Cargar desde GPX";
            btnGPX.UseVisualStyleBackColor = true;
            // 
            // lblDuracionHoras
            // 
            lblDuracionHoras.AutoSize = true;
            lblDuracionHoras.Location = new Point(127, 203);
            lblDuracionHoras.Name = "lblDuracionHoras";
            lblDuracionHoras.Size = new Size(10, 15);
            lblDuracionHoras.TabIndex = 23;
            lblDuracionHoras.Text = ":";
            // 
            // lblDuracionMins
            // 
            lblDuracionMins.AutoSize = true;
            lblDuracionMins.Location = new Point(186, 203);
            lblDuracionMins.Name = "lblDuracionMins";
            lblDuracionMins.Size = new Size(10, 15);
            lblDuracionMins.TabIndex = 24;
            lblDuracionMins.Text = ":";
            // 
            // CrearRuta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private ComboBox comboTemporada;
        private TextBox txtNombre;
        private TextBox txtDistancia;
        private TextBox txtZona;
        private TextBox txtRecomendaciones;
        private GroupBox gbAccesibilidad;
        private GroupBox gbFamiliar;
        private RadioButton rbNoAccesibilidad;
        private RadioButton rbSiAccesibilidad;
        private RadioButton rbNoFamiliar;
        private RadioButton rbSiFamiliar;
        private GroupBox gbClasificacion;
        private RadioButton rbLineal;
        private RadioButton rbCircular;
        private Button btnCrear;
        private NumericUpDown numericHoras;
        private NumericUpDown numericMinutos;
        private NumericUpDown numericSegundos;
        private Button btnGPX;
        private Label lblDuracionHoras;
        private Label lblDuracionMins;
    }
}