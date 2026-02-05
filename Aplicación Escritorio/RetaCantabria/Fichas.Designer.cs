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
            cbSeguridad = new CheckBox();
            cbUsuario = new CheckBox();
            cbOrganizacion = new CheckBox();
            button1 = new Button();
            label1 = new Label();
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
            cbUsuario.Location = new Point(41, 191);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(113, 19);
            cbUsuario.TabIndex = 1;
            cbUsuario.Text = "Ficha de Usuario";
            cbUsuario.UseVisualStyleBackColor = true;
            // 
            // cbOrganizacion
            // 
            cbOrganizacion.AutoSize = true;
            cbOrganizacion.Location = new Point(41, 334);
            cbOrganizacion.Name = "cbOrganizacion";
            cbOrganizacion.Size = new Size(143, 19);
            cbOrganizacion.TabIndex = 2;
            cbOrganizacion.Text = "Ficha de Organización";
            cbOrganizacion.UseVisualStyleBackColor = true;
            cbOrganizacion.CheckedChanged += checkBox3_CheckedChanged;
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
            // Fichas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(cbOrganizacion);
            Controls.Add(cbUsuario);
            Controls.Add(cbSeguridad);
            Name = "Fichas";
            Text = "Fichas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbSeguridad;
        private CheckBox cbUsuario;
        private CheckBox cbOrganizacion;
        private Button button1;
        private Label label1;
    }
}