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
    /// Logika interakcji dla klasy DodajStacjeWindow.xaml
    /// </summary>
    public partial class DodajStacjeWindow : Window
    {
        Centrala c_Slask_xml = new Centrala();
        public DodajStacjeWindow()
        {
            c_Slask_xml = (Centrala)c_Slask_xml.OdczytajXML("test.xml"); //deserializacja
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_wartoscnpm.Content = Math.Round(slider_wysokosc.Value,0).ToString() + " m.n.p.m";
        }
        

        private void Nazwa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_back_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Stacja_pomiarowa sp = new Stacja_pomiarowa(Nazwa.Text, Math.Round(slider_wysokosc.Value, 0));
            c_Slask_xml.DodajStacje(sp);
            c_Slask_xml.ZapiszXML("test.xml");
            End();
        }
        private void End()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(CentralaWindow))
                {
                    window.Close();
                }
                //if (window.GetType() == typeof(StacjaWindow))
                //{
                //    window.Close();
                //}
            }
            Close();
            CentralaWindow centralaPogodowaWindow = new CentralaWindow();
            centralaPogodowaWindow.Show();
        }
        private void MoveBottomRightEdgeOfWindow()
        {
            Left = Application.Current.MainWindow.Left;
            Top = Application.Current.MainWindow.Top;
        }
    }
}
