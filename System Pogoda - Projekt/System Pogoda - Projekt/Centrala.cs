using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_Pogoda___Projekt
{
   
    [XmlInclude(typeof(Opad_deszczu))]
    [XmlInclude(typeof(Opad_gradu))]
    [XmlInclude(typeof(Opad_sniegu))]
    [XmlInclude(typeof(Burza))]
    [XmlInclude(typeof(Tornado))]

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>


    public class Centrala : IWymagane
    {
        public string obszar;
        public List<Stacja_pomiarowa> Stacje;
        public int liczba_porzadkowa;

        public Centrala()
        {
            Obszar = null;
            Stacje = new List<Stacja_pomiarowa>();
        }

        public Centrala(string obszar)
        {
            Obszar = obszar;
            Stacje = new List<Stacja_pomiarowa>();
        }

        public Stacja_pomiarowa Znajdz(string nazwa)
        {
            foreach (Stacja_pomiarowa sp in Stacje)
            {
                if (sp.Nazwa == nazwa)
                {
                    return sp;
                }
            }
            return null;
        }
        public void Sortuj()
        {
            Stacje.Sort();
        }

        public Stacja_pomiarowa ZnajdzStacjePoZjawisku(Zjawisko_pogodowe zp)
        {
            foreach (Stacja_pomiarowa sp in Stacje)
                if (sp.Zjawiska.Contains(zp))
                {
                    return sp;
                }
            return null;
        }

        public string Obszar { get => obszar; set => obszar = value; }

        public void DodajStacje(Stacja_pomiarowa s)
        {
            liczba_porzadkowa = 1;
            foreach (Stacja_pomiarowa s1 in Stacje)
            {
                if (s.Miejscowosc == s1.Miejscowosc)
                {
                    liczba_porzadkowa++;
                }
            }
            s.Nazwa = Obszar + "_" + s.Miejscowosc + "/" + liczba_porzadkowa;
            Stacje.Add(s);
        }

        public void UsunStacje(Stacja_pomiarowa s)
        {
            liczba_porzadkowa--;
            Stacje.Remove(s);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Centrala: " + Obszar + "\n\n\n");
            foreach (Stacja_pomiarowa s in Stacje)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public virtual void ZapiszXML(string fname)
        {
            string newPath = Path.GetFullPath(Path.Combine(fname, @"..\..\..\..\" + fname));
            XmlSerializer xs = new XmlSerializer(typeof(Centrala));
            using (StreamWriter sw = new StreamWriter(newPath))
            {
                xs.Serialize(sw, this);
            }
        }


        public object OdczytajXML(string fname)
        {
            string newPath = Path.GetFullPath(Path.Combine(fname, @"..\..\..\..\"+fname));
            XmlSerializer xs = new XmlSerializer(typeof(Centrala));
            using (StreamReader sw = new StreamReader(newPath))
            {
                return xs.Deserialize(sw);
            }
        }

    }
}
// tutaj kolejna zmianka