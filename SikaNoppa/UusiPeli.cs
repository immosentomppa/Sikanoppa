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
    public partial class UusiPeli : Form
    {
        //Luodaan 4 uutta pelaajaa ja asetetaan ne kaikki tyhjiksi.
        private Pelaaja pelaaja1 = new Pelaaja("", 0);
        private Pelaaja pelaaja2 = new Pelaaja("", 0);
        private Pelaaja pelaaja3 = new Pelaaja("", 0);
        private Pelaaja pelaaja4 = new Pelaaja("", 0);
        //OnkoTotta-muuttujat uudelleen heittämiselle, vuoron vaihdolle, aloitukselle ja pisteiden ottamiselle.
        private bool heitaUudestaan, vuoroVaihto, alkaako, otetaankoPisteet;
        //Lukumuuttujat vuorolle, heittoluvulle ja heittojen summalle.
        private int vuoro, tulos, heittojesiSummaLuku;
        //Satunnaislukumuuttujat nopan silmäluvulle ja koneen päätöksenteolle
        private Random silmaLuku = new Random();
        private Random mitaTehdaan = new Random();
        //Merkkijonomuuttujat pelityypille sekä voittoilmoituksen otsikolle ja viestille
        private string peli, otsikko, viesti;
        //Tyhjä nappula voittoilmoituksen kuittaamiselle
        private MessageBoxButtons kuittaa;
        //Tyhjä tulosmuuttuja voittoilmoituksen kuittaamiselle
        private DialogResult kuitattu;

        /// <summary>
        /// Alustusmetodi, jolla luodaan uusi peli ja asetetaan annetut pelaajien nimet pelaajaolioiden nimiksi.
        /// </summary>
        /// <param name="pelaaja1Nimi">kuljetetaan annettu pelaajan 1 nimi alustusmetodille</param>
        /// <param name="pelaaja2Nimi">kuljetetaan annettu pelaajan 2 nimi alustusmetodille</param>
        /// <param name="pelaaja3Nimi">kuljetetaan annettu pelaajan 3 nimi alustusmetodille</param>
        /// <param name="pelaaja4Nimi">kuljetetaan annettu pelaajan 4 nimi alustusmetodille</param>
        public UusiPeli(string pelaaja1Nimi, string pelaaja2Nimi, string pelaaja3Nimi, string pelaaja4Nimi)
        {
            //Alustetaan käyttöliittymä
            InitializeComponent();
            //Jos 1. pelaajan nimi on Kone 1 mutta toisen pelaajan ei, tunnistetaan pelimuodoksi kone konetta vastaan.
            if (pelaaja1Nimi == "Kone 1" && pelaaja2Nimi != "Kone 1")
            {
                //asetetaan aloitusmuuttuja todeksi
                alkaako = true;
                //asetetaan pelimuodoksi kone konetta vastaan
                peli = "koneKonetta";
                //asetetaan 1. ja 2. pelaajaolion nimiksi annetut 1. ja 2. pelaajan nimet sekä 3. ja 4. pelaajan nimet tyhjiksi
                pelaaja1.Nimi = pelaaja1Nimi;
                pelaaja2.Nimi = pelaaja2Nimi;
                pelaaja3.Nimi = string.Empty;
                pelaaja4.Nimi = string.Empty;
                //asetetaan vuorokenttään pelaajan 1 nimi
                vuoroKentta.Text = pelaaja1.Nimi;
                //asetetaan 1. ja 2. pelaajan pisteet nollaksi
                pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                //asetetaan pelaajan 1. ja 2. nimikenttään 1. ja 2. pelaajaolion nimet
                pelaaja1NimiKentta.Text = pelaaja1.Nimi;
                pelaaja2NimiKentta.Text = pelaaja2.Nimi;
                //asetetaan heittoluku ja heittojen summa nollaksi
                heittojesiSummaLuku = 0;
                heititKentta.Text = "0";
                heittojesiSummaKentta.Text = "0";
                //Poistetaan napit käytöstä
                nopanHeitto.Enabled = false;
                otaPisteet.Enabled = false;
                lopetaPeli.Enabled = false;
                //aloitetaan bottien toimintoja hidastava ajastin
                timer1.Start();
            }
            //jos 2. pelaajan nimi on Kone 1, tunnistetaan pelimuodoksi pelaaja konetta vastaan
            else if (pelaaja2Nimi == "Kone 1")
            {
                //asetetaan pelimuodoksi pelaaja konetta vastaan
                peli = "peliKonetta";
                //asetetaan 1. ja 2. pelaajaolion nimiksi annetut 1. ja 2. pelaajan nimet sekä 3. ja 4. pelaajan nimet tyhjiksi
                pelaaja1.Nimi = pelaaja1Nimi;
                pelaaja2.Nimi = pelaaja2Nimi;
                pelaaja3.Nimi = string.Empty;
                pelaaja4.Nimi = string.Empty;
                //asetetaan vuorokenttään pelaajan 1 nimi
                vuoroKentta.Text = pelaaja1Nimi;
                //asetetaan 1. ja 2. pelaajan pisteiksi 0
                pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                //asetetaan 1. ja 2. pelaajan nimikenttään 1. ja 2. pelaajaolio nimet
                pelaaja1NimiKentta.Text = pelaaja1.Nimi;
                pelaaja2NimiKentta.Text = pelaaja2.Nimi;
                //asetetaan heittoluku sekä heittojen summa nollaksi
                heittojesiSummaLuku = 0;
                heittojesiSummaKentta.Text = "0";
                heititKentta.Text = "0";
                //asetetaan vuoro pelaajalle 1 ja käynnistetään koneen toimintoja viivästyttävä ajastin
                vuoro = 1;
                timer1.Start();
            }
            //jos pelaajan 1 tai 2 nimi ei ole Kone 1 eikä pelaajan 2 nimi Kone 2, tunnistetaan pelimuodoksi peli kavereja vastaan
            else if (pelaaja1Nimi != "Kone 1"  && pelaaja2Nimi != "Kone 1" && pelaaja2Nimi != "Kone 2")
            {
                //asetetaan pelimuodoksi peli kavereja vastaan
                peli = "peliKaveria";
                //jos 3. pelaajan nimi on tyhjä, tarkistetaan ensimmäiseksi onko 4. pelaajan nimi tyhjä
                if (pelaaja3Nimi != string.Empty)
                {
                    //jos 4. pelaajan nimi ei ole tyhjä, asetetaan jokaiselle pelaajalle heille annetut nimet ja pisteiksi 0
                    if (pelaaja4Nimi != string.Empty)
                    {
                        pelaaja1.Nimi = pelaaja1Nimi;
                        pelaaja2.Nimi = pelaaja2Nimi;
                        pelaaja3.Nimi = pelaaja3Nimi;
                        pelaaja4.Nimi = pelaaja4Nimi;
                        pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                        pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                        pelaaja3PisteetKentta.Text = Convert.ToString(pelaaja3.Pisteet);
                        pelaaja4PisteetKentta.Text = Convert.ToString(pelaaja4.Pisteet);

                    }
                    //jos 4. pelaajan nimi on tyhjä, asetetaan pelaajille 1-3 heille annetut nimet ja pisteiksi 0 sekä pelaajan 4 nimi tyhjäksi
                    else if (pelaaja4Nimi == string.Empty)
                    {
                        pelaaja1.Nimi = pelaaja1Nimi;
                        pelaaja2.Nimi = pelaaja2Nimi;
                        pelaaja3.Nimi = pelaaja3Nimi;
                        pelaaja4.Nimi = string.Empty;
                        pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                        pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                        pelaaja3PisteetKentta.Text = Convert.ToString(pelaaja3.Pisteet);
                    }
                }
                //jos 3. pelaajan nimi on tyhjä, asetetaan pelaajille 1 ja 2 heille annetut nimet ja pisteiksi 0 sekä pelaajille 3 ja 4 tyhjät
                //nimet
                else if (pelaaja3Nimi == string.Empty)
                {
                    pelaaja1.Nimi = pelaaja1Nimi;
                    pelaaja2.Nimi = pelaaja2Nimi;
                    pelaaja3.Nimi = string.Empty;
                    pelaaja4.Nimi = string.Empty;
                    pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                    pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                }
                //tämän jälkeen asetetaan pelaajien 1 ja 2 nimikenttiin pelaajaolioiden nimet
                pelaaja1NimiKentta.Text = pelaaja1.Nimi;
                pelaaja2NimiKentta.Text = pelaaja2.Nimi;
                //jos pelaajan 3 nimi ei ole tyhjä, asetetaan hänen nimikenttäänsä pelaajaoliolle annettu nimi
                if (pelaaja3.Nimi != string.Empty)
                {
                    pelaaja3NimiKentta.Text = pelaaja3.Nimi;
                    //jos pelaajan 4 nimi ei ole tyhjä, asetetaan hänen nimikenttäänsä pelaajaoliolle annettu nimi
                    if (pelaaja4.Nimi != string.Empty)
                    {
                        pelaaja4NimiKentta.Text = pelaaja4.Nimi;
                    }
                }
                //lopuksi asetetaan vuoro 1. pelaajalle sekä heittoluvuksi ja heittojen summaksi 0.
                vuoroKentta.Text = pelaaja1.Nimi;
                vuoro = 1;
                heititKentta.Text = "0";
                heittojesiSummaLuku = 0;
                heittojesiSummaKentta.Text = "0";
            }
        }

        //Kun noppaa heitetään
        private void nopanHeitto_Click(object sender, EventArgs e)
        {
            //Jos pelimuoto on peli kaveria vastaan
            if (peli == "peliKaveria")
            {
                //arvotaan nopan silmäluku väliltä 1-6
                Random silmaLuku = new Random();
                tulos = silmaLuku.Next(1, 7);
                //jos tulos on 1, asetetaan heiton luvuksi 1, heittojen summaksi 0 ja estetään uudelleenheitto.
                if (tulos == 1)
                {
                    heititKentta.Text = "1";
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    nopanHeitto.Enabled = false;
                }
                //Muutoin asetetaan heittokenttään tulos ja lisätään se heittojen summaan.
                else
                {
                    heititKentta.Text = Convert.ToString(tulos);
                    heittojesiSummaLuku += tulos;
                    heittojesiSummaKentta.Text = Convert.ToString(heittojesiSummaLuku);
                }
            }
            //Jos pelimuoto on pelaaja vs kone ja vuoro on 1
            else if (peli == "peliKonetta" && vuoro == 1)
            {
                //arvotaan nopan silmäluku väliltä 1-6
                Random silmaLuku = new Random();
                tulos = silmaLuku.Next(1, 7);
                //jos tulos on 1, asetetaan heiton luvuksi 1, heittojen summaksi 0 ja estetään uudelleenheitto.
                if (tulos == 1)
                {
                    heititKentta.Text = "1";
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    nopanHeitto.Enabled = false;
                }
                //Muutoin asetetaan heittokenttään tulos ja lisätään se heittojen summaan.
                else
                {
                    heititKentta.Text = Convert.ToString(tulos);
                    heittojesiSummaLuku += tulos;
                    heittojesiSummaKentta.Text = Convert.ToString(heittojesiSummaLuku);
                }
            }
        }

        //Kun pisteet otetaan
        private void otaPisteet_Click(object sender, EventArgs e)
        {
            //Jos peli on peli kaveria vastaan
            if (peli == "peliKaveria")
            {
                //jos vuoro on 1 ja heittojen summa ei ole 0
                if (vuoro == 1 && heittojesiSummaLuku != 0)
                {
                    //lisätään heittojen summa pisteisiin
                    pelaaja1.Pisteet += heittojesiSummaLuku;
                    pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                    //jonka jälkeen asetetaan heittoluku ja heittojen summa nollaksi
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos pelaajan pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja1.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja1.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voitto kuitataan, avataan uusi aloitus.
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //ja asetetaan vuoro pelaajalle 2
                    vuoro = 2;
                    vuoroKentta.Text = pelaaja2.Nimi;
                }
                //jos heittojen summa on 0, asetetaan heittoluku nollaksi, siirretään vuoro pelaajalle 2 ja sallitaan nopan heitto.
                else if (vuoro == 1 && heittojesiSummaLuku == 0)
                {
                    heititKentta.Text = "0";
                    vuoro = 2;
                    vuoroKentta.Text = pelaaja2.Nimi;
                    nopanHeitto.Enabled = true;
                }
                //jos vuoro on 2 ja heittojen summa ei ole 0
                else if (vuoro == 2 && heittojesiSummaLuku != 0)
                {
                    //lisätään heittojen summa pisteisiin
                    pelaaja2.Pisteet += heittojesiSummaLuku;
                    pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                    //jonka jälkeen asetetaan heittoluku ja heittojen summa nollaksi
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos pelaajan pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja2.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja2.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voitto kuitataan, avataan uusi aloitus.
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos pelaajan 3 nimi ei ole tyhjä, asetetaan vuoro hänelle
                    else if (pelaaja3.Nimi != string.Empty)
                    {
                        vuoro = 3;
                        vuoroKentta.Text = pelaaja3.Nimi;
                    }
                    //jos pelaajan 3 nimi on tyhjä, asetetaan vuoro pelaajalle 1
                    else if (pelaaja3.Nimi == string.Empty)
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                    }
                }
                //jos vuoro on 2 ja heittojen summa on 0
                else if (vuoro == 2 && heittojesiSummaLuku == 0)
                {
                    //asetetaan heittoluku nollaksi
                    heititKentta.Text = "0";
                    //jos pelaajan 3 nimi ei ole tyhjä, asetetaan vuoro hänelle ja nopanheitto sallituksi
                    if (pelaaja3.Nimi != string.Empty)
                    {
                        vuoro = 3;
                        vuoroKentta.Text = pelaaja3.Nimi;
                        nopanHeitto.Enabled = true;
                    }
                    //jos pelaajan 3 nimi on tyhjä, asetetaan vuoro pelaajalle 1 ja nopanheitto sallituksi
                    else if (pelaaja3.Nimi == string.Empty)
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                        nopanHeitto.Enabled = true;
                    }
                }
                //jos vuoro on 3 ja heittojen summa ei ole 0
                else if (vuoro == 3 && heittojesiSummaLuku != 0)
                {
                    //lisätään heittojen summa pelaajan 3 pisteisiin
                    pelaaja3.Pisteet += heittojesiSummaLuku;
                    pelaaja3PisteetKentta.Text = Convert.ToString(pelaaja3.Pisteet);
                    //ja asetetaan heittoluvuksi ja heittojen summaksi 0
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos pelaajan 3 pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja3.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja3.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //voiton kuittauksen jälkeen avataan uusi aloitus
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos pelaajan 4 nimi ei ole tyhjä, siirretään vuoro hänelle
                    else if (pelaaja4.Nimi != string.Empty)
                    {
                        vuoro = 4;
                        vuoroKentta.Text = pelaaja4.Nimi;
                    }
                    //jos pelaajan 4 nimi on tyhjä, siirretään vuoro pelaajalle 1
                    else if (pelaaja4.Nimi == string.Empty)
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                    }
                }
                //jos vuoro on 3 ja heittojen summa on 0, asetetaan heittoluku nollaksi
                else if (vuoro == 3 && heittojesiSummaLuku == 0)
                {
                    heititKentta.Text = "0";
                    //jos pelaajan 4 nimi ei ole tyhjä, siirretään vuoro hänelle ja pistetään nopanheitto sallituksi
                    if (pelaaja4.Nimi != string.Empty)
                    {
                        vuoro = 4;
                        vuoroKentta.Text = pelaaja4.Nimi;
                        nopanHeitto.Enabled = true;
                    }
                    //jos pelaajan 4 nimi on tyhjä, asetetaan vuoro pelaajalle 1 ja pistetään nopanheitto sallituksi
                    else if (pelaaja4.Nimi == string.Empty)
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                        nopanHeitto.Enabled = true;
                    }
                }

                //jos vuoro on 4 ja heittojen summa ei ole 0
                else if (vuoro == 4 && heittojesiSummaLuku != 0)
                {
                    //lisätään heittojen summa pelaajan 4 pisteisiin
                    pelaaja4.Pisteet += heittojesiSummaLuku;
                    pelaaja4PisteetKentta.Text = Convert.ToString(pelaaja4.Pisteet);
                    //ja nollataan heittoluku ja heittojen summa
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos pelaajan 4 pisteet ovat 100 tai yli, näytetään voittoilmoitus
                    if (pelaaja4.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja4.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voittoilmoitus kuitataan, avataan uusi aloitus
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos voittoa ei tapahtunut, siirretään vuoro pelaajalle 1
                    else
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                    }
                }
                //jos vuoro on 4 ja heittojen summa on 0, asetetaan heittoluku nollaksi, siirretään vuoro pelaajalle 1 ja sallitaan
                //nopanheitto
                else if (vuoro == 4 && heittojesiSummaLuku == 0)
                {
                    heititKentta.Text = "0";
                    vuoro = 1;
                    vuoroKentta.Text = pelaaja1.Nimi;
                    nopanHeitto.Enabled = true;
                }
            }
            //jos pelimuoto on peli konetta vastaan
            else if (peli == "peliKonetta")
            {
                //jos vuoro on 1 ja heittojen summa ei ole 0
                if (vuoro == 1 && heittojesiSummaLuku != 0)
                {
                    //lisätään heittojen summa pelaajan 1 pisteisiin
                    pelaaja1.Pisteet += heittojesiSummaLuku;
                    pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                    //ja nollataan heittoluku ja heittojen summa
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos pelaajan 1 pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja1.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja1.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voitto kuitataan, avataan uusi aloitus.
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos voittoa ei tapahtunut, asetetaan vuoron vaihto todeksi ja estetään nopanheitto, pisteiden ottaminen ja pelin lopetus
                    else
                    {
                        vuoroVaihto = true;
                        nopanHeitto.Enabled = false;
                        otaPisteet.Enabled = false;
                        lopetaPeli.Enabled = false;
                    }
                }
                //jos vuoro on 1 ja heittojen summa on 0
                else if (vuoro == 1 && heittojesiSummaLuku == 0)
                {
                    //asetetaan heittoluku ja heittojen summa nollaksi ja estetään nopanheitto, pisteiden ottaminen ja pelin lopetus sekä
                    //asetetaan vuoron vaihto todeksi
                    heititKentta.Text = "0";
                    heittojesiSummaKentta.Text = "0";
                    nopanHeitto.Enabled = false;
                    otaPisteet.Enabled = false;
                    lopetaPeli.Enabled = false;
                    vuoroVaihto = true;
                }
            }
        }

        //Jos pelin lopetusta painetaan
        private void lopetaPeli_Click(object sender, EventArgs e)
        {
            //avataan uusi pelin tallennuksen käyttöliittymä
            TallennusPeli lopetetaanPeli = new TallennusPeli(pelaaja1, pelaaja2, pelaaja3, pelaaja4, vuoro, -1);
            DialogResult loppuTulos = lopetetaanPeli.ShowDialog();
            //jos peliä ei tallenneta tai se tallennetaan, avataan uusi aloituskäyttöliittymä.
            if (loppuTulos == DialogResult.Yes || loppuTulos == DialogResult.No)
            {
                Hide();
                Aloitus aloitetaanUusi = new Aloitus();
                aloitetaanUusi.ShowDialog();
                Close();
            }
        }

        //Metodi, jolla kone heittää noppaa
        private void HeitaNoppaaKone()
        {
            //jos pelimuoto on kone konetta vastaan
            if (peli == "koneKonetta")
            {
                //arvotaan silmäluku väliltä 1-6 ja estetään automaattinen uudelleenheittäminen
                tulos = silmaLuku.Next(1, 7);
                heitaUudestaan = false;
                //jos tulos on 1, asetetaan heittoluku arvoon 1, heittojen summa arvoon 0 ja sallitaan automaattinen pisteidenotto
                if (tulos == 1)
                {
                    heititKentta.Text = "1";
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    otetaankoPisteet = true;
                }
                //jos tulos ei ole 1, asetetaan se heittoluvuksi ja lisätään se heittojen summaan, jonka jälkeen pistetään kone arpomaan
                //seuraava teko
                else
                {
                    heititKentta.Text = Convert.ToString(tulos);
                    heittojesiSummaLuku += tulos;
                    heittojesiSummaKentta.Text = Convert.ToString(heittojesiSummaLuku);
                    KoneToiminta();
                }
            }
            //jos pelimuoto on pelaaja konetta vastaan ja vuoro on 2
            else if (peli == "peliKonetta" && vuoro == 2)
            {
                //arvotaan uusi silmäluku väliltä 1-6 ja estetään automaattinen uudelleenheittäminen
                tulos = silmaLuku.Next(1, 7);
                heitaUudestaan = false;
                //jos tulos on 1, asetetaan heittoluvuksi 1 ja nollataan heittojen summa sekä sallitaan automaattinen pisteidenotto
                if (tulos == 1)
                {
                    heititKentta.Text = "1";
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    otetaankoPisteet = true;
                }
                //jos tulos ei ole 1, asetetaan se heittoluvuksi ja lisätään se heittojen summaan, jonka jälkeen pistetään kone arpomaan
                //seuraava teko
                else
                {
                    heititKentta.Text = Convert.ToString(tulos);
                    heittojesiSummaLuku += tulos;
                    heittojesiSummaKentta.Text = Convert.ToString(heittojesiSummaLuku);
                    KoneToiminta();
                }
            }

        }

        //Metodi, jolla kone arpoo tekonsa
        private void KoneToiminta()
        {
            //jos pelimuoto on pelaaja konetta vastaan
            if (peli == "peliKonetta")
            {
                //ja vuoro on 2, asetetaan automaattinen pisteiden otto, uudelleenheitto ja vuoron vaihto estetyksi
                if (vuoro == 2)
                {
                    otetaankoPisteet = false;
                    heitaUudestaan = false;
                    vuoroVaihto = false;
                    //jonka jälkeen arvotaan luvuksi 1 tai 2
                    int tehdaanTama = mitaTehdaan.Next(1, 3);
                    //jos  luku on 1 tai heittojen summa on 0, asetetaan automaattinen uudelleenheitto todeksi
                    if (tehdaanTama == 1 || heittojesiSummaLuku == 0)
                    {
                        heitaUudestaan = true;
                    }
                    //jos heittojen summa on isompi kuin 0 ja luku on 2, asetetaan automaattinen pisteidenotto todeksi
                    else if (heittojesiSummaLuku > 0)
                    {
                        if (tehdaanTama == 2)
                        {
                            otetaankoPisteet = true;
                        }
                    }
                }
            }
            //jos pelimuoto on kone konetta vastaan
            else if (peli == "koneKonetta")
            {
                //asetetaan automaattinen vuoron vaihto, uudelleenheitto ja pisteiden otto epätodeksi
                vuoroVaihto = false;
                heitaUudestaan = false;
                otetaankoPisteet = false;
                //jonka jälkeen arvotaan luvuksi 1 tai 2
                int tehdaanTama = mitaTehdaan.Next(1, 3);
                //jos luku on 1 tai heittojen summa on 0, asetetaan automaattinen uudelleenheitto todeksi
                if (tehdaanTama == 1 || heittojesiSummaLuku == 0)
                {
                    heitaUudestaan = true;
                }
                //jos heittojen summa on enemmän kuin 0 ja luku on 2, asetetaan automaattinen pisteidenotto todeksi
                else if (heittojesiSummaLuku > 0)
                {
                    if (tehdaanTama == 2)
                    {
                        otetaankoPisteet = true;
                    }
                }
            }
        }

        //Metodi, joka käydään läpi aina kun kuluu sekunti.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //jos pelimuoto on pelaaja konetta vastaan
            if (peli == "peliKonetta")
            {
                //ja 1. sekä 2. pelaajan pisteet ovat alle 100
                if (pelaaja1.Pisteet < 100 && pelaaja2.Pisteet < 100)
                {
                    //jos vuoro on 2 ja uudelleenheitto on totta, kutsutaan koneen nopanheittometodia
                    if (vuoro == 2 && heitaUudestaan == true)
                    {
                        HeitaNoppaaKone();
                    }
                    //jos vuoro on 1 ja vuoron vaihto on totta, asetetaan vuoro koneelle ja kutsutaan koneen tekopäätösmetodia
                    else if (vuoro == 1 && vuoroVaihto == true)
                    {
                        vuoro = 2;
                        vuoroKentta.Text = pelaaja2.Nimi;
                        KoneToiminta();
                    }
                    //jos vuoro on 2 ja pisteidenotto on totta, kutsutaan pisteidenottometodia
                    else if (vuoro == 2 && otetaankoPisteet == true)
                    {
                        OtaPisteetKone();
                    }
                }
            }
            //jos pelimuoto on kone konetta vastaan
            else if (peli == "koneKonetta")
            {
                //ja 1. sekä 2. pelaajan pisteet ovat alle 100
                if (pelaaja1.Pisteet < 100 && pelaaja2.Pisteet < 100)
                {
                    //jos aloitusmuuttuja on totta, asetetaan se epätodeksi, annetaan vuoro pelaajalle 1 ja kutsutaan koneen tekopäätösmetodia
                    if (alkaako == true)
                    {
                        alkaako = false;
                        vuoro = 1;
                        KoneToiminta();
                    }
                    //jos vuoro on 1 ja pisteidenotto on totta, kutsutaan pisteidenottometodia
                    else if (vuoro == 1 && otetaankoPisteet == true)
                    {
                        OtaPisteetKone();
                    }
                    //jos vuoro on 1 ja uudelleenheitto on totta, kutsutaan uudelleenheittometodia
                    else if (vuoro == 1 && heitaUudestaan == true)
                    {
                        HeitaNoppaaKone();
                    }
                    //jos vuoro on 2 ja pisteidenotto on totta, kutsutaan pisteidenottometodia
                    else if (vuoro == 2 && otetaankoPisteet == true)
                    {
                        OtaPisteetKone();
                    }
                    //jos vuoro on 2 ja uudelleenheitto on totta, kutsutaan uudelleenheittometodia
                    else if (vuoro == 2 && heitaUudestaan == true)
                    {
                        HeitaNoppaaKone();
                    }
                    //jos vuoro on 1 ja vuoron vaihto on totta, asetetaan vuoro pelaajalle 2, nollataan heittoluku ja kutsutaan koneen
                    //päätöksentekometodia
                    else if (vuoro == 1 && vuoroVaihto == true)
                    {
                        vuoro = 2;
                        vuoroKentta.Text = pelaaja2.Nimi;
                        heititKentta.Text = "0";
                        KoneToiminta();
                    }
                    //jos vuoro on 2 ja vuoron vaihto on totta, asetetaan vuoro pelaajalle 1, nollataan heittoluku ja kutsutaan koneen
                    //päätöksentekometodia
                    else if (vuoro == 2 && vuoroVaihto == true)
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                        heititKentta.Text = "0";
                        KoneToiminta();
                    }
                }
            }
        }

        //Metodi, jolla kone voi ottaa pisteensä
        private void OtaPisteetKone()
        {
            //jos peli on pelaaja konetta vastaan, asetetaan ensiksi automaattinen pisteidenotto epätodeksi
            if (peli == "peliKonetta")
            {
                otetaankoPisteet = false;
                //jos vuoro on 2 ja heittojen summa ei ole 0, lisätään se 2. pelaajan pisteisiin ja nollataan heittoluku sekä heittojen summa
                if (vuoro == 2 && heittojesiSummaLuku != 0)
                {
                    pelaaja2.Pisteet += heittojesiSummaLuku;
                    pelaaja2PisteetKentta.Text = pelaaja2.Pisteet.ToString();
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos 2. pelaajan pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja2.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja2.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kuittauksen jälkeen avataan uusi aloituskäyttöliittymä
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos voittoa ei tapahtunut, siirretään vuoro pelaajalle 1 ja sallitaan nopanheitto, pelin lopetus sekä pisteidenotto
                    else
                    {
                        vuoro = 1;
                        vuoroKentta.Text = pelaaja1.Nimi;
                        nopanHeitto.Enabled = true;
                        lopetaPeli.Enabled = true;
                        otaPisteet.Enabled = true;
                    }
                }
                //jos vuoro on 2 ja heittojen summa on 0, siirretään vuoro pelaajalle 1, sallitaan nopanheitto, pelin lopetus sekä pisteidenotto
                //ja asetetaan heittoluku sekä heittojen summa nollaksi
                else if (vuoro == 2 && heittojesiSummaLuku == 0)
                {
                    vuoro = 1;
                    vuoroKentta.Text = pelaaja1.Nimi;
                    nopanHeitto.Enabled = true;
                    lopetaPeli.Enabled = true;
                    otaPisteet.Enabled = true;
                    heititKentta.Text = "0";
                    heittojesiSummaKentta.Text = "0";
                }
            }
            //jos pelimuoto on kone konetta vastaan ja pisteidenotto on totta, asetetaan se ensimmäisenä epätodeksi
            else if (peli == "koneKonetta" && otetaankoPisteet == true)
            {
                otetaankoPisteet = false;
                //jos vuoro on 1 ja heittojen summa ei ole 0, lisätään se 1. pelaajan pisteisiin ja nollataan heittoluku sekä heittojen summa
                if (vuoro == 1 && heittojesiSummaLuku != 0)
                {
                    pelaaja1.Pisteet += heittojesiSummaLuku;
                    pelaaja1PisteetKentta.Text = Convert.ToString(pelaaja1.Pisteet);
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos 1. pelaajan pisteet ovat 100 tai yli, ilmoitetaan voitosta
                    if (pelaaja1.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja1.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voitto kuitataan, avataan uusi aloituskäyttöliittymä
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos voittoa ei tapahtunut, asetetaan automaattinen vuoron vaihto todeksi
                    else
                    {
                        vuoroVaihto = true;
                    }
                }
                //jos vuoro on 1 ja heittojen summa on 0, asetetaan automaattinen vuoron vaihto todeksi
                else if (vuoro == 1 && heittojesiSummaLuku == 0)
                {
                    vuoroVaihto = true;
                }
                //jos vuoro on 2 ja heittojen summa ei ole 0, lisätään se pelaajan 2 pisteisiin ja nollataan heittoluku sekä heittojen summa
                else if (vuoro == 2 && heittojesiSummaLuku != 0)
                {
                    pelaaja2.Pisteet += heittojesiSummaLuku;
                    pelaaja2PisteetKentta.Text = Convert.ToString(pelaaja2.Pisteet);
                    heittojesiSummaKentta.Text = "0";
                    heittojesiSummaLuku = 0;
                    heititKentta.Text = "0";
                    //jos 2. pelaajan pisteet ovat yli 100, ilmoitetaan voitosta
                    if (pelaaja2.Pisteet >= 100)
                    {
                        otsikko = "Ilmoitus";
                        viesti = pelaaja2.Nimi + " voitti pelin";
                        kuittaa = MessageBoxButtons.OK;
                        DialogResult kuitattu = MessageBox.Show(viesti, otsikko, kuittaa);
                        //kun voitto kuitataan, avataan uusi aloituskäyttöliittymä
                        if (kuitattu == DialogResult.OK)
                        {
                            Hide();
                            Aloitus uusiAloitus = new Aloitus();
                            uusiAloitus.ShowDialog();
                            Close();
                        }
                    }
                    //jos voittoa ei tapahtunut, asetetaan automaattinen vuoron vaihto todeksi
                    else
                    {
                        vuoroVaihto = true;
                    }
                }
                //jos vuoro on 2 ja heittojen summa on 0, asetetaan automaattinen vuoron vaihto todeksi
                else if (vuoro == 2 && heittojesiSummaLuku == 0)
                {
                    vuoroVaihto = true;
                }
            }
        }
    }
}
