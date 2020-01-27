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


namespace WeatherAPI_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Autorzy.xaml
    /// </summary>
    public partial class Autorzy : Window
    {
        public Autorzy()
        {
            InitializeComponent();
            MoveBottomRightEdgeOfWindow();
        }
        private void MoveBottomRightEdgeOfWindow()
        {
            Left = 300;
            Top = 300;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
