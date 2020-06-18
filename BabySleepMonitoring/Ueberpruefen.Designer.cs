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
            this.TextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonStartMakierung = new System.Windows.Forms.Button();
            this.ButtonNeuMakierung = new System.Windows.Forms.Button();
            this.ButtonPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(55, 264);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(86, 29);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Visible = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(250, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(618, 406);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // TextBox
            // 
            this.TextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Location = new System.Drawing.Point(23, 406);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(205, 49);
            this.TextBox.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(38, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 111);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Für die Makierung des Bettrandes, setzen sie bitte 3 Punkte wie folgt:\r\n\r\n1. Link" +
    "s oben\r\n2. rechts oben\r\n3. rechts unten\r\n\r\n\r\n";
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ButtonStartMakierung
            // 
            this.ButtonStartMakierung.Location = new System.Drawing.Point(25, 185);
            this.ButtonStartMakierung.Name = "ButtonStartMakierung";
            this.ButtonStartMakierung.Size = new System.Drawing.Size(116, 29);
            this.ButtonStartMakierung.TabIndex = 5;
            this.ButtonStartMakierung.Text = "Start Makierung";
            this.ButtonStartMakierung.UseVisualStyleBackColor = true;
            this.ButtonStartMakierung.Visible = false;
            this.ButtonStartMakierung.Click += new System.EventHandler(this.ButtonStartMakierung_Click);
            // 
            // ButtonNeuMakierung
            // 
            this.ButtonNeuMakierung.Location = new System.Drawing.Point(25, 220);
            this.ButtonNeuMakierung.Name = "ButtonNeuMakierung";
            this.ButtonNeuMakierung.Size = new System.Drawing.Size(116, 29);
            this.ButtonNeuMakierung.TabIndex = 6;
            this.ButtonNeuMakierung.Text = "Neu Makierung";
            this.ButtonNeuMakierung.UseVisualStyleBackColor = true;
            this.ButtonNeuMakierung.Visible = false;
            this.ButtonNeuMakierung.Click += new System.EventHandler(this.ButtonNeuMakierung_Click);
            // 
            // ButtonPause
            // 
            this.ButtonPause.Location = new System.Drawing.Point(55, 299);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(86, 29);
            this.ButtonPause.TabIndex = 7;
            this.ButtonPause.Text = "Pause";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // Ueberpruefen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.ButtonNeuMakierung);
            this.Controls.Add(this.ButtonStartMakierung);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonStart);
            this.Name = "Ueberpruefen";
            this.Size = new System.Drawing.Size(918, 492);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonStartMakierung;
        private System.Windows.Forms.Button ButtonNeuMakierung;
        private System.Windows.Forms.Button ButtonPause;
    }
}
