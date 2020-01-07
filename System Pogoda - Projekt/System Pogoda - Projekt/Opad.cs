using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    public enum Typ { orograficzny, konwekcyjny, fronatlny};
    [Serializable]
    public abstract class Opad : Zjawisko_pogodowe
    {
        [XmlIgnore] public Typ typ;
        [XmlIgnore] public double iloscOpadowNaM2;

        public Typ Typ { get => typ; set => typ = value; }
        public double IloscOpadowNaM2 { get => iloscOpadowNaM2; set => iloscOpadowNaM2 = value; }


        public Opad() : base()
        {
            Typ = Typ.orograficzny;
            IloscOpadowNaM2 = 0;
        }

        public Opad(string datar, string dataz, Skala_zagr zagrozenie, double iloscOpadowNa_M2, Typ typ, decimal temp, double sredniecisnienieatm, double predkoscwiatru) : base(datar, dataz, zagrozenie, temp, sredniecisnienieatm, predkoscwiatru)
        {
            Typ = typ;
            IloscOpadowNaM2 = iloscOpadowNa_M2;
        }

        public virtual string Baza()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString() + ", Ilość opadów na m^2: " + IloscOpadowNaM2 + "mm" + ", Typ opadów: " + typ.ToString());
            return sb.ToString();
        }
    }
}
