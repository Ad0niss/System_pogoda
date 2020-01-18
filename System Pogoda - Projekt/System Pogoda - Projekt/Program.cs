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
                Burza b2 = new Burza("17/11/2019 15:18", "21/11/2019 15:55", Skala_zagr.możliwie_niebezpieczne, 15, 315, 4, Typ.fronatlny, -24, 1005, 55);
                Burza b3 = new Burza("17/11/2019 15:25", "22/11/2019 15:55", Skala_zagr.niebezpieczne, 15, 315, 4, Typ.konwekcyjny, -24, 1005, 55);
                Burza b4 = new Burza("17/11/2019 15:45", "23/11/2019 15:55", Skala_zagr.bardzo_niebezpieczne, 15, 315, 4, Typ.orograficzny, -24, 1005, 55);
                Burza b5 = new Burza("17/11/2019 16:07", "24/11/2019 15:55", Skala_zagr.niebezpieczne, 15, 315, 4, Typ.konwekcyjny, -24, 1005, 55);
                Burza b6 = new Burza("17/11/2019 17:12", "25/11/2019 15:55", Skala_zagr.neutralne, 15, 315, 4, Typ.fronatlny, -24, 1005, 55);
                Tornado t1 = new Tornado("17/11/2019 15:07", "19/11/2019 15:55", Skala_zagr.neutralne, 32m, 1000, 55, SkalaFujity.F4);
                Tornado t2 = new Tornado("17/11/2019 15:08", "19/11/2019 15:55", Skala_zagr.bardzo_niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                Tornado t3 = new Tornado("17/11/2019 15:09", "19/11/2019 15:55", Skala_zagr.niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                Tornado t4 = new Tornado("20/11/2019 15:10", "21/11/2019 15:55", Skala_zagr.możliwie_niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                Tornado t5 = new Tornado("17/11/2019 15:11", "19/11/2019 15:55", Skala_zagr.bardzo_niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                Tornado t6 = new Tornado("17/11/2019 15:12", "19/11/2019 15:55", Skala_zagr.bardzo_niebezpieczne, 32m, 1000, 55, SkalaFujity.F4);
                Opad_deszczu od2 = new Opad_deszczu("18/11/2019 16:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_deszczu od3 = new Opad_deszczu("20/11/2019 17:07", "21/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_deszczu od4 = new Opad_deszczu("18/11/2019 18:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_deszczu od5 = new Opad_deszczu("18/11/2019 19:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_sniegu os1 = new Opad_sniegu("18/11/2019 16:06", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_sniegu os2 = new Opad_sniegu("20/11/2019 17:06", "21/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_sniegu os3 = new Opad_sniegu("18/11/2019 18:06", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_sniegu os4 = new Opad_sniegu("20/11/2019 19:08", "21/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_sniegu os5 = new Opad_sniegu("18/11/2019 10:05", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og1 = new Opad_gradu("20/11/2019 17:07", "21/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og2 = new Opad_gradu("20/11/2019 17:37", "21/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og3 = new Opad_gradu("18/11/2019 18:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og4 = new Opad_gradu("18/11/2019 18:34", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og5 = new Opad_gradu("18/11/2019 19:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                Opad_gradu og6 = new Opad_gradu("18/11/2019 20:07", "19/11/2019 15:55", Skala_zagr.neutralne, 15, 4, Typ.fronatlny, 59, 1130, 55);
                s1.Dodaj(b1);
                s1.Dodaj(b2);
                s1.Dodaj(b3);
                s1.Dodaj(b4);
                s1.Dodaj(b5);
                s1.Dodaj(b6);
                s1.Dodaj(t1);
                s1.Dodaj(t2);
                s1.Dodaj(t3);
                s1.Dodaj(t4);
                s1.Dodaj(t5);
                s1.Dodaj(t6);
                s1.Dodaj(od2);
                s1.Dodaj(od3);
                s1.Dodaj(od4);
                s1.Dodaj(od5);
                s1.Dodaj(os1);
                s1.Dodaj(os2);
                s1.Dodaj(os3);
                s1.Dodaj(os4);
                s1.Dodaj(os5);
                s1.Dodaj(og1);
                s1.Dodaj(og2);
                s1.Dodaj(og3);
                s1.Dodaj(og4);
                s1.Dodaj(og5);
                Console.WriteLine(c_Slask);
                s1.Sortuj(); //sortowanie zjawisk po dacie rozpoczęcia i zakończenia
                //Console.WriteLine(c_Slask);
                c_Slask.ZapiszXML("test.xml"); //serializacja
                Centrala c_Slask_xml = new Centrala();
                c_Slask_xml = (Centrala)c_Slask_xml.OdczytajXML("test.xml"); //deserializacja
                Console.WriteLine("------------------------------------");
                Console.WriteLine(c_Slask_xml);


                //List<Zjawisko_pogodowe> zp;
                //zp = s1.WyszukajZjawiskaPoDacie("18-11-2019");
                //foreach (Zjawisko_pogodowe z in zp)
                //{
                //    Console.WriteLine(z);
                //}


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
