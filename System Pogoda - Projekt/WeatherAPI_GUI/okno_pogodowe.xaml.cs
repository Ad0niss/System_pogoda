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
            MoveBottomRightEdgeOfWindow();
            wind.Visibility = Visibility.Collapsed;
            humid.Visibility = Visibility.Collapsed;
            cloudy.Visibility = Visibility.Collapsed;
            fog.Visibility = Visibility.Collapsed;
            sunrise.Visibility = Visibility.Collapsed;
            sunset.Visibility = Visibility.Collapsed;
            snowy.Visibility = Visibility.Collapsed;
            changable_rain.Visibility = Visibility.Collapsed;
            sunny.Visibility = Visibility.Collapsed;
            temp_image.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logo_icon.Visibility = Visibility.Collapsed;
            //ukryj();

            // w tablicy są odpowiedni przekazane wartości: temperatury, wilogotnosci, wiatru, ogolnej pogody, wschodu i zachodu oraz numer ogolnej pogody
            APIGrabber pogoda = new APIGrabber(Wyszukiwarka.Text);
            try
            {
                string[] zjawiska = pogoda.API();
                // przerabiam daty
                string sunrise_time = zjawiska[4].Substring(zjawiska[4].IndexOf("T") + 1);
                string sunset_time = zjawiska[5].Substring(zjawiska[5].IndexOf("T") + 1);
                int weather_id = Int32.Parse(zjawiska[6]);

                pokaz(weather_id);

                lab_temperatura.Content = zjawiska[0] + "st. C";
                lab_humidity.Content = zjawiska[1] + "%";
                lab_wind.Content = zjawiska[2] + "m/s";
                lab_rain.Content = zjawiska[3];
                lab_sunrise.Content = sunrise_time.ToString() + "GMT";
                lab_sunset.Content = sunset_time + "GMT";
                lab_ApiError.Content = "";
            }
            catch(Exception)
            {
                lab_temperatura.Content = "";
                lab_humidity.Content = "";
                lab_wind.Content = "";
                lab_rain.Content = "";
                lab_sunrise.Content = "";
                lab_sunset.Content = "";
                lab_ApiError.Content = "Podano błędną nazwę miasta!!";
                ukryj();
            }
        }

        private void MoveBottomRightEdgeOfWindow()
        {
            Left = Application.Current.MainWindow.Left;
            Top = Application.Current.MainWindow.Top;
        }

        private void pokaz(int weather_id)
        {
            wind.Visibility = Visibility.Visible;
            humid.Visibility = Visibility.Visible;
            sunrise.Visibility = Visibility.Visible;
            sunset.Visibility = Visibility.Visible;
            temp_image.Visibility = Visibility.Visible;
            if (weather_id < 600)
                changable_rain.Visibility = Visibility.Visible;
            else if (weather_id >= 600 && weather_id < 700)
                snowy.Visibility = Visibility.Visible;
            else if (weather_id >= 700 && weather_id < 800)
                fog.Visibility = Visibility.Visible;
            else if (weather_id == 800)
                sunny.Visibility = Visibility.Visible;
            else
                cloudy.Visibility = Visibility.Visible;
        }
        private void ukryj()
        {
            wind.Visibility = Visibility.Collapsed;
            humid.Visibility = Visibility.Collapsed;
            cloudy.Visibility = Visibility.Collapsed;
            fog.Visibility = Visibility.Collapsed;
            sunrise.Visibility = Visibility.Collapsed;
            sunset.Visibility = Visibility.Collapsed;
            snowy.Visibility = Visibility.Collapsed;
            changable_rain.Visibility = Visibility.Collapsed;
            sunny.Visibility = Visibility.Collapsed;
            temp_image.Visibility = Visibility.Collapsed;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Wyszukiwarka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
