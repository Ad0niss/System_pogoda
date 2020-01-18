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
    public partial class StacjaWindow : Window
    {
        public Stacja_pomiarowa sp;
        string nazwa;
        public StacjaWindow(string name, Stacja_pomiarowa s)
        {
            nazwa = name;
            sp = s;
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            lab_Stacja.Content = "Stacja pogodowa " + nazwa;
            lab_Stacja.Visibility = Visibility.Visible;
            DodajListBoxy();
        }

        private void MoveBottomRightEdgeOfWindow()
        {
            Left = Application.Current.MainWindow.Left;
            Top = Application.Current.MainWindow.Top;
        }

        private void btn_back_1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DodajListBoxy()
        {
            int counter;
            sp.Sortuj();
            foreach (Zjawisko_pogodowe z in sp.Zjawiska)
            {
                counter = 0;
                if (listbox_Zjawiska.Items.Count == 0)
                {
                    listbox_Zjawiska.Items.Add(z.dataObserwacji.Date.ToString("dd-MM-yyyy"));
                }
                foreach (string lb in listbox_Zjawiska.Items)
                {
                    if (lb == z.dataObserwacji.Date.ToString("dd-MM-yyyy"))
                    {
                        counter = 1;
                        break;
                    }
                }
                if (counter == 0)
                {
                    listbox_Zjawiska.Items.Add(z.dataObserwacji.Date.ToString("dd-MM-yyyy"));
                }
            }
        }

        private void ListBox_Zjawiska_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                List<Zjawisko_pogodowe> zpList;
                zpList=sp.WyszukajZjawiskaPoDacie(listbox_Zjawiska.SelectedItem.ToString());
                foreach (Zjawisko_pogodowe z in zpList)
                {
                    if (listbox_Zjawiska.SelectedItem.ToString() == z.DataObserwacji.Date.ToString("dd-MM-yyyy"));
                    {
                        ZjawiskaWindow zw = new ZjawiskaWindow(zpList, nazwa);
                        zw.Show();
                        break;
                    }
                }
            }
        }
    }
}
