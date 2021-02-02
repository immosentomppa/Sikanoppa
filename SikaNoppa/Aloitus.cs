using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SikaNoppa
{
    /// <summary>
    /// Luokka, jolla luodaan uusi aloituskäyttöliittymä ja hallitaan sitä.
    /// </summary>
    public partial class Aloitus : Form
    {
        /// <summary>
        /// Alustetaan käyttöliittymä
        /// </summary>
        public Aloitus()
        {   
            InitializeComponent();
        }

        //Kun Uusi peli -nappulaa klikataan, aukeaa vastustajan valinta -käyttöliittymä
        private void aloitaUusi_Click(object sender, EventArgs e)
        {
            Hide();
            Vastustaja vastustajanValinta = new Vastustaja();
            vastustajanValinta.ShowDialog();
            Close();
        }

        //Kun Jatka peliä -nappulaa klikataa, kysytään pelin ID ja sen jälkeen avataan kyseinen peli.
        private void jatkaVanhaa_Click(object sender, EventArgs e)
        {
            //Kysytään pelin ID:tä ja asetetaan se muuttujaan.
            PeliHaku annaID = new PeliHaku();
            DialogResult pelinHaku = annaID.ShowDialog();
            long pelinID = annaID.PelinID;
            //Jos uudesta lomakkeesta painetaan "Valmis", luodaan uusi peli"
            if (pelinHaku == DialogResult.Yes)
            {
                //Luodaan uusi käyttöliittymä jatkettavalle pelille, ja viedään sille käyttäjän antama ID.
                JatkaPelia jatketaan = new JatkaPelia(pelinID);
                Hide();
                jatketaan.ShowDialog();
                Close();
            }
        }

        //Metodi, jolla näytetään ohjeboksi, kun aloituksessa olevaa kysymysmerkkiä klikataan
        private void ohjeet_Click(object sender, EventArgs e)
        {
            MessageBoxButtons kuittaa = MessageBoxButtons.OK;
            string viesti = "Pelaajat heittävät vuorollaan noppaa. Noppaa saa heittää niin kauan, kunnes nopasta tulee 1. Tällöin pisteet nollautuvat ja vuoro vaihtuu. Vaihtoehtoisesti pelaaja voi myös halutessaan ottaa pisteet, jolloin vuoro siirtyy seuraavalle. Peliä pelataan niin kauan, että joku pelaajista saa 100 pistettä. Pelin voi myös tallentaa.\n\nPelimuodot ovat:\n\nKavereja vastaan\nPelaaja konetta vastaan\nKone konetta vastaan ";
            string otsikko = "Ohjeet";
            MessageBox.Show(viesti, otsikko, kuittaa);
        }
    }
}
