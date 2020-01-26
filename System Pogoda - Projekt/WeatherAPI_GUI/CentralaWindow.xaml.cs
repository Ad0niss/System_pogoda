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
        int usuwanie = 0;
        public CentralaWindow()
        {
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            btn_back_1.Visibility = Visibility.Visible;
            lab_usuwanie.Visibility = Visibility.Collapsed;
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
            c_Slask_xml.Sortuj();
            foreach (Stacja_pomiarowa s in c_Slask_xml.Stacje)
            {
                listbox_Stacje.Items.Add(s.Nazwa.ToString() + ", " + s.wysokoscNpm + " m.n.p.m");
            }
        }

        private void btn_back_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ListBox_Stacje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(usuwanie % 2 == 0)
            {
                foreach (Stacja_pomiarowa s in c_Slask_xml.Stacje)
                {
                    if (listbox_Stacje.SelectedItem.ToString() == s.Nazwa + ", " + s.wysokoscNpm + " m.n.p.m")
                    {
                        StacjaWindow cw = new StacjaWindow(s.Nazwa);
                        cw.Show();
                        Close();
                    }
                }
            }
            else
            {
                foreach (Stacja_pomiarowa s in c_Slask_xml.Stacje)
                {
                    if (listbox_Stacje.SelectedItem.ToString() == s.Nazwa + ", " + s.wysokoscNpm + " m.n.p.m")
                    {
                        c_Slask_xml.UsunStacje(s);
                        c_Slask_xml.ZapiszXML("test.xml");
                        Close();
                        return;
                    }
                }
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            DodajStacjeWindow ds = new DodajStacjeWindow();
            ds.Show();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            usuwanie++;
            if (usuwanie % 2 == 0)
            {
                lab_usuwanie.Visibility = Visibility.Collapsed;
            }
            else
            {
                lab_usuwanie.Visibility = Visibility.Visible;
            }
        }
    }
}
