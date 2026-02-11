namespace RetaCantabria
{
    partial class DetallesRuta
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
            btnMapa = new Button();
            btnWaypoints = new Button();
            lblNombre = new Label();
            lblDistancia = new Label();
            lblDuracion = new Label();
            lblMedia = new Label();
            lblZona = new Label();
            lblClasificacion = new Label();
            checkFamiliar = new CheckBox();
            checkAccesible = new CheckBox();
            lblNom = new Label();
            lblMed = new Label();
            lblDist = new Label();
            lblZone = new Label();
            lblDur = new Label();
            lblClasi = new Label();
            SuspendLayout();
            // 
            // btnMapa
            // 
            btnMapa.BackColor = Color.FromArgb(74, 82, 90);
            btnMapa.FlatAppearance.BorderColor = Color.Crimson;
            btnMapa.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnMapa.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnMapa.FlatStyle = FlatStyle.Flat;
            btnMapa.ForeColor = SystemColors.ButtonHighlight;
            btnMapa.Location = new Point(237, 394);
            btnMapa.Name = "btnMapa";
            btnMapa.Size = new Size(173, 29);
            btnMapa.TabIndex = 0;
            btnMapa.Text = "Ver Mapa de la Ruta";
            btnMapa.UseVisualStyleBackColor = true;
            btnMapa.Click += btnMapa_Click;
            // 
            // btnWaypoints
            // 
            btnWaypoints.BackColor = Color.FromArgb(74, 82, 90);
            btnWaypoints.FlatAppearance.BorderColor = Color.Crimson;
            btnWaypoints.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnWaypoints.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnWaypoints.FlatStyle = FlatStyle.Flat;
            btnWaypoints.ForeColor = SystemColors.ButtonHighlight;
            btnWaypoints.Location = new Point(443, 394);
            btnWaypoints.Name = "btnWaypoints";
            btnWaypoints.Size = new Size(120, 29);
            btnWaypoints.TabIndex = 1;
            btnWaypoints.Text = "Ver WayPoints";
            btnWaypoints.UseVisualStyleBackColor = true;
            btnWaypoints.Click += btnWaypoints_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(124, 86);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(50, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "label1";
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Location = new Point(124, 197);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(50, 20);
            lblDistancia.TabIndex = 3;
            lblDistancia.Text = "label2";
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(124, 303);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(50, 20);
            lblDuracion.TabIndex = 4;
            lblDuracion.Text = "label3";
            // 
            // lblMedia
            // 
            lblMedia.AutoSize = true;
            lblMedia.Location = new Point(357, 86);
            lblMedia.Name = "lblMedia";
            lblMedia.Size = new Size(50, 20);
            lblMedia.TabIndex = 5;
            lblMedia.Text = "label4";
            // 
            // lblZona
            // 
            lblZona.AutoSize = true;
            lblZona.Location = new Point(357, 197);
            lblZona.Name = "lblZona";
            lblZona.Size = new Size(50, 20);
            lblZona.TabIndex = 6;
            lblZona.Text = "label5";
            // 
            // lblClasificacion
            // 
            lblClasificacion.AutoSize = true;
            lblClasificacion.Location = new Point(357, 303);
            lblClasificacion.Name = "lblClasificacion";
            lblClasificacion.Size = new Size(50, 20);
            lblClasificacion.TabIndex = 7;
            lblClasificacion.Text = "label6";
            // 
            // checkFamiliar
            // 
            checkFamiliar.AutoSize = true;
            checkFamiliar.Enabled = false;
            checkFamiliar.Location = new Point(582, 43);
            checkFamiliar.Name = "checkFamiliar";
            checkFamiliar.Size = new Size(83, 24);
            checkFamiliar.TabIndex = 8;
            checkFamiliar.Text = "Familiar";
            checkFamiliar.UseVisualStyleBackColor = true;
            // 
            // checkAccesible
            // 
            checkAccesible.AutoSize = true;
            checkAccesible.Enabled = false;
            checkAccesible.Location = new Point(582, 161);
            checkAccesible.Name = "checkAccesible";
            checkAccesible.Size = new Size(94, 24);
            checkAccesible.TabIndex = 9;
            checkAccesible.Text = "Accesible";
            checkAccesible.UseVisualStyleBackColor = true;
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(124, 43);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(67, 20);
            lblNom.TabIndex = 10;
            lblNom.Text = "Nombre:";
            // 
            // lblMed
            // 
            lblMed.AutoSize = true;
            lblMed.Location = new Point(357, 47);
            lblMed.Name = "lblMed";
            lblMed.Size = new Size(128, 20);
            lblMed.TabIndex = 11;
            lblMed.Text = "Media Valoracion:";
            // 
            // lblDist
            // 
            lblDist.AutoSize = true;
            lblDist.Location = new Point(124, 162);
            lblDist.Name = "lblDist";
            lblDist.Size = new Size(73, 20);
            lblDist.TabIndex = 12;
            lblDist.Text = "Distancia:";
            // 
            // lblZone
            // 
            lblZone.AutoSize = true;
            lblZone.Location = new Point(357, 161);
            lblZone.Name = "lblZone";
            lblZone.Size = new Size(123, 20);
            lblZone.TabIndex = 13;
            lblZone.Text = "Zona Geográfica:";
            // 
            // lblDur
            // 
            lblDur.AutoSize = true;
            lblDur.Location = new Point(124, 260);
            lblDur.Name = "lblDur";
            lblDur.Size = new Size(72, 20);
            lblDur.TabIndex = 14;
            lblDur.Text = "Duración:";
            // 
            // lblClasi
            // 
            lblClasi.AutoSize = true;
            lblClasi.Location = new Point(357, 260);
            lblClasi.Name = "lblClasi";
            lblClasi.Size = new Size(95, 20);
            lblClasi.TabIndex = 15;
            lblClasi.Text = "Clasificación:";
            // 
            // DetallesRuta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblClasi);
            Controls.Add(lblDur);
            Controls.Add(lblZone);
            Controls.Add(lblDist);
            Controls.Add(lblMed);
            Controls.Add(lblNom);
            Controls.Add(checkAccesible);
            Controls.Add(checkFamiliar);
            Controls.Add(lblClasificacion);
            Controls.Add(lblZona);
            Controls.Add(lblMedia);
            Controls.Add(lblDuracion);
            Controls.Add(lblDistancia);
            Controls.Add(lblNombre);
            Controls.Add(btnWaypoints);
            Controls.Add(btnMapa);
            Name = "DetallesRuta";
            Text = "DetallesRuta";
            Load += DetallesRuta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMapa;
        private Button btnWaypoints;
        private Label lblNombre;
        private Label lblDistancia;
        private Label lblDuracion;
        private Label lblMedia;
        private Label lblZona;
        private Label lblClasificacion;
        private CheckBox checkFamiliar;
        private CheckBox checkAccesible;
        private Label lblNom;
        private Label lblMed;
        private Label lblDist;
        private Label lblZone;
        private Label lblDur;
        private Label lblClasi;
    }
}