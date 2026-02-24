namespace RetaCantabria
{
    partial class MapaRuta
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
            webViewRuta = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewRuta).BeginInit();
            SuspendLayout();
            // 
            // webViewRuta
            // 
            webViewRuta.AllowExternalDrop = true;
            webViewRuta.CreationProperties = null;
            webViewRuta.DefaultBackgroundColor = Color.White;
            webViewRuta.Dock = DockStyle.Fill;
            webViewRuta.Location = new Point(0, 0);
            webViewRuta.Name = "webViewRuta";
            webViewRuta.Size = new Size(800, 450);
            webViewRuta.TabIndex = 0;
            webViewRuta.ZoomFactor = 1D;
            // 
            // MapaRuta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webViewRuta);
            Name = "MapaRuta";
            Text = "Mapa";
            ((System.ComponentModel.ISupportInitialize)webViewRuta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewRuta;
    }
}