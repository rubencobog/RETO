namespace Reto
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_titulo = new Label();
            dataGridView1 = new DataGridView();
            btn_crear = new Button();
            btn_import = new Button();
            btn_validar = new Button();
            btn_calendarioRutas = new Button();
            btn_usuariosLista = new Button();
            btn_salir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_titulo
            // 
            lbl_titulo.AutoSize = true;
            lbl_titulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_titulo.Location = new Point(12, 9);
            lbl_titulo.Name = "lbl_titulo";
            lbl_titulo.Size = new Size(156, 30);
            lbl_titulo.TabIndex = 0;
            lbl_titulo.Text = "Reta Cantabria";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(571, 390);
            dataGridView1.TabIndex = 1;
            // 
            // btn_crear
            // 
            btn_crear.Location = new Point(639, 50);
            btn_crear.Name = "btn_crear";
            btn_crear.Size = new Size(113, 43);
            btn_crear.TabIndex = 2;
            btn_crear.Text = "Crear ruta";
            btn_crear.UseVisualStyleBackColor = true;
            // 
            // btn_import
            // 
            btn_import.Location = new Point(639, 99);
            btn_import.Name = "btn_import";
            btn_import.Size = new Size(113, 43);
            btn_import.TabIndex = 3;
            btn_import.Text = "Importar ruta";
            btn_import.UseVisualStyleBackColor = true;
            // 
            // btn_validar
            // 
            btn_validar.Location = new Point(639, 246);
            btn_validar.Name = "btn_validar";
            btn_validar.Size = new Size(113, 43);
            btn_validar.TabIndex = 4;
            btn_validar.Text = "Validar rutas";
            btn_validar.UseVisualStyleBackColor = true;
            // 
            // btn_calendarioRutas
            // 
            btn_calendarioRutas.Location = new Point(639, 148);
            btn_calendarioRutas.Name = "btn_calendarioRutas";
            btn_calendarioRutas.Size = new Size(113, 43);
            btn_calendarioRutas.TabIndex = 5;
            btn_calendarioRutas.Text = "Calendario rutas";
            btn_calendarioRutas.UseVisualStyleBackColor = true;
            // 
            // btn_usuariosLista
            // 
            btn_usuariosLista.Location = new Point(639, 197);
            btn_usuariosLista.Name = "btn_usuariosLista";
            btn_usuariosLista.Size = new Size(113, 43);
            btn_usuariosLista.TabIndex = 6;
            btn_usuariosLista.Text = "Lista de usuarios";
            btn_usuariosLista.UseVisualStyleBackColor = true;
            // 
            // btn_salir
            // 
            btn_salir.Location = new Point(713, 415);
            btn_salir.Name = "btn_salir";
            btn_salir.Size = new Size(75, 23);
            btn_salir.TabIndex = 7;
            btn_salir.Text = "Salir";
            btn_salir.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_salir);
            Controls.Add(btn_usuariosLista);
            Controls.Add(btn_calendarioRutas);
            Controls.Add(btn_validar);
            Controls.Add(btn_import);
            Controls.Add(btn_crear);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_titulo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_titulo;
        private DataGridView dataGridView1;
        private Button btn_crear;
        private Button btn_import;
        private Button btn_validar;
        private Button btn_calendarioRutas;
        private Button btn_usuariosLista;
        private Button btn_salir;
    }
}
