namespace Reto
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
            lbl_nombre = new Label();
            lbl_clasificacion = new Label();
            lbl_riesgo = new Label();
            lbl_esfuerzo = new Label();
            lbl_terreno = new Label();
            lbl_indicaciones = new Label();
            lbl_actividad = new Label();
            lbl_temporada = new Label();
            lbl_accesibilidad = new Label();
            lbl_familiar = new Label();
            lbl_estado = new Label();
            lbl_equipamiento = new Label();
            lbl_zona = new Label();
            SuspendLayout();
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(37, 23);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(103, 15);
            lbl_nombre.TabIndex = 0;
            lbl_nombre.Text = "Nombre de la ruta";
            // 
            // lbl_clasificacion
            // 
            lbl_clasificacion.AutoSize = true;
            lbl_clasificacion.Location = new Point(560, 95);
            lbl_clasificacion.Name = "lbl_clasificacion";
            lbl_clasificacion.Size = new Size(74, 15);
            lbl_clasificacion.TabIndex = 5;
            lbl_clasificacion.Text = "Clasificación";
            // 
            // lbl_riesgo
            // 
            lbl_riesgo.AutoSize = true;
            lbl_riesgo.Location = new Point(37, 95);
            lbl_riesgo.Name = "lbl_riesgo";
            lbl_riesgo.Size = new Size(85, 15);
            lbl_riesgo.TabIndex = 6;
            lbl_riesgo.Text = "Nivel de riesgo";
            // 
            // lbl_esfuerzo
            // 
            lbl_esfuerzo.AutoSize = true;
            lbl_esfuerzo.Location = new Point(37, 146);
            lbl_esfuerzo.Name = "lbl_esfuerzo";
            lbl_esfuerzo.Size = new Size(97, 15);
            lbl_esfuerzo.TabIndex = 7;
            lbl_esfuerzo.Text = "Nivel de esfuerzo";
            // 
            // lbl_terreno
            // 
            lbl_terreno.AutoSize = true;
            lbl_terreno.Location = new Point(236, 146);
            lbl_terreno.Name = "lbl_terreno";
            lbl_terreno.Size = new Size(88, 15);
            lbl_terreno.TabIndex = 8;
            lbl_terreno.Text = "Tipo de terreno";
            // 
            // lbl_indicaciones
            // 
            lbl_indicaciones.AutoSize = true;
            lbl_indicaciones.Location = new Point(403, 146);
            lbl_indicaciones.Name = "lbl_indicaciones";
            lbl_indicaciones.Size = new Size(73, 15);
            lbl_indicaciones.TabIndex = 9;
            lbl_indicaciones.Text = "Indicaciones";
            // 
            // lbl_actividad
            // 
            lbl_actividad.AutoSize = true;
            lbl_actividad.Location = new Point(560, 146);
            lbl_actividad.Name = "lbl_actividad";
            lbl_actividad.Size = new Size(98, 15);
            lbl_actividad.TabIndex = 10;
            lbl_actividad.Text = "Tipo de actividad";
            // 
            // lbl_temporada
            // 
            lbl_temporada.AutoSize = true;
            lbl_temporada.Location = new Point(204, 200);
            lbl_temporada.Name = "lbl_temporada";
            lbl_temporada.Size = new Size(143, 15);
            lbl_temporada.TabIndex = 13;
            lbl_temporada.Text = "Temporada recomendada";
            // 
            // lbl_accesibilidad
            // 
            lbl_accesibilidad.AutoSize = true;
            lbl_accesibilidad.Location = new Point(378, 200);
            lbl_accesibilidad.Name = "lbl_accesibilidad";
            lbl_accesibilidad.Size = new Size(155, 15);
            lbl_accesibilidad.TabIndex = 14;
            lbl_accesibilidad.Text = "Accesibilidad e inclusividad ";
            // 
            // lbl_familiar
            // 
            lbl_familiar.AutoSize = true;
            lbl_familiar.Location = new Point(549, 200);
            lbl_familiar.Name = "lbl_familiar";
            lbl_familiar.Size = new Size(74, 15);
            lbl_familiar.TabIndex = 15;
            lbl_familiar.Text = "Ruta familiar";
            // 
            // lbl_estado
            // 
            lbl_estado.AutoSize = true;
            lbl_estado.Location = new Point(210, 262);
            lbl_estado.Name = "lbl_estado";
            lbl_estado.Size = new Size(94, 15);
            lbl_estado.TabIndex = 17;
            lbl_estado.Text = "Estado de la ruta";
            // 
            // lbl_equipamiento
            // 
            lbl_equipamiento.AutoSize = true;
            lbl_equipamiento.Location = new Point(346, 262);
            lbl_equipamiento.Name = "lbl_equipamiento";
            lbl_equipamiento.Size = new Size(277, 15);
            lbl_equipamiento.TabIndex = 18;
            lbl_equipamiento.Text = "Recomendaciones sobre equipamiento y seguridad";
            // 
            // lbl_zona
            // 
            lbl_zona.AutoSize = true;
            lbl_zona.Location = new Point(560, 369);
            lbl_zona.Name = "lbl_zona";
            lbl_zona.Size = new Size(93, 15);
            lbl_zona.TabIndex = 19;
            lbl_zona.Text = "Zona geografica";
            // 
            // CrearRuta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_zona);
            Controls.Add(lbl_equipamiento);
            Controls.Add(lbl_estado);
            Controls.Add(lbl_familiar);
            Controls.Add(lbl_accesibilidad);
            Controls.Add(lbl_temporada);
            Controls.Add(lbl_actividad);
            Controls.Add(lbl_indicaciones);
            Controls.Add(lbl_terreno);
            Controls.Add(lbl_esfuerzo);
            Controls.Add(lbl_riesgo);
            Controls.Add(lbl_clasificacion);
            Controls.Add(lbl_nombre);
            Name = "CrearRuta";
            Text = "CrearRuta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_nombre;
        private Label lbl_clasificacion;
        private Label lbl_riesgo;
        private Label lbl_esfuerzo;
        private Label lbl_terreno;
        private Label lbl_indicaciones;
        private Label lbl_actividad;
        private Label lbl_temporada;
        private Label lbl_accesibilidad;
        private Label lbl_familiar;
        private Label lbl_estado;
        private Label lbl_equipamiento;
        private Label lbl_zona;
    }
}