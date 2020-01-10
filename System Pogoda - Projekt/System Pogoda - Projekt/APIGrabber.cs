using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace System_Pogoda___Projekt
{
        public class APIGrabber
        {
        string city;
        const string APIKEY = "23269ab567a2a8dc1c3991ee3a1f4422";

        public string City { get => city; set => city = value; }

        public APIGrabber(string city) 
        {
            this.City = city;
        }

        public string[] API()
        {   
            //pobieranie pliku xml z api OpenWeatherMap.
            var doc = new XmlDocument();
            string CurrentURL = "https://api.openweathermap.org/data/2.5/weather?q=" + City + "&mode=xml&units=metric&APPID=" + APIKEY;
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                doc.LoadXml(xmlContent);
                Console.WriteLine(xmlContent);
                
            }
            // pobieram dane pogodowe z xml'a( temp, wilgotnosc, wiatr,ogolne warunki pogodowe, wschod i zachod slonca. Na dole jest algorytm wyłuskujący wszystkie dane z pliku xml
            
            string[] tab_zjawisk = { "temperature", "humidity","speed","weather", "sun", "sun" };
            int j = 0;
            foreach (string i in tab_zjawisk)
            {
                string value = "value";
                if (j == 4)
                {
                    value = "rise";
                }
                if (j == 5)
                {
                    value = "set";
                }
                string temp_name = "//" + i;
                XmlNode temporary_node = doc.SelectSingleNode(temp_name);
                XmlAttribute temporary_value = temporary_node.Attributes[value];
                string zjawisko = temporary_value.Value;
                tab_zjawisk[j] = zjawisko;
                j++;
            }
            return tab_zjawisk;
            
        }
    }
}
