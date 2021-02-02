using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SikaNoppa
{
    static class Program
    {
        /// <summary>
        /// Testiluokka, jolla avataan uusi aloituskäyttöliittymä.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Aloitus());
        }
    }
}
