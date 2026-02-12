namespace RetaCantabria
{
    partial class Fichas
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
            components = new System.ComponentModel.Container();
            cbSeguridad = new CheckBox();
            cbUsuario = new CheckBox();
            cbOrganizacion = new CheckBox();
            button1 = new Button();
            label1 = new Label();
            imageList1 = new ImageList(components);
            pb_Seguridad = new PictureBox();
            pb_Usuario = new PictureBox();
            pb_Organizacion = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_Seguridad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Usuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_Organizacion).BeginInit();
            SuspendLayout();
            // 
            // cbSeguridad
            // 
            cbSeguridad.AutoSize = true;
            cbSeguridad.Location = new Point(47, 57);
            cbSeguridad.Margin = new Padding(3, 4, 3, 4);
            cbSeguridad.Name = "cbSeguridad";
            cbSeguridad.Size = new Size(158, 24);
            cbSeguridad.TabIndex = 0;
            cbSeguridad.Text = "Ficha de Seguridad";
            cbSeguridad.UseVisualStyleBackColor = true;
            // 
            // cbUsuario
            // 
            cbUsuario.AutoSize = true;
            cbUsuario.Location = new Point(47, 225);
            cbUsuario.Margin = new Padding(3, 4, 3, 4);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(140, 24);
            cbUsuario.TabIndex = 1;
            cbUsuario.Text = "Ficha de Usuario";
            cbUsuario.UseVisualStyleBackColor = true;
            // 
            // cbOrganizacion
            // 
            cbOrganizacion.AutoSize = true;
            cbOrganizacion.Location = new Point(47, 401);
            cbOrganizacion.Margin = new Padding(3, 4, 3, 4);
            cbOrganizacion.Name = "cbOrganizacion";
            cbOrganizacion.Size = new Size(178, 24);
            cbOrganizacion.TabIndex = 2;
            cbOrganizacion.Text = "Ficha de Organización";
            cbOrganizacion.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(74, 82, 90);
            button1.FlatAppearance.BorderColor = Color.Crimson;
            button1.FlatAppearance.MouseDownBackColor = Color.DimGray;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(398, 539);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Generar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 12);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 4;
            label1.Text = "Fichas Informativas";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pb_Seguridad
            // 
            pb_Seguridad.Location = new Point(639, 57);
            pb_Seguridad.Margin = new Padding(3, 4, 3, 4);
            pb_Seguridad.Name = "pb_Seguridad";
            pb_Seguridad.Size = new Size(210, 153);
            pb_Seguridad.TabIndex = 5;
            pb_Seguridad.TabStop = false;
            // 
            // pb_Usuario
            // 
            pb_Usuario.Location = new Point(639, 225);
            pb_Usuario.Margin = new Padding(3, 4, 3, 4);
            pb_Usuario.Name = "pb_Usuario";
            pb_Usuario.Size = new Size(210, 153);
            pb_Usuario.TabIndex = 6;
            pb_Usuario.TabStop = false;
            // 
            // pb_Organizacion
            // 
            pb_Organizacion.Location = new Point(639, 401);
            pb_Organizacion.Margin = new Padding(3, 4, 3, 4);
            pb_Organizacion.Name = "pb_Organizacion";
            pb_Organizacion.Size = new Size(210, 153);
            pb_Organizacion.TabIndex = 7;
            pb_Organizacion.TabStop = false;
            // 
            // Fichas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pb_Organizacion);
            Controls.Add(pb_Usuario);
            Controls.Add(pb_Seguridad);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(cbOrganizacion);
            Controls.Add(cbUsuario);
            Controls.Add(cbSeguridad);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Fichas";
            Text = "Fichas";
            ((System.ComponentModel.ISupportInitialize)pb_Seguridad).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Usuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_Organizacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbSeguridad;
        private CheckBox cbUsuario;
        private CheckBox cbOrganizacion;
        private Button button1;
        private Label label1;
        private ImageList imageList1;
        private PictureBox pb_Seguridad;
        private PictureBox pb_Usuario;
        private PictureBox pb_Organizacion;
    }
}