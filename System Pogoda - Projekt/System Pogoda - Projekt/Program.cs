using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Pogoda___Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            APIGrabber cyk = new APIGrabber("Kraków");
            cyk.API();
            try
            {
                Centrala c_Slask = new Centrala("Śląsk");
                Stacja_pomiarowa s1 = new Stacja_pomiarowa("Radzionków", 50);
                Stacja_pomiarowa s2 = new Stacja_pomiarowa("Ciechocinek", 150);
                Stacja_pomiarowa s3 = new Stacja_pomiarowa("Radzionków", 10);
                Stacja_pomiarowa s4 = new Stacja_pomiarowa("Miechowice", 2350);
                c_Slask.DodajStacje(s1);
                c_Slask.DodajStacje(s2);
                c_Slask.DodajStacje(s3);
                c_Slask.DodajStacje(s4);
                //Console.WriteLine(s1);
                //Console.WriteLine(s2);
                //Console.WriteLine(s3);
                //Console.WriteLine(s4);
                Opad_deszczu od1 = new Opad_deszczu("18/11/2019 15:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                s1.Dodaj(od1);
                Burza b1 = new Burza("17/11/2019 15:07", "20/11/2019 15:55", Skala_zagr.neutralne, 15, 315, 4, Typ.fronatlny, -24, 1005, 55);
                Tornado t1 = new Tornado("17/11/2019 15:07", "19/11/2019 15:55", Skala_zagr.bardzo_niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                s1.Dodaj(b1);
                s1.Dodaj(t1);
                Console.WriteLine(c_Slask);
                s1.Sortuj(); //sortowanie zjawisk po dacie rozpoczęcia i zakończenia
                Console.WriteLine(c_Slask);
                c_Slask.ZapiszXML("test.xml"); //serializacja
                
                Centrala c_Slask_xml = new Centrala();
                c_Slask_xml = (Centrala)c_Slask_xml.OdczytajXML("test.xml"); //deserializacja
                Console.WriteLine(c_Slask_xml);


            }
            catch (WrongCisnienieException)
            {
                Console.WriteLine("Podano błędną wartość cisnienia (800hPa, 1200hPa).");
            }
            catch (WrongTemperaturaException)
            {
                Console.WriteLine("Podano błędną wartość temperatury (-60°C, 60°C).");
            }
            catch (WrongPredkoscWiatruException)
            {
                Console.WriteLine("Podano błędną prędkość wiatru (nie może być ujemna).");
            }
            catch (WrongDataException)
            {
                Console.WriteLine("Podano nieprawidłowe daty.");
            }
        }
    }
}
