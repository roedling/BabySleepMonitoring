namespace BabySleepMonitoring
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOrdnerWählen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonOrdnerWählen
            // 
            this.ButtonOrdnerWählen.Location = new System.Drawing.Point(12, 12);
            this.ButtonOrdnerWählen.Name = "ButtonOrdnerWählen";
            this.ButtonOrdnerWählen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOrdnerWählen.TabIndex = 0;
            this.ButtonOrdnerWählen.Text = "Ordner";
            this.ButtonOrdnerWählen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 553);
            this.Controls.Add(this.ButtonOrdnerWählen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOrdnerWählen;
    }
}

