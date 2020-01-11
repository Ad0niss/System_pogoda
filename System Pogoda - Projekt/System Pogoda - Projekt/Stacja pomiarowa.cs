using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    [Serializable]
    public class Stacja_pomiarowa
    {

        [XmlIgnore] public string nazwa;
        [XmlIgnore] public string miejscowosc;
        [XmlIgnore] public int wysokoscNpm;
        [XmlIgnore] public List<Zjawisko_pogodowe> zjawiska;

        public Stacja_pomiarowa()
        {
            Nazwa = null;
            Miejscowosc = null;
            WysokoscNpm = 0;
            Zjawiska = null;
        }

        public Stacja_pomiarowa(string miejscowosc, int wysokoscNpm)
        {
            Miejscowosc = miejscowosc;
            WysokoscNpm = wysokoscNpm;
            Zjawiska = new List<Zjawisko_pogodowe>();
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Miejscowosc { get => miejscowosc; set => miejscowosc = value; }
        public int WysokoscNpm { get => wysokoscNpm; set => wysokoscNpm = value; }
        public List<Zjawisko_pogodowe> Zjawiska { get => zjawiska; set => zjawiska = value; }

        public void Dodaj(Zjawisko_pogodowe zp)
        {
            Zjawiska.Add(zp);
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
    }
}
