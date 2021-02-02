namespace SikaNoppa
{
    partial class Aloitus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aloitus));
            this.aloitaUusi = new System.Windows.Forms.Button();
            this.jatkaVanhaa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ohjeet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ohjeet)).BeginInit();
            this.SuspendLayout();
            // 
            // aloitaUusi
            // 
            this.aloitaUusi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aloitaUusi.Location = new System.Drawing.Point(12, 134);
            this.aloitaUusi.Name = "aloitaUusi";
            this.aloitaUusi.Size = new System.Drawing.Size(169, 61);
            this.aloitaUusi.TabIndex = 1;
            this.aloitaUusi.Text = "Aloita uusi peli";
            this.aloitaUusi.UseVisualStyleBackColor = true;
            this.aloitaUusi.Click += new System.EventHandler(this.aloitaUusi_Click);
            // 
            // jatkaVanhaa
            // 
            this.jatkaVanhaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jatkaVanhaa.Location = new System.Drawing.Point(249, 134);
            this.jatkaVanhaa.Name = "jatkaVanhaa";
            this.jatkaVanhaa.Size = new System.Drawing.Size(170, 61);
            this.jatkaVanhaa.TabIndex = 2;
            this.jatkaVanhaa.Text = "Jatka peliä";
            this.jatkaVanhaa.UseVisualStyleBackColor = true;
            this.jatkaVanhaa.Click += new System.EventHandler(this.jatkaVanhaa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tervetuloa pelaamaan Sikanoppaa!";
            // 
            // ohjeet
            // 
            this.ohjeet.Image = ((System.Drawing.Image)(resources.GetObject("ohjeet.Image")));
            this.ohjeet.Location = new System.Drawing.Point(365, 12);
            this.ohjeet.Name = "ohjeet";
            this.ohjeet.Size = new System.Drawing.Size(54, 35);
            this.ohjeet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ohjeet.TabIndex = 5;
            this.ohjeet.TabStop = false;
            this.ohjeet.Click += new System.EventHandler(this.ohjeet_Click);
            // 
            // Aloitus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(431, 258);
            this.Controls.Add(this.ohjeet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jatkaVanhaa);
            this.Controls.Add(this.aloitaUusi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(447, 297);
            this.MinimumSize = new System.Drawing.Size(447, 297);
            this.Name = "Aloitus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sikanoppa";
            ((System.ComponentModel.ISupportInitialize)(this.ohjeet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button aloitaUusi;
        private System.Windows.Forms.Button jatkaVanhaa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ohjeet;
    }
}

