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
    public class Stacja_pomiarowa : ICloneable, IComparable<Stacja_pomiarowa>
    {

        [XmlIgnore] public string nazwa;
        [XmlIgnore] public string miejscowosc;
        [XmlIgnore] public double wysokoscNpm;
        [XmlIgnore] public List<Zjawisko_pogodowe> zjawiska;

        public Stacja_pomiarowa()
        {
            Nazwa = null;
            Miejscowosc = null;
            WysokoscNpm = 0;
            Zjawiska = null;
        }

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

        public void Dodaj(Zjawisko_pogodowe zp)
        {
            Zjawiska.Add(zp);
        }


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

        public object Clone()
        {
            Stacja_pomiarowa klon = new Stacja_pomiarowa(Miejscowosc, WysokoscNpm);
            foreach (Zjawisko_pogodowe z in Zjawiska)
            {
                klon.Zjawiska.Add(z); 
            }
            return klon;
        }

        public int CompareTo(Stacja_pomiarowa other)
        {
            return Nazwa.CompareTo(other.Nazwa);
        }
    }
}
