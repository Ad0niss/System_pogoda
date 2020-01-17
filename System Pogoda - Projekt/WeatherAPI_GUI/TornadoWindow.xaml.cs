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
    /// Logika interakcji dla klasy TornadoWindow.xaml
    /// </summary>
    public partial class TornadoWindow : Window
    {
        public TornadoWindow()
        {
            InitializeComponent();
        }

        private void btn_back_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
