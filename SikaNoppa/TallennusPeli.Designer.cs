namespace SikaNoppa
{
    partial class TallennusPeli
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
            this.label1 = new System.Windows.Forms.Label();
            this.lopetaTallentamatta = new System.Windows.Forms.Button();
            this.tallennaPeli = new System.Windows.Forms.Button();
            this.peruuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Haluatko tallentaa pelin?";
            // 
            // lopetaTallentamatta
            // 
            this.lopetaTallentamatta.Location = new System.Drawing.Point(12, 96);
            this.lopetaTallentamatta.Name = "lopetaTallentamatta";
            this.lopetaTallentamatta.Size = new System.Drawing.Size(75, 39);
            this.lopetaTallentamatta.TabIndex = 1;
            this.lopetaTallentamatta.Text = "Lopeta tallentamatta";
            this.lopetaTallentamatta.UseVisualStyleBackColor = true;
            this.lopetaTallentamatta.Click += new System.EventHandler(this.lopetaTallentamatta_Click);
            // 
            // tallennaPeli
            // 
            this.tallennaPeli.Location = new System.Drawing.Point(102, 96);
            this.tallennaPeli.Name = "tallennaPeli";
            this.tallennaPeli.Size = new System.Drawing.Size(75, 39);
            this.tallennaPeli.TabIndex = 2;
            this.tallennaPeli.Text = "Tallenna\r\npeli";
            this.tallennaPeli.UseVisualStyleBackColor = true;
            this.tallennaPeli.Click += new System.EventHandler(this.tallennaPeli_Click);
            // 
            // peruuta
            // 
            this.peruuta.Location = new System.Drawing.Point(197, 96);
            this.peruuta.Name = "peruuta";
            this.peruuta.Size = new System.Drawing.Size(75, 39);
            this.peruuta.TabIndex = 3;
            this.peruuta.Text = "Takaisin peliin";
            this.peruuta.UseVisualStyleBackColor = true;
            this.peruuta.Click += new System.EventHandler(this.peruuta_Click);
            // 
            // TallennusPeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 166);
            this.Controls.Add(this.peruuta);
            this.Controls.Add(this.tallennaPeli);
            this.Controls.Add(this.lopetaTallentamatta);
            this.Controls.Add(this.label1);
            this.Name = "TallennusPeli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lopetus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lopetaTallentamatta;
        private System.Windows.Forms.Button tallennaPeli;
        private System.Windows.Forms.Button peruuta;
    }
}