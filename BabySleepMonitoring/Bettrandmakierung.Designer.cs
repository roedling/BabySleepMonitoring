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
            this.ButtonStartMakierung = new System.Windows.Forms.Button();
            this.ButtonNeuMakierung = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMakierung)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxMakierung
            // 
            this.PictureBoxMakierung.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PictureBoxMakierung.Dock = System.Windows.Forms.DockStyle.Right;
            this.PictureBoxMakierung.Location = new System.Drawing.Point(206, 0);
            this.PictureBoxMakierung.Name = "PictureBoxMakierung";
            this.PictureBoxMakierung.Size = new System.Drawing.Size(440, 273);
            this.PictureBoxMakierung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxMakierung.TabIndex = 0;
            this.PictureBoxMakierung.TabStop = false;
            this.PictureBoxMakierung.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMakierung_MouseClick);
            // 
            // ButtonStartMakierung
            // 
            this.ButtonStartMakierung.Location = new System.Drawing.Point(34, 173);
            this.ButtonStartMakierung.Name = "ButtonStartMakierung";
            this.ButtonStartMakierung.Size = new System.Drawing.Size(116, 29);
            this.ButtonStartMakierung.TabIndex = 1;
            this.ButtonStartMakierung.Text = "Start Makierung";
            this.ButtonStartMakierung.UseVisualStyleBackColor = true;
            this.ButtonStartMakierung.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonNeuMakierung
            // 
            this.ButtonNeuMakierung.Location = new System.Drawing.Point(34, 208);
            this.ButtonNeuMakierung.Name = "ButtonNeuMakierung";
            this.ButtonNeuMakierung.Size = new System.Drawing.Size(116, 29);
            this.ButtonNeuMakierung.TabIndex = 2;
            this.ButtonNeuMakierung.Text = "Neu Makierung";
            this.ButtonNeuMakierung.UseVisualStyleBackColor = true;
            this.ButtonNeuMakierung.Click += new System.EventHandler(this.ButtonNeuMakierung_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(34, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 141);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Setzen sie bitte 3 Punkte \r\nfür die Breite und die Dicke.\r\n\r\nMit Start \"Makierung" +
    "\" können sie die Makierung starten";
            this.textBox1.Visible = false;
            this.textBox1.VisibleChanged += new System.EventHandler(this.textBox1_VisibleChanged);
            // 
            // Bettrandmakierung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ButtonNeuMakierung);
            this.Controls.Add(this.ButtonStartMakierung);
            this.Controls.Add(this.PictureBoxMakierung);
            this.Name = "Bettrandmakierung";
            this.Size = new System.Drawing.Size(646, 273);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMakierung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMakierung;
        private System.Windows.Forms.Button ButtonStartMakierung;
        private System.Windows.Forms.Button ButtonNeuMakierung;
        private System.Windows.Forms.TextBox textBox1;
    }
}
