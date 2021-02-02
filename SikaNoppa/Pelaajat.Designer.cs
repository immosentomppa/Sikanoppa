namespace SikaNoppa
{
    partial class Pelaajat
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
            this.pelaaja1Kentta = new System.Windows.Forms.TextBox();
            this.luoPeli = new System.Windows.Forms.Button();
            this.pelaaja3Kentta = new System.Windows.Forms.TextBox();
            this.pelaaja2Kentta = new System.Windows.Forms.TextBox();
            this.pelaaja4Kentta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pelaaja1Teksti = new System.Windows.Forms.Label();
            this.pelaaja2Teksti = new System.Windows.Forms.Label();
            this.pelaaja3Teksti = new System.Windows.Forms.Label();
            this.peruuta = new System.Windows.Forms.Button();
            this.pelaaja4Teksti = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pelaaja1Kentta
            // 
            this.pelaaja1Kentta.Location = new System.Drawing.Point(39, 96);
            this.pelaaja1Kentta.Name = "pelaaja1Kentta";
            this.pelaaja1Kentta.Size = new System.Drawing.Size(65, 20);
            this.pelaaja1Kentta.TabIndex = 0;
            // 
            // luoPeli
            // 
            this.luoPeli.Location = new System.Drawing.Point(39, 205);
            this.luoPeli.Name = "luoPeli";
            this.luoPeli.Size = new System.Drawing.Size(65, 23);
            this.luoPeli.TabIndex = 4;
            this.luoPeli.Text = "Valmis";
            this.luoPeli.UseVisualStyleBackColor = true;
            this.luoPeli.Click += new System.EventHandler(this.luoPeli_Click);
            // 
            // pelaaja3Kentta
            // 
            this.pelaaja3Kentta.Location = new System.Drawing.Point(39, 155);
            this.pelaaja3Kentta.Name = "pelaaja3Kentta";
            this.pelaaja3Kentta.Size = new System.Drawing.Size(65, 20);
            this.pelaaja3Kentta.TabIndex = 2;
            // 
            // pelaaja2Kentta
            // 
            this.pelaaja2Kentta.Location = new System.Drawing.Point(154, 96);
            this.pelaaja2Kentta.Name = "pelaaja2Kentta";
            this.pelaaja2Kentta.Size = new System.Drawing.Size(68, 20);
            this.pelaaja2Kentta.TabIndex = 1;
            // 
            // pelaaja4Kentta
            // 
            this.pelaaja4Kentta.Location = new System.Drawing.Point(154, 155);
            this.pelaaja4Kentta.Name = "pelaaja4Kentta";
            this.pelaaja4Kentta.Size = new System.Drawing.Size(68, 20);
            this.pelaaja4Kentta.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Anna jokaisen pelaajan nimi. Jos pelaajia \r\nei ole neljää, voit jättää loput tyhj" +
    "äksi.";
            // 
            // pelaaja1Teksti
            // 
            this.pelaaja1Teksti.AutoSize = true;
            this.pelaaja1Teksti.Location = new System.Drawing.Point(45, 80);
            this.pelaaja1Teksti.Name = "pelaaja1Teksti";
            this.pelaaja1Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja1Teksti.TabIndex = 6;
            this.pelaaja1Teksti.Text = "Pelaaja 1";
            // 
            // pelaaja2Teksti
            // 
            this.pelaaja2Teksti.AutoSize = true;
            this.pelaaja2Teksti.Location = new System.Drawing.Point(163, 80);
            this.pelaaja2Teksti.Name = "pelaaja2Teksti";
            this.pelaaja2Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja2Teksti.TabIndex = 7;
            this.pelaaja2Teksti.Text = "Pelaaja 2";
            // 
            // pelaaja3Teksti
            // 
            this.pelaaja3Teksti.AutoSize = true;
            this.pelaaja3Teksti.Location = new System.Drawing.Point(45, 139);
            this.pelaaja3Teksti.Name = "pelaaja3Teksti";
            this.pelaaja3Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja3Teksti.TabIndex = 8;
            this.pelaaja3Teksti.Text = "Pelaaja 3";
            // 
            // peruuta
            // 
            this.peruuta.Location = new System.Drawing.Point(154, 205);
            this.peruuta.Name = "peruuta";
            this.peruuta.Size = new System.Drawing.Size(68, 23);
            this.peruuta.TabIndex = 5;
            this.peruuta.Text = "Peruuta";
            this.peruuta.UseVisualStyleBackColor = true;
            this.peruuta.Click += new System.EventHandler(this.peruuta_Click);
            // 
            // pelaaja4Teksti
            // 
            this.pelaaja4Teksti.AutoSize = true;
            this.pelaaja4Teksti.Location = new System.Drawing.Point(163, 139);
            this.pelaaja4Teksti.Name = "pelaaja4Teksti";
            this.pelaaja4Teksti.Size = new System.Drawing.Size(51, 13);
            this.pelaaja4Teksti.TabIndex = 10;
            this.pelaaja4Teksti.Text = "Pelaaja 4";
            // 
            // Pelaajat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pelaaja4Teksti);
            this.Controls.Add(this.peruuta);
            this.Controls.Add(this.pelaaja3Teksti);
            this.Controls.Add(this.pelaaja2Teksti);
            this.Controls.Add(this.pelaaja1Teksti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pelaaja4Kentta);
            this.Controls.Add(this.pelaaja2Kentta);
            this.Controls.Add(this.pelaaja3Kentta);
            this.Controls.Add(this.luoPeli);
            this.Controls.Add(this.pelaaja1Kentta);
            this.Name = "Pelaajat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sikanoppa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pelaaja1Kentta;
        private System.Windows.Forms.Button luoPeli;
        private System.Windows.Forms.TextBox pelaaja3Kentta;
        private System.Windows.Forms.TextBox pelaaja2Kentta;
        private System.Windows.Forms.TextBox pelaaja4Kentta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pelaaja1Teksti;
        private System.Windows.Forms.Label pelaaja2Teksti;
        private System.Windows.Forms.Label pelaaja3Teksti;
        private System.Windows.Forms.Button peruuta;
        private System.Windows.Forms.Label pelaaja4Teksti;
    }
}