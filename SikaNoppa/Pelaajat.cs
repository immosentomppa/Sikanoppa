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
    /// Luokka, jonka käyttöliittymässä annetaan pelaajien nimet peli kaveria vastaan -pelimuodossa.
    /// </summary>
    public partial class Pelaajat : Form
    {
        //Muuttujat pelaajien nimille
        private string pelaajan1Nimi;
        private string pelaajan2Nimi;
        private string pelaajan3Nimi;
        private string pelaajan4Nimi;
        //Alustetaan käyttöliittymä.
        public Pelaajat()
        {
            InitializeComponent();
        }

        //Kun klikataan valmis, tarkistetaan ensin kenttien sisällöt.
        private void luoPeli_Click(object sender, EventArgs e)
        {
            //Asetetaan tekstikenttien sisällöt aiemmin luotuihin muuttujiin
            pelaajan1Nimi = pelaaja1Kentta.Text;
            pelaajan2Nimi = pelaaja2Kentta.Text;
            pelaajan3Nimi = pelaaja3Kentta.Text;
            pelaajan4Nimi = pelaaja4Kentta.Text;
            MessageBoxButtons kuittaa;
            string varoitus, otsikko;
            //Jos 1. tai 2. pelaajan nimi on tyhjä, annetaan virheilmoitus.
            if (pelaajan1Nimi == string.Empty || pelaajan2Nimi == string.Empty)
            {
                otsikko = "Virhe";
                varoitus = "Peli vaatii vähintään 2 pelaajaa.";
                kuittaa = MessageBoxButtons.OK;
                MessageBox.Show(varoitus, otsikko, kuittaa);
            }
            //Jos 1. pelaajan nimi on Kone 1 tai 2. pelaajan nimi on joko Kone 1 tai Kone 2, annetaan virheilmoitus, jottei konepeliä
            //voida luoda pelaajilla.
            else if (pelaajan1Nimi == "Kone 1" || pelaajan2Nimi == "Kone 1" || pelaajan2Nimi == "Kone 2")
            {
                otsikko = "Virhe";
                varoitus = "Kyseisiä nimiä ei voi käyttää";
                kuittaa = MessageBoxButtons.OK;
                MessageBox.Show(varoitus, otsikko, kuittaa);
            }
            //Muutoin luodaan uusi peli kaveria vastaan -peli.
            else
            {
                UusiPeli peliKaveriaVastaan = new UusiPeli(pelaajan1Nimi, pelaajan2Nimi, pelaajan3Nimi, pelaajan4Nimi);
                Hide();
                peliKaveriaVastaan.ShowDialog();
                Close();
            }
        }

        //Jos klikataan peruuta, mennään takaisin vastustajan valintaan.
        private void peruuta_Click(object sender, EventArgs e)
        {
            Hide();
            Vastustaja takaisinVastustajaan = new Vastustaja();
            takaisinVastustajaan.ShowDialog();
            Close();
        }
    }
}
