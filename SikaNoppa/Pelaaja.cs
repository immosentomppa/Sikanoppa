using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SikaNoppa
{
    /// <summary>
    /// Luokka, jolla luodaan uusi pelaajaolio.
    /// </summary>
    public class Pelaaja
    {
        //Pelaajan nimi ja pisteet.
        private string nimi;
        private int pisteet;
        /// <summary>
        /// Alustusmetodi, jolla uusi pelaajaolio tehdään. Sille kuljetetaan käyttäjän antama nimi sekä pisteet.
        /// </summary>
        /// <param name="nimi">käyttäjän antama nimi</param>
        /// <param name="pisteet">käyttäjän antama pistemäärä</param>
        public Pelaaja(string nimi, int pisteet)
        {
            //tallennetaan ominaisuudet luokassa sijaitseviin muuttujiin
            this.nimi = nimi;
            this.pisteet = pisteet;
        }

        /// <summary>
        /// Ominaisuus, jolla voidaan hakea pelaajan pistesaldo tai tarvittaessa muuttaa sitä.
        /// </summary>
        public int Pisteet
        {
            get
            {
                return pisteet;
            }
            set
            {
                pisteet = value;
            }
        }

        /// <summary>
        /// Ominaisuus, jolla voidaan hakea pelaajan nimi tai tarvittaessa muuttaa sitä.
        /// </summary>
        public string Nimi
        {
            get
            {
                return nimi;
            }
            set
            {
                nimi = value;
            }
        }

    }
}
