namespace SikaNoppa
{
    partial class PelaajaKone
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
            this.peruuta = new System.Windows.Forms.Button();
            this.pelaaja2Teksti = new System.Windows.Forms.Label();
            this.pelaaja1Teksti = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.luoPeli = new System.Windows.Forms.Button();
            this.pelaaja1Kentta = new System.Windows.Forms.TextBox();
            this.kone1Kentta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // peruuta
            // 
            this.peruuta.Location = new System.Drawing.Point(149, 166);
            this.peruuta.Name = "peruuta";
            this.peruuta.Size = new System.Drawing.Size(68, 23);
            this.peruuta.TabIndex = 20;
            this.peruuta.Text = "Peruuta";
            this.peruuta.UseVisualStyleBackColor = true;
            this.peruuta.Click += new System.EventHandler(this.peruuta_Click);
            // 
            // pelaaja2Teksti
            // 
            this.pelaaja2Teksti.AutoSize = true;
            this.pelaaja2Teksti.Location = new System.Drawing.Point(158, 85);
            this.pelaaja2Teksti.Name = "pelaaja2Teksti";
            this.pelaaja2Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja2Teksti.TabIndex = 18;
            this.pelaaja2Teksti.Text = "Pelaaja 2";
            // 
            // pelaaja1Teksti
            // 
            this.pelaaja1Teksti.AutoSize = true;
            this.pelaaja1Teksti.Location = new System.Drawing.Point(40, 85);
            this.pelaaja1Teksti.Name = "pelaaja1Teksti";
            this.pelaaja1Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja1Teksti.TabIndex = 17;
            this.pelaaja1Teksti.Text = "Pelaaja 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Anna nimesi.";
            // 
            // luoPeli
            // 
            this.luoPeli.Location = new System.Drawing.Point(34, 166);
            this.luoPeli.Name = "luoPeli";
            this.luoPeli.Size = new System.Drawing.Size(65, 23);
            this.luoPeli.TabIndex = 12;
            this.luoPeli.Text = "Valmis";
            this.luoPeli.UseVisualStyleBackColor = true;
            this.luoPeli.Click += new System.EventHandler(this.luoPeli_Click);
            // 
            // pelaaja1Kentta
            // 
            this.pelaaja1Kentta.Location = new System.Drawing.Point(34, 101);
            this.pelaaja1Kentta.Name = "pelaaja1Kentta";
            this.pelaaja1Kentta.Size = new System.Drawing.Size(65, 20);
            this.pelaaja1Kentta.TabIndex = 11;
            // 
            // kone1Kentta
            // 
            this.kone1Kentta.AutoSize = true;
            this.kone1Kentta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kone1Kentta.Location = new System.Drawing.Point(158, 102);
            this.kone1Kentta.Name = "kone1Kentta";
            this.kone1Kentta.Size = new System.Drawing.Size(53, 17);
            this.kone1Kentta.TabIndex = 21;
            this.kone1Kentta.Text = "Kone 1";
            // 
            // PelaajaKone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 221);
            this.Controls.Add(this.kone1Kentta);
            this.Controls.Add(this.peruuta);
            this.Controls.Add(this.pelaaja2Teksti);
            this.Controls.Add(this.pelaaja1Teksti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.luoPeli);
            this.Controls.Add(this.pelaaja1Kentta);
            this.Name = "PelaajaKone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sikanoppa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button peruuta;
        private System.Windows.Forms.Label pelaaja2Teksti;
        private System.Windows.Forms.Label pelaaja1Teksti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button luoPeli;
        private System.Windows.Forms.TextBox pelaaja1Kentta;
        private System.Windows.Forms.Label kone1Kentta;
    }
}