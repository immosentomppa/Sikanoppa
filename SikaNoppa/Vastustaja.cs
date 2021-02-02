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
    /// Luokka, jolla hallitaan vastustajan valinta -käyttöliittymää.
    /// </summary>
    public partial class    Vastustaja : Form
    {
        //Alustetaan käyttöliittymä
        public Vastustaja()
        {
            InitializeComponent();
        }

        //jos klikataan kaveria vastaan, siirrytään pelaajien syöttö -käyttöliittymään
        private void kaveriaVastaan_Click(object sender, EventArgs e)
        {
            Hide();
            Pelaajat pelaajaSyotto = new Pelaajat();
            pelaajaSyotto.ShowDialog();
            Close();
        }

        //jos klikataan konetta vastaan, siirrytään pelaajan syöttö -käyttöliittymään
        private void konettaVastaan_Click(object sender, EventArgs e)
        {
            Hide();
            PelaajaKone annaPelaaja = new PelaajaKone();
            annaPelaaja.ShowDialog();
            Close();
        }

        //jos klikataan kone konetta vastaan, luodaan uusi kone vs kone -peli
        private void koneKonettaVastaan_Click(object sender, EventArgs e)
        {
            Hide();
            UusiPeli konettaVastaan = new UusiPeli("Kone 1", "Kone 2", "", "");
            konettaVastaan.ShowDialog();
            Close();
        }

        //jos klikataan peruuta, mennään takaisin aloitukseen
        private void peruuta_Click(object sender, EventArgs e)
        {
            Hide();
            Aloitus takaisinAloitukseen = new Aloitus();
            takaisinAloitukseen.ShowDialog();
            Close();
        }
    }
}
