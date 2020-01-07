using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    public class Burza: Opad_deszczu
    {
        [XmlIgnore] public int iloscWyladowan;
        public Burza() : base()
        {
            IloscWyladowan = 0;
        }
        public Burza(string datar, string dataz, Skala_zagr zagrozenie, int iloscWyladowan, double iloscOpadowNa_M2, double srednicakropel, Typ typ, decimal temp, double sredniecisnienieatm, double predkoscwiatru) : base(datar, dataz, zagrozenie, iloscOpadowNa_M2, srednicakropel, typ, temp, sredniecisnienieatm, predkoscwiatru)
        {
            IloscWyladowan = iloscWyladowan;
        }

        public int IloscWyladowan { get => iloscWyladowan; set => iloscWyladowan = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Burza: " + Baza());  // tak lepiej
            //sb.Append("Burza: " + ", Zaobserwowano: " + DataObserwacji + ", Temperatura początkowa: " + Temperatura + "°C" + ", Śr. ciśnienie atm.: " + SrednieCisnienieAtm + "Pa" + ", Skala zagrożenia: " + Zagrozenie.ToString());
            sb.Append(", Ilość wyładowań atmosferycznych: " + IloscWyladowan + ", Ilość opadów na m^2: " + IloscOpadowNaM2 + "mm" + ", Średnica kropel: " + SrednicaKropel + "mm" + ", Prędkość wiatru: " + PredkoscWiatru + "km/h" + ", Czas trwania: " + CzasTrwania + " minut");
            return sb.ToString();
        }
    }
}
