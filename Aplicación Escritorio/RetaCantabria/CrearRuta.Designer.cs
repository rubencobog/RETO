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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
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
            button1 = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(84, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 23);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(84, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(106, 23);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(428, 198);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(145, 23);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(428, 280);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(259, 114);
            textBox4.TabIndex = 13;
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
            // button1
            // 
            button1.Location = new Point(428, 411);
            button1.Name = "button1";
            button1.Size = new Size(114, 23);
            button1.TabIndex = 22;
            button1.Text = "Cargar desde GPX";
            button1.UseVisualStyleBackColor = true;
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
            Controls.Add(button1);
            Controls.Add(numericSegundos);
            Controls.Add(numericMinutos);
            Controls.Add(numericHoras);
            Controls.Add(btnCrear);
            Controls.Add(gbClasificacion);
            Controls.Add(gbAccesibilidad);
            Controls.Add(gbFamiliar);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
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
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
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
        private Button button1;
        private Label lblDuracionHoras;
        private Label lblDuracionMins;
    }
}