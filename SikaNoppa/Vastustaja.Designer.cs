namespace SikaNoppa
{
    partial class Vastustaja
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
            this.kaveriaVastaan = new System.Windows.Forms.Button();
            this.konettaVastaan = new System.Windows.Forms.Button();
            this.koneKonettaVastaan = new System.Windows.Forms.Button();
            this.peruuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pelaatko konetta vai kaveria vastaan, \r\nvai laitatko koneen pelaamaan konetta \r\nv" +
    "astaan?";
            // 
            // kaveriaVastaan
            // 
            this.kaveriaVastaan.Location = new System.Drawing.Point(12, 116);
            this.kaveriaVastaan.Name = "kaveriaVastaan";
            this.kaveriaVastaan.Size = new System.Drawing.Size(88, 36);
            this.kaveriaVastaan.TabIndex = 1;
            this.kaveriaVastaan.Text = "Kaveria vastaan";
            this.kaveriaVastaan.UseVisualStyleBackColor = true;
            this.kaveriaVastaan.Click += new System.EventHandler(this.kaveriaVastaan_Click);
            // 
            // konettaVastaan
            // 
            this.konettaVastaan.Location = new System.Drawing.Point(106, 116);
            this.konettaVastaan.Name = "konettaVastaan";
            this.konettaVastaan.Size = new System.Drawing.Size(75, 36);
            this.konettaVastaan.TabIndex = 2;
            this.konettaVastaan.Text = "Konetta vastaan";
            this.konettaVastaan.UseVisualStyleBackColor = true;
            this.konettaVastaan.Click += new System.EventHandler(this.konettaVastaan_Click);
            // 
            // koneKonettaVastaan
            // 
            this.koneKonettaVastaan.Location = new System.Drawing.Point(187, 116);
            this.koneKonettaVastaan.Name = "koneKonettaVastaan";
            this.koneKonettaVastaan.Size = new System.Drawing.Size(80, 36);
            this.koneKonettaVastaan.TabIndex = 3;
            this.koneKonettaVastaan.Text = "Kone konetta vastaan";
            this.koneKonettaVastaan.UseVisualStyleBackColor = true;
            this.koneKonettaVastaan.Click += new System.EventHandler(this.koneKonettaVastaan_Click);
            // 
            // peruuta
            // 
            this.peruuta.Location = new System.Drawing.Point(12, 158);
            this.peruuta.Name = "peruuta";
            this.peruuta.Size = new System.Drawing.Size(255, 39);
            this.peruuta.TabIndex = 4;
            this.peruuta.Text = "Peruuta";
            this.peruuta.UseVisualStyleBackColor = true;
            this.peruuta.Click += new System.EventHandler(this.peruuta_Click);
            // 
            // Vastustaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 209);
            this.Controls.Add(this.peruuta);
            this.Controls.Add(this.koneKonettaVastaan);
            this.Controls.Add(this.konettaVastaan);
            this.Controls.Add(this.kaveriaVastaan);
            this.Controls.Add(this.label1);
            this.Name = "Vastustaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vastustajan valinta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kaveriaVastaan;
        private System.Windows.Forms.Button konettaVastaan;
        private System.Windows.Forms.Button koneKonettaVastaan;
        private System.Windows.Forms.Button peruuta;
    }
}