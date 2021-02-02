namespace SikaNoppa
{
    partial class PeliHaku
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
            this.pelinIDKentta = new System.Windows.Forms.TextBox();
            this.valmis = new System.Windows.Forms.Button();
            this.peruuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anna pelin ID:";
            // 
            // pelinIDKentta
            // 
            this.pelinIDKentta.Location = new System.Drawing.Point(64, 54);
            this.pelinIDKentta.Name = "pelinIDKentta";
            this.pelinIDKentta.Size = new System.Drawing.Size(100, 20);
            this.pelinIDKentta.TabIndex = 1;
            // 
            // valmis
            // 
            this.valmis.Location = new System.Drawing.Point(46, 109);
            this.valmis.Name = "valmis";
            this.valmis.Size = new System.Drawing.Size(63, 23);
            this.valmis.TabIndex = 2;
            this.valmis.Text = "Valmis";
            this.valmis.UseVisualStyleBackColor = true;
            this.valmis.Click += new System.EventHandler(this.valmis_Click);
            // 
            // peruuta
            // 
            this.peruuta.Location = new System.Drawing.Point(125, 109);
            this.peruuta.Name = "peruuta";
            this.peruuta.Size = new System.Drawing.Size(60, 23);
            this.peruuta.TabIndex = 3;
            this.peruuta.Text = "Peruuta";
            this.peruuta.UseVisualStyleBackColor = true;
            this.peruuta.Click += new System.EventHandler(this.peruuta_Click);
            // 
            // PeliHaku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 144);
            this.Controls.Add(this.peruuta);
            this.Controls.Add(this.valmis);
            this.Controls.Add(this.pelinIDKentta);
            this.Controls.Add(this.label1);
            this.Name = "PeliHaku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pelin haku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pelinIDKentta;
        private System.Windows.Forms.Button valmis;
        private System.Windows.Forms.Button peruuta;
    }
}