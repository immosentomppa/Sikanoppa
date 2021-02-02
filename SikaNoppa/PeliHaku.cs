using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SikaNoppa
{
    /// <summary>
    /// Luokka, jota käytetään peliä jatkaessa. Lomakkeelle annetaan pelin ID, joka palauttaa sen hakijalle.
    /// </summary>
    public partial class PeliHaku : Form
    {
        //Muuttuja pelin ID:lle.
        private int pelinID;

        //Alustetaan käyttöliittymä.
        public PeliHaku()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ominaisuus, jolla viedään käyttäjän antama pelin ID muualle tai tarvittaessa laitetaan se tiettyyn arvoon.
        /// </summary>
        public int PelinID
        {
            get
            {
                return pelinID;
            }
            set
            {
                pelinID = value;
            }
        }

        //Kun peruutusta painetaan, mennään takaisin aloitukseen.
        private void peruuta_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //Kun klikataan valmis, kerrotaan edelliselle lomakkeelle siitä ja asetetaan pelin ID:ksi kentässä oleva arvo.
        private void valmis_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            PelinID = Convert.ToInt32(pelinIDKentta.Text);
            Close();
        }
    }
}
