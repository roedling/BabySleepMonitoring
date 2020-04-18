namespace BabySleepMonitoring
{
    partial class Bettrandmakierung
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBoxMakierung = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMakierung)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxMakierung
            // 
            this.PictureBoxMakierung.Location = new System.Drawing.Point(76, 60);
            this.PictureBoxMakierung.Name = "PictureBoxMakierung";
            this.PictureBoxMakierung.Size = new System.Drawing.Size(283, 219);
            this.PictureBoxMakierung.TabIndex = 0;
            this.PictureBoxMakierung.TabStop = false;
            // 
            // Bettrandmakierung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PictureBoxMakierung);
            this.Name = "Bettrandmakierung";
            this.Size = new System.Drawing.Size(697, 495);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMakierung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMakierung;
    }
}
