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
    /// Logika interakcji dla klasy ZjawiskaWindow.xaml
    /// </summary>
    public partial class ZjawiskaWindow : Window
    {
        public List<Zjawisko_pogodowe> zjawiskaList;
        string nazwa;
        public ZjawiskaWindow(List<Zjawisko_pogodowe> zp, string name)
        {
            nazwa = name;
            zjawiskaList = zp;
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            lab_Zjawiska.Content = "Zjawiska pogodowe z dnia " + zjawiskaList[0].DataObserwacji.ToString("dd-MM-yyyy");
            lab_Stacja_1.Content = nazwa;
            lab_Stacja_1.Visibility = Visibility.Visible;
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
            foreach(Zjawisko_pogodowe zp in zjawiskaList)
            {
                listbox_Zjawiska.Items.Add(zp.DataObserwacji.ToString("HH:mm") + ", " + zp.GetType().Name.Replace("_", " ").ToString());
            }

        }

        private void ListBox_Zjawiska_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String[] strlistfromlistbox = (listbox_Zjawiska.SelectedItem.ToString()).Split(new[] { ", " }, StringSplitOptions.None);
            if (strlistfromlistbox.Length == 3)
            {
                strlistfromlistbox[1] = strlistfromlistbox[1] + "_" + strlistfromlistbox[2];
            }
            //MessageBox.Show(strlistfromlistbox[0].ToString());
            //MessageBox.Show(strlistfromlistbox[1].ToString());


            foreach (Zjawisko_pogodowe zp in zjawiskaList)
            {
                //MessageBox.Show(zp.DataObserwacji.ToString("HH:mm"));
                //MessageBox.Show(zp.GetType().Name.ToString().Replace("_", " "));
                if (strlistfromlistbox[0] == zp.DataObserwacji.ToString("HH:mm"))
                {
                    if (strlistfromlistbox[1] == zp.GetType().Name.Replace("_", " ").ToString())
                    {
                        if (zp.GetType().Name == "Tornado")
                        {
                            TornadoWindow cw = new TornadoWindow((Tornado)zp);
                            cw.Show();
                            break;
                        }
                        else if (zp.GetType().Name == "Burza")
                        {
                            BurzaWindow cw = new BurzaWindow((Burza)zp);
                            cw.Show();
                            break;
                        }

                    }
                }
            }
        }
    }
}
