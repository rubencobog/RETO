namespace RetaCantabria
{
    partial class DetallesWaypoints
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
            lblWayPoint = new Label();
            dgvWayPoint = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvWayPoint).BeginInit();
            SuspendLayout();
            // 
            // lblWayPoint
            // 
            lblWayPoint.AutoSize = true;
            lblWayPoint.Location = new Point(36, 23);
            lblWayPoint.Name = "lblWayPoint";
            lblWayPoint.Size = new Size(125, 20);
            lblWayPoint.TabIndex = 0;
            lblWayPoint.Text = "Puntos de interés:";
            // 
            // dgvWayPoint
            // 
            dgvWayPoint.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWayPoint.Location = new Point(36, 58);
            dgvWayPoint.Name = "dgvWayPoint";
            dgvWayPoint.RowHeadersWidth = 51;
            dgvWayPoint.Size = new Size(721, 338);
            dgvWayPoint.TabIndex = 1;
            // 
            // DetallesWaypoints
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvWayPoint);
            Controls.Add(lblWayPoint);
            Name = "DetallesWaypoints";
            Text = "DetallesWaypoints";
            Load += DetallesWaypoints_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWayPoint).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWayPoint;
        private DataGridView dgvWayPoint;
    }
}