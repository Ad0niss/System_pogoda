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
    /// Logika interakcji dla klasy StacjaWindow.xaml
    /// </summary>
    public partial class CentralaWindow : Window
    {
        Centrala c_Slask_xml = new Centrala();

        public CentralaWindow()
        {
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            btn_back_1.Visibility = Visibility.Visible;
            c_Slask_xml = (Centrala)c_Slask_xml.OdczytajXML("test.xml"); //deserializacja
            DodajListBoxy();
        }

        private void MoveBottomRightEdgeOfWindow()
        {
            Left = Application.Current.MainWindow.Left;
            Top = Application.Current.MainWindow.Top;
        }

        private void DodajListBoxy()
        {
            foreach (Stacja_pomiarowa s in c_Slask_xml.Stacje)
            {
                listbox_Stacje.Items.Add(s.Nazwa.ToString());
            }
        }

        private void btn_back_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void ListBox_Stacje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IsLoaded)
            {
                foreach (Stacja_pomiarowa s in c_Slask_xml.Stacje)
                {
                    if (listbox_Stacje.SelectedItem.ToString() == s.Nazwa)
                    {
                        Stacja_pomiarowa sp;
                        sp = c_Slask_xml.Znajdz(s.Nazwa);
                        StacjaWindow cw = new StacjaWindow(s.Nazwa, sp);
                        cw.Show();
                    }
                }
            }
        }
    }
}
