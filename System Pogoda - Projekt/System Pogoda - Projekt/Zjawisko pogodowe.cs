using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
    public enum Skala_zagr { neutralne, możliwie_niebezpieczne, niebezpieczne, bardzo_niebezpieczne}

    /// <summary>
    /// Klasa abstrakcyjna zawierająca wspólne parametry dla każdego zjawiska pogodowego 
    /// </summary>
    public abstract class Zjawisko_pogodowe : IComparable<Zjawisko_pogodowe>
    {
        public DateTime dataObserwacji;
        public DateTime dataZakonczenia;
        public Skala_zagr zagrozenie;
        public double srednieCisnienieAtm;
        public decimal temperatura;
        public double predkoscWiatru;
        public double czasTrwania;

        /// <summary>
        /// Konstruktor bazowy 
        /// </summary>
        public Zjawisko_pogodowe()
        {
            DataObserwacji = DateTime.Now;
            DataZakonczenia = DateTime.Now;
            Zagrozenie = Skala_zagr.neutralne;
            SrednieCisnienieAtm = 1000;
            Temperatura = 0;
            PredkoscWiatru = 0;
        }

        /// <summary>
        /// Konstruktor parametryczny 
        /// </summary>
        public Zjawisko_pogodowe(string datar, string dataz, Skala_zagr zagrozenie, decimal temp, double sredniecisnienieatm, double predkoscwiatru)
        {
            DateTime.TryParseExact(datar, new[] { "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "dd-MM-yyyy HH:mm", "dd-MM-yyyy HH:mm:ss", "yyyy.MM.dd HH:mm", "yyyy.MM.dd HH:mm:ss", "dd.MM.yyyy HH:mm", "dd.MM.yyyy HH:mm:ss" }, null, DateTimeStyles.None, out dataObserwacji);
            DateTime.TryParseExact(dataz, new[] { "dd/MM/yyyy HH:mm", "dd/MM/yyyy HH:mm:ss", "dd-MM-yyyy HH:mm", "dd-MM-yyyy HH:mm:ss", "yyyy.MM.dd HH:mm", "yyyy.MM.dd HH:mm:ss", "dd.MM.yyyy HH:mm", "dd.MM.yyyy HH:mm:ss" }, null, DateTimeStyles.None, out dataZakonczenia);
            Temperatura = temp;
            SrednieCisnienieAtm = sredniecisnienieatm;
            Zagrozenie = zagrozenie;
            PredkoscWiatru = predkoscwiatru;
            CzasTrwania = (dataZakonczenia - DataObserwacji).TotalMinutes;
        }
        [XmlIgnore] public DateTime DataObserwacji { get => dataObserwacji; set => dataObserwacji = value; }
        [XmlIgnore] public Skala_zagr Zagrozenie { get => zagrozenie; set => zagrozenie = value; }

        [XmlIgnore]
        public decimal Temperatura
        {
            get => temperatura;
            set
            {
                if (value >= -50 && value <= 50)
                {
                    temperatura = value;
                }
                else
                {
                    throw new WrongTemperaturaException();
                }
            }
        }
        [XmlIgnore]
        public double PredkoscWiatru
        { 
            get => predkoscWiatru;
            set
            {
                if (value >= 0)
                {
                    predkoscWiatru = value;
                }
                else
                {
                    throw new WrongPredkoscWiatruException();
                }
            }
        }
        [XmlIgnore] public DateTime DataZakonczenia { get => dataZakonczenia; set => dataZakonczenia = value; }
        [XmlIgnore]
        public double CzasTrwania
        {
            get => czasTrwania;
            set
            {
                if (value >= 0)
                {
                    czasTrwania = value;
                }
                else
                {
                    throw new WrongDataException();
                }
            }
        }

        [XmlIgnore]
        public double SrednieCisnienieAtm
        {   
            
            get => srednieCisnienieAtm;
            set
            {
                if (value >= 800 && value <= 1200)
                {
                    srednieCisnienieAtm = value;
                }
                else
                {
                    
                    throw new WrongCisnienieException();
                }

            }
        }

        /// <summary>
        /// Funkcja porównująca zjawiska pogodowe na podstawie daty 
        /// </summary>
        public int CompareTo(Zjawisko_pogodowe other)
        {
            int wynik = DataObserwacji.CompareTo(other.DataObserwacji);
            if (wynik == 0)
            {
                return DataZakonczenia.CompareTo(other.DataZakonczenia);
            }
            else
            {
                return wynik;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Zaobserwowano: " + DataObserwacji);
            sb.Append(" do: " + DataZakonczenia);
            sb.Append(", Czas trwania: " + CzasTrwania + "min");
            sb.Append(", Skala zagrożenia: " + Zagrozenie.ToString());
            sb.Append(", Temperatura początkowa: " + Temperatura + "°C");
            sb.Append(", Śr. ciśnienie atm.: " + SrednieCisnienieAtm + "hPa");
            return sb.ToString();
        }
    }
}
