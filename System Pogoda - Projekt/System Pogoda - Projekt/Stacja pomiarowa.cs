using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa tworząca obiekt Stacja pomiarowa
    /// Implementuje interfejs ICloneable oraz IComparable<Stacja_pomiarowa>
    /// </summary>

    public class Stacja_pomiarowa : ICloneable, IComparable<Stacja_pomiarowa>
    {

        [XmlIgnore] public string nazwa;
        [XmlIgnore] public string miejscowosc;
        [XmlIgnore] public double wysokoscNpm;
        [XmlIgnore] public List<Zjawisko_pogodowe> zjawiska;


        /// <summary>
        /// Konstruktor bazowy 
        /// </summary>

        public Stacja_pomiarowa()
        {
            Nazwa = null;
            Miejscowosc = null;
            WysokoscNpm = 0;
            Zjawiska = null;
        }
        /// <summary>
        /// Konstruktor parametryczny 
        /// </summary>
        public Stacja_pomiarowa(string miejscowosc, double wysokoscNpm)
        {
            Miejscowosc = miejscowosc;
            WysokoscNpm = wysokoscNpm;
            Zjawiska = new List<Zjawisko_pogodowe>();
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Miejscowosc { get => miejscowosc; set => miejscowosc = value; }
        public double WysokoscNpm { get => wysokoscNpm; set => wysokoscNpm = value; }
        public List<Zjawisko_pogodowe> Zjawiska { get => zjawiska; set => zjawiska = value; }

        /// <summary>
        /// Funkcja dodająca do stacji zjawisko pogodowe
        /// </summary>
        /// <param name="zp">Zjawisko pogodowe</param>
        public void Dodaj(Zjawisko_pogodowe zp)
        {
            Zjawiska.Add(zp);
        }

        /// <summary>
        /// Funkcja znajdująca w danej stacji zjawisko po dacie
        /// </summary>
        /// <param name="data">Data obserwacji zjawiska</param>
        /// <returns>Lista Zjawisk zaobserwowanych danego dnia</returns>
        public List<Zjawisko_pogodowe> WyszukajZjawiskaPoDacie(string data)
        {
            DateTime dataNew;
            List<Zjawisko_pogodowe> listaZjawisk = new List<Zjawisko_pogodowe>();
            DateTime.TryParseExact(data, new[] { "dd/MM/yyyy", "dd/MM/yyyy", "dd-MM-yyyy", "dd-MM-yyyy", "yyyy.MM.dd", "yyyy.MM.dd", "dd.MM.yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out dataNew);
            foreach (Zjawisko_pogodowe zp in Zjawiska)
            {
                if (zp.DataObserwacji.Date.ToString("dd-MM-yyyy") == dataNew.Date.ToString("dd-MM-yyyy"))
                {
                    listaZjawisk.Add(zp);
                }
            }
            return listaZjawisk;
        }

        /// <summary>
        /// Funkcja sortująca zjawisko po dacie obserwacji
        /// </summary>
        public void Sortuj()
        {
            Zjawiska.Sort();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stacja: " + Nazwa + ", Wysokość n.p.m.: " + WysokoscNpm + "m");
            if (Zjawiska.Count != 0)
            {
                sb.AppendLine("Zaobserwowane zjawiska: \n");
                foreach (Zjawisko_pogodowe zp in Zjawiska)
                {
                    sb.AppendLine(zp.ToString());
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }


        /// <summary>
        /// Funkcja głęboko klonująca stację pomiarową
        /// </summary>
        /// <returns> Kopia stacji pomiarowej</returns>
        public object Clone()
        {
            Stacja_pomiarowa klon = new Stacja_pomiarowa(Miejscowosc, WysokoscNpm);
            foreach (Zjawisko_pogodowe z in Zjawiska)
            {
                klon.Zjawiska.Add(z); 
            }
            return klon;
        }

        /// <summary>
        /// Funkcja sortująca stacje po nazwie 
        /// </summary>
        public int CompareTo(Stacja_pomiarowa other)
        {
            return Nazwa.CompareTo(other.Nazwa);
        }
    }
}
