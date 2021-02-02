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
    /// Luokka, jota käytetään pelin lopetuskäyttöliittymän näyttämiseen. Tämä avataan, kun pelaaja painaa pelissä "Lopeta peli".
    /// </summary>
    public partial class TallennusPeli : Form
    {
        //Muuttujat jokaisen pelaajan nimelle ja heidän pisteilleen sekä viimeiselle vuorolle.
        private string pelaaja1Nimi, pelaaja2Nimi, pelaaja3Nimi, pelaaja4Nimi;
        private int pelaaja1Pisteet, pelaaja2Pisteet, pelaaja3Pisteet, pelaaja4Pisteet, vuoroLuku;
        //Muuttuja pelin ID:lle. Jos tähän käyttöliittymään tullaan uudesta pelistä, pelin ID on -1.
        private long peliID;

        /// <summary>
        /// Aloitusmetodi, asetetaan kaikkien pelaajien nimet ja pisteet sekä viimeinen vuoro ja pelin ID muuttujiin.
        /// </summary>
        /// <param name="pelaaja1">1. pelaajan pelaajaolio</param>
        /// <param name="pelaaja2">2. pelaajan pelaajaolio</param>
        /// <param name="pelaaja3">3. pelaajan pelaajaolio</param>
        /// <param name="pelaaja4">4. pelaajan pelaajaolio</param>
        /// <param name="vuoro">vuoro, johon peli jäi ennen lopetuksen painamista</param>
        /// <param name="peliID">pelin ID, jos uusi peli -> -1</param>
        public TallennusPeli(Pelaaja pelaaja1, Pelaaja pelaaja2, Pelaaja pelaaja3, Pelaaja pelaaja4, int vuoro, long peliID)
        {
            InitializeComponent();
            pelaaja1Nimi = pelaaja1.Nimi;
            pelaaja2Nimi = pelaaja2.Nimi;
            pelaaja3Nimi = pelaaja3.Nimi;
            pelaaja4Nimi = pelaaja4.Nimi;
            pelaaja1Pisteet = pelaaja1.Pisteet;
            pelaaja2Pisteet = pelaaja2.Pisteet;
            pelaaja3Pisteet = pelaaja3.Pisteet;
            pelaaja4Pisteet = pelaaja4.Pisteet;
            vuoroLuku = vuoro;
            this.peliID = peliID;
        }

        //Kun valitaan lopetus ilman tallennusta, asetetaan vastaus tiettyyn arvoon.
        private void lopetaTallentamatta_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        //Kun painetaan tallenna peli, tarkistetaan ensin onko pelin ID -1.
        private void tallennaPeli_Click(object sender, EventArgs e)
        {
            //Jos pelin ID on -1, kutsutaan uuden pelin tallennusta.
            if (peliID == -1)
            {
                TallennetaankoUusi();
            }
            //Muutoin kutsutaan vanhan pelin tallennusta.
            else
            {
                TallennetaankoVanha();
            }
        }

        //Kun painetaan peruuta, suljetaan käyttöliittymä.
        private void peruuta_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Metodi, jolla tallennetaan uusi peli.
        /// </summary>
        private void TallennetaankoUusi()
        {
            //luodaan muuttuja uudelle ID:lle
            long uusiID = 0;
            //määritellään käytettävän tietokannan polku
            string polku = "Data Source=" + System.Environment.CurrentDirectory + @"\sikanoppa.db";
            //muuttujat onnistumis- ja epäonnistumisviestille sekä otsikolle
            string viestiOnnistui;
            string viestiEiOnnistunut = "Tietojen tallennus epäonnistui";
            string otsikko = "Ilmoitus";
            //muuttujat kuittausnapille sekä ilmoituksen kuittaukselle
            MessageBoxButtons kuittaa = MessageBoxButtons.OK;
            DialogResult naytaViesti;
            //muuttujat, joilla tiedetään tuliko tietokantakyselyissä virhettä
            int x1 = -1;
            int x2 = -1;
            //muuttuja, jolla tarkistetaan onko tietokannasta haetun maksimi-ID:n arvo null.
            object tallennettavaID;
            //määritellään uusi yhteys ja käsketään sen käyttää aiemmin määriteltyä polkua
            using (SQLiteConnection con = new SQLiteConnection(polku))
            {
                //avataan kyseinen yhteys
                con.Open();
                //pistetään maksimi-ID:n valinta kyselyyn.
                string select = "SELECT MAX(pelipelaajat.PeliID) FROM pelipelaajat";
                //tehdään uusi komento, joka käyttää annettua yhteyttä sekä kyselyä
                using (SQLiteCommand cmdMAX = new SQLiteCommand(select, con))
                {
                    //tehdään uusi datalukija, joka käyttää aiemmin määriteltyä komentoa
                    using (SQLiteDataReader tiedonHakija = cmdMAX.ExecuteReader())
                    {
                        //jos datalukija löytää rivejä
                        if (tiedonHakija.HasRows)
                        {
                            //kun datalukija lukee, haetaan suurin ID taulusta pelipelaajat ja tallennetaan se muuttujaan
                            while (tiedonHakija.Read())
                            {
                                tallennettavaID = tiedonHakija["MAX(pelipelaajat.PeliID)"];
                                //jos tietokannasta haettu ID on null, asetetaan se nollaksi
                                if (tallennettavaID == DBNull.Value)
                                {
                                    tallennettavaID = 0;
                                }
                                //muutoin lisätään siihen yksi ja tallennetaan se uuteen muuttujaan.
                                else
                                {
                                    uusiID = Convert.ToInt64(tallennettavaID) + 1;
                                }
                            }
                        }
                    }
                }
                //tallennetaan uusi kysely muuttujaan
                string insert1 = "INSERT INTO pelitiedot (PeliID, Pelaaja1Pisteet, Pelaaja2Pisteet, Pelaaja3Pisteet, Pelaaja4Pisteet, Vuoro) VALUES (@pelinID, @pelaajan1Pisteet, @pelaajan2Pisteet, @pelaajan3Pisteet, @pelaajan4Pisteet, @vikaVuoro)";
                //tehdään uusi komento aiemmin luodulla yhteydellä sekä äsken luodulla kyselyllä
                using (SQLiteCommand laitetaanTieto = new SQLiteCommand(insert1, con))
                {
                    //määritetään kyselyssä annettujen parametrien arvot
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@pelinID", uusiID));
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@pelaajan1Pisteet", pelaaja1Pisteet));
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@pelaajan2Pisteet", pelaaja2Pisteet));
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@pelaajan3Pisteet", pelaaja3Pisteet));
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@pelaajan4Pisteet", pelaaja4Pisteet));
                    laitetaanTieto.Parameters.Add(new SQLiteParameter("@vikaVuoro", vuoroLuku));
                    //yritetään suorittaa kysely
                    try
                    {
                        laitetaanTieto.ExecuteNonQuery();
                    }
                    //jos virheitä ilmenee, asetetaan x1-muuttuja nollaan
                    catch (Exception)
                    {
                        x1 = 0;
                    }
                }
                //luodaan uusi kysely
                string insert2 = "INSERT INTO pelipelaajat (PeliID, Pelaaja1, Pelaaja2, Pelaaja3, Pelaaja4) VALUES (@pelinID, @pelaajan1Nimi, @pelaajan2Nimi, @pelaajan3Nimi, @pelaajan4Nimi)";
                //luodaan uusi yhteys aiemmin luodulla yhteydellä sekä äsken luodulla kyselyllä
                using (SQLiteCommand laitetaanTieto2 = new SQLiteCommand(insert2, con))
                {
                    //määritetään kyselyssä annettujen parametrien arvot
                    laitetaanTieto2.Parameters.Add(new SQLiteParameter("@pelinID", uusiID));
                    laitetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan1Nimi", pelaaja1Nimi));
                    laitetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan2Nimi", pelaaja2Nimi));
                    laitetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan3Nimi", pelaaja3Nimi));
                    laitetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan4Nimi", pelaaja4Nimi));
                    //yritetään suorittaa kysely
                    try
                    {
                        laitetaanTieto2.ExecuteNonQuery();
                    }
                    //jos virheitä ilmenee, asetetaan x2-muuttuja nollaksi
                    catch (Exception)
                    {
                        x2 = 0;
                    }
                }
            }
            //jos x1 tai x2 on nolla, näytetään virheilmoitus
            if (x1 == 0 || x2 == 0)
            {

                naytaViesti = MessageBox.Show(viestiEiOnnistunut, otsikko, kuittaa);
                DialogResult = DialogResult.Cancel;
            }
            //jos ne eivät ole muuttuneet, näytetään onnistumisilmoitus
            else if (x1 == -1 || x2 == -1)
            {
                viestiOnnistui = "Tietojen tallennus onnistui. Ota ylös pelin ID: " + uusiID;
                naytaViesti = MessageBox.Show(viestiOnnistui, otsikko, kuittaa);
                DialogResult = DialogResult.Yes;
            }
        }

        /// <summary>
        /// Metodi, jolla tallennetaan jo kerran tallennettu peli.
        /// </summary>
        private void TallennetaankoVanha()
        {
            //asetetaan tietokannan polku muuttujaan
            string polku = "Data Source=" + System.Environment.CurrentDirectory + @"\sikanoppa.db";
            //luodaan onnistumis- sekä epäonnistumisviestille ja otsikolle muuttujat
            string viestiOnnistui;
            string viestiEiOnnistunut = "Tietojen tallennus epäonnistui";
            string otsikko = "Ilmoitus";
            //luodaan kuittausnappulalle sekä sen tulokselle muuttujat
            MessageBoxButtons kuittaa = MessageBoxButtons.OK;
            DialogResult naytaViesti;
            //luodaan kaksi lukumuuttujaa, joilla tarkistetaan, ilmenikö kyselyissä virheitä
            int x1 = -1;
            int x2 = -1;
            //luodaan uusi yhteys äsken määritellyllä polulla
            using (SQLiteConnection con = new SQLiteConnection(polku))
            {
                //avataan yhteys
                con.Open();
                //luodaan uusi kysely
                string kysely = "UPDATE pelitiedot SET Pelaaja1Pisteet = :pelaajan1Pisteet, Pelaaja2Pisteet = :pelaajan2Pisteet, Pelaaja3Pisteet = :pelaajan3Pisteet, Pelaaja4Pisteet = :pelaajan4Pisteet, Vuoro = :vikaVuoro WHERE PeliID = :peliID;";
                //luodaan uusi komento äsken luodulla yhteydellä sekä kyselyllä
                using (SQLiteCommand tallennetaanTieto = new SQLiteCommand(kysely, con))
                {
                    //määritellään kyselyn parametrien arvot
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("peliID", peliID));
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("pelaajan1Pisteet", pelaaja1Pisteet));
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("pelaajan2Pisteet", pelaaja2Pisteet));
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("pelaajan3Pisteet", pelaaja3Pisteet));
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("pelaajan4Pisteet", pelaaja4Pisteet));
                    tallennetaanTieto.Parameters.Add(new SQLiteParameter("vikaVuoro", vuoroLuku));
                    //yritetään suorittaa kysely
                    try
                    {
                        tallennetaanTieto.ExecuteNonQuery();
                    }
                    //jos suorittamisessa ilmenee virheitä, asetetaan x1 arvoon 0
                    catch (Exception)
                    {
                        x1 = 0;
                    }
                    //luodaan uusi kysely
                    string kysely2 = "UPDATE pelipelaajat SET Pelaaja1 = @pelaajan1Nimi, Pelaaja2 = @pelaajan2Nimi, Pelaaja3 = @pelaajan3Nimi, Pelaaja4 = @pelaajan4Nimi WHERE PeliID = :peliID";
                    //luodaan uusi komento aiemmin määritellyllä yhteydellä sekä äsken luodulla komennolla
                    using (SQLiteCommand tallennetaanTieto2 = new SQLiteCommand(kysely2, con))
                    {
                        //asetetaan kyselyn parametrien arvot haluttuihin
                        tallennetaanTieto2.Parameters.Add(new SQLiteParameter("peliID", peliID));
                        tallennetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan1Nimi", pelaaja1Nimi));
                        tallennetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan2Nimi", pelaaja2Nimi));
                        tallennetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan3Nimi", pelaaja3Nimi));
                        tallennetaanTieto2.Parameters.Add(new SQLiteParameter("@pelaajan4Nimi", pelaaja4Nimi));
                        //yritetään suorittaa kysely
                        try
                        {
                            tallennetaanTieto2.ExecuteNonQuery();
                        }
                        //jos suorittaminen ei onnistu, asetetaan x2 arvoon 0
                        catch (Exception)
                        {
                            x2 = 0;
                        }
                    }
                }
                //jos x1 tai x2 on arvossa 0, näytetään epäonnistumisilmoitus
                if (x1 == 0 || x2 == 0)
                {
                    naytaViesti = MessageBox.Show(viestiEiOnnistunut, otsikko, kuittaa);
                    DialogResult = DialogResult.Cancel;
                }
                //jos ne eivät ole muuttuneet, näytetään onnistumisilmoitus
                else if (x1 == -1 || x2 == -1)
                {
                    viestiOnnistui = "Tietojen tallennus onnistui. Ota ylös pelin ID: " + peliID;
                    naytaViesti = MessageBox.Show(viestiOnnistui, otsikko, kuittaa);
                    DialogResult = DialogResult.Yes;
                }
            }
        }
    }
}