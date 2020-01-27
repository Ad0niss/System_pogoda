using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    /// <summary>
    /// Klasa zawierająca obiekt opad gradu
    /// Dziedzicząca po klasie Opad
    /// </summary>
    public class Opad_gradu : Opad
    {
        [XmlIgnore] public double srednicaBrylekLodu;
        /// <summary>
        /// Konstruktor bazowy
        /// </summary>
        public Opad_gradu() : base()
        {
            SrednicaBrylekLodu = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny 
        /// </summary>
        public Opad_gradu(string datar, string dataz, Skala_zagr zagrozenie, double iloscOpadowNa_M2, double srednicaBrylek, Typ typ, decimal temp, double sredniecisnienieatm, double predkoscwiatru) : base(datar, dataz, zagrozenie, iloscOpadowNa_M2, typ, temp, sredniecisnienieatm, predkoscwiatru)
        {
            SrednicaBrylekLodu = srednicaBrylek;
        }

        public double SrednicaBrylekLodu { get => srednicaBrylekLodu; set => srednicaBrylekLodu = value; }

        public override string ToString()
        {
            return "Opad gradu: " + base.ToString() + ", Średnica bryłek: " + SrednicaBrylekLodu + "mm";
        }
    }
}
