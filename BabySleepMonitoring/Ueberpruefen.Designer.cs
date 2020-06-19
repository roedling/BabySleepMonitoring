namespace BabySleepMonitoring
{
    partial class Ueberpruefen
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
            this.ButtonStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonNeuMakierung = new System.Windows.Forms.Button();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.ButtonBeenden = new System.Windows.Forms.Button();
            this.ButtonNeustart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(57, 58);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(100, 31);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Visible = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(212, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(635, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 97);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 175);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Zur Festlegung des Bereiches, in welchem sich Ihr Kind befinden darf, ist wie fol" +
    "gt vorzugehen: \r\n\r\n1. Eckpunkt links oben \r\n2. Eckpunkt rechts oben \r\n3. Eckpunk" +
    "t rechts unten \r\n";
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ButtonNeuMakierung
            // 
            this.ButtonNeuMakierung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonNeuMakierung.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNeuMakierung.Location = new System.Drawing.Point(37, 304);
            this.ButtonNeuMakierung.Name = "ButtonNeuMakierung";
            this.ButtonNeuMakierung.Size = new System.Drawing.Size(135, 31);
            this.ButtonNeuMakierung.TabIndex = 6;
            this.ButtonNeuMakierung.Text = "Makierung löschen\r\n";
            this.ButtonNeuMakierung.UseVisualStyleBackColor = true;
            this.ButtonNeuMakierung.Visible = false;
            this.ButtonNeuMakierung.Click += new System.EventHandler(this.ButtonNeuMakierung_Click);
            // 
            // ButtonPause
            // 
            this.ButtonPause.Location = new System.Drawing.Point(57, 95);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(100, 31);
            this.ButtonPause.TabIndex = 7;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Visible = false;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // ButtonBeenden
            // 
            this.ButtonBeenden.Location = new System.Drawing.Point(124, 353);
            this.ButtonBeenden.Name = "ButtonBeenden";
            this.ButtonBeenden.Size = new System.Drawing.Size(100, 31);
            this.ButtonBeenden.TabIndex = 8;
            this.ButtonBeenden.Text = "Beenden";
            this.ButtonBeenden.UseVisualStyleBackColor = true;
            this.ButtonBeenden.Visible = false;
            this.ButtonBeenden.Click += new System.EventHandler(this.ButtonBeenden_Click);
            // 
            // ButtonNeustart
            // 
            this.ButtonNeustart.Location = new System.Drawing.Point(18, 353);
            this.ButtonNeustart.Name = "ButtonNeustart";
            this.ButtonNeustart.Size = new System.Drawing.Size(100, 31);
            this.ButtonNeustart.TabIndex = 9;
            this.ButtonNeustart.Text = "Neustart";
            this.ButtonNeustart.UseVisualStyleBackColor = true;
            this.ButtonNeustart.Visible = false;
            // 
            // Ueberpruefen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.ButtonNeustart);
            this.Controls.Add(this.ButtonBeenden);
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.ButtonNeuMakierung);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonStart);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Ueberpruefen";
            this.Size = new System.Drawing.Size(859, 494);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonNeuMakierung;
        private System.Windows.Forms.Button ButtonPause;
        private System.Windows.Forms.Button ButtonBeenden;
        private System.Windows.Forms.Button ButtonNeustart;
    }
}
