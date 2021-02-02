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
    /// Luokka, jolla luodaan uusi pelaaja vs kone -peli.
    /// </summary>
    public partial class PelaajaKone : Form
    {
        //Muuttujat pelaajan ja koneen nimelle
        private string pelaajanNimi;
        private string koneenNimi;
        //Alustetaan käyttöliittymä
        public PelaajaKone()
        {
            InitializeComponent();
        }

        //Kun klikataan "valmis", luodaan uusi pelaaja vs kone -peli.
        private void luoPeli_Click(object sender, EventArgs e)
        {
            //Asetetaan pelaajan ja koneen nimeksi kenttien sisällöt
            pelaajanNimi = pelaaja1Kentta.Text;
            koneenNimi = kone1Kentta.Text;
            Hide();
            UusiPeli peliKonettaVastaan = new UusiPeli(pelaajanNimi, koneenNimi, "", "");
            peliKonettaVastaan.ShowDialog();
            Close();
        }

        //Jos klikataan peruuta, mennään takaisin vastustajaan.
        private void peruuta_Click(object sender, EventArgs e)
        {
            Vastustaja takaisinVastustajaan = new Vastustaja();
            Hide();
            takaisinVastustajaan.ShowDialog();
            Close();
        }
    }
}
