using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System_Pogoda___Projekt;

namespace WeatherAPI_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy okno_pogodowe.xaml
    /// </summary>
    public partial class okno_pogodowe : Window
    {
        public okno_pogodowe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // w tablicy są odpowiedni przekazane wartotci: temperatury, wilogotnosci, wiatru, ogolnej pogody, wschodu i zachodu
            APIGrabber pogoda = new APIGrabber(Wyszukiwarka.Text);
            string[] zjawiska= pogoda.API();
            lab_temperatura.Content = zjawiska[0];
            lab_humidity.Content = zjawiska[1];
            lab_wind.Content = zjawiska[2];
            lab_rain.Content = zjawiska[3];
            lab_sunrise.Content = zjawiska[4];
            lab_sunset.Content = zjawiska[5]; 

        }
    }
}
