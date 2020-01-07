using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    public enum SkalaFujity { F0, F1, F2, F3, F4, F5};
    [Serializable]
    public class Tornado : Zjawisko_pogodowe
    {
        [XmlIgnore] public SkalaFujity skala_Fujity;
        public Tornado() : base()
        {
            Skala_Fujity = SkalaFujity.F0;
        }

        public Tornado(string datar, string dataz, Skala_zagr zagrozenie, decimal temp, double sredniecisnienieatm, double predkoscwiatru, SkalaFujity skalaFujity) : base(datar, dataz, zagrozenie, temp, sredniecisnienieatm, predkoscwiatru)
        {
            Skala_Fujity = skalaFujity;
        }

        public SkalaFujity Skala_Fujity { get => skala_Fujity; set => skala_Fujity = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Tornado: " + base.ToString() + ", Skala Fujity: " + Skala_Fujity.ToString());
            return sb.ToString();
        }
    }
}
