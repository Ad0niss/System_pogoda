using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{

    /// <summary>
    /// Klasa tworząca obiekt Opad deszczu
    /// Dziedzicząca po klasie abstrakcyjnej Opad
    /// </summary>

    public class Opad_deszczu : Opad
    {
        [XmlIgnore] public double srednicaKropel;
        /// <summary>
        /// Konstruktor bazowy 
        /// </summary>
        public Opad_deszczu() : base()
        {
            SrednicaKropel = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny
        /// </summary>
        public Opad_deszczu(string datar, string dataz, Skala_zagr zagrozenie, double iloscOpadowNa_M2, double srednicakropel, Typ typ, decimal temp, double sredniecisnienieatm, double predkoscwiatru) : base(datar, dataz, zagrozenie, iloscOpadowNa_M2, typ, temp, sredniecisnienieatm, predkoscwiatru)
        {
            SrednicaKropel = srednicakropel;
        }

        public double SrednicaKropel { get => srednicaKropel; set => srednicaKropel = value; }

        public override string ToString()
        {
            return "Opad deszczu: " + base.ToString() + ", Średnica kropel: " + SrednicaKropel + "mm";
        }
    }
}
