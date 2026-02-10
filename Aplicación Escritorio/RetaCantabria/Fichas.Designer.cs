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
            cbSeguridad.Location = new Point(41, 43);
            cbSeguridad.Name = "cbSeguridad";
            cbSeguridad.Size = new Size(126, 19);
            cbSeguridad.TabIndex = 0;
            cbSeguridad.Text = "Ficha de Seguridad";
            cbSeguridad.UseVisualStyleBackColor = true;
            // 
            // cbUsuario
            // 
            cbUsuario.AutoSize = true;
            cbUsuario.Location = new Point(41, 169);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(113, 19);
            cbUsuario.TabIndex = 1;
            cbUsuario.Text = "Ficha de Usuario";
            cbUsuario.UseVisualStyleBackColor = true;
            // 
            // cbOrganizacion
            // 
            cbOrganizacion.AutoSize = true;
            cbOrganizacion.Location = new Point(41, 301);
            cbOrganizacion.Name = "cbOrganizacion";
            cbOrganizacion.Size = new Size(143, 19);
            cbOrganizacion.TabIndex = 2;
            cbOrganizacion.Text = "Ficha de Organización";
            cbOrganizacion.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(348, 404);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 9);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
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
            pb_Seguridad.Location = new Point(559, 43);
            pb_Seguridad.Name = "pb_Seguridad";
            pb_Seguridad.Size = new Size(184, 115);
            pb_Seguridad.TabIndex = 5;
            pb_Seguridad.TabStop = false;
            // 
            // pb_Usuario
            // 
            pb_Usuario.Location = new Point(559, 169);
            pb_Usuario.Name = "pb_Usuario";
            pb_Usuario.Size = new Size(184, 115);
            pb_Usuario.TabIndex = 6;
            pb_Usuario.TabStop = false;
            // 
            // pb_Organizacion
            // 
            pb_Organizacion.Location = new Point(559, 301);
            pb_Organizacion.Name = "pb_Organizacion";
            pb_Organizacion.Size = new Size(184, 115);
            pb_Organizacion.TabIndex = 7;
            pb_Organizacion.TabStop = false;
            // 
            // Fichas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pb_Organizacion);
            Controls.Add(pb_Usuario);
            Controls.Add(pb_Seguridad);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(cbOrganizacion);
            Controls.Add(cbUsuario);
            Controls.Add(cbSeguridad);
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