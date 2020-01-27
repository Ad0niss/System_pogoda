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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherAPI_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MoveBottomRightEdgeOfWindow();
        }

        private void Pogoda_Click(object sender, RoutedEventArgs e)
        {
            okno_pogodowe oknoPogoda = new okno_pogodowe();
            oknoPogoda.Show();
        }

        private void Stacja_Pogodowa_Click(object sender, RoutedEventArgs e)
        {
            CentralaWindow centralaPogodowaWindow = new CentralaWindow();
            centralaPogodowaWindow.Show();
        }

        public void MoveBottomRightEdgeOfWindow()
        {
            Left = 300;
            Top = 300;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Autorzy a = new Autorzy();
            a.Show();
        }
    }
}
