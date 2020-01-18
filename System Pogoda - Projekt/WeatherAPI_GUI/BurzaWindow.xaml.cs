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
    /// Logika interakcji dla klasy BurzaWindow.xaml
    /// </summary>
    public partial class BurzaWindow : Window
    {
        public BurzaWindow(Burza zp)
        {
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            lab_rozp.Content = zp.DataObserwacji.ToString("dd-MM-yyyy HH:mm");
            lab_zak.Content = zp.DataZakonczenia.ToString("dd-MM-yyyy HH:mm");
            lab_wind.Content = zp.PredkoscWiatru + " m/s";
            lab_temp.Content = zp.Temperatura + "°C";
            lab_pressure.Content = zp.SrednieCisnienieAtm + " hPa";
            lab_blyskawica.Content = zp.IloscWyladowan + " wyładowań";
            lab_opady.Content = zp.IloscOpadowNaM2 + " mm na metr kwadratowy";
            lab_srednica.Content = "Średnica kropel: " + zp.SrednicaKropel + " mm";
            if (zp.zagrozenie == Skala_zagr.neutralne)
            {
                lab_SkalaZagrozenia.Content = "Zjawisko neutralne";
                lab_SkalaZagrozenia.Foreground = Brushes.Gray;
            }
            else if (zp.zagrozenie == Skala_zagr.niebezpieczne)
            {
                lab_SkalaZagrozenia.Content = "Zjawisko niebezpieczne!!";
                lab_SkalaZagrozenia.Foreground = Brushes.Orange;
            }
            else if (zp.zagrozenie == Skala_zagr.możliwie_niebezpieczne)
            {
                lab_SkalaZagrozenia.Content = "Zjawisko możliwie niebezpieczne!";
                lab_SkalaZagrozenia.Foreground = Brushes.Yellow;
            }
            else if (zp.zagrozenie == Skala_zagr.bardzo_niebezpieczne)
            {
                lab_SkalaZagrozenia.Content = "Zjawisko bardzo niebezpieczne!!!";
                lab_SkalaZagrozenia.Foreground = Brushes.Red;
            }
            if (zp.Typ == Typ.fronatlny)
            {
                lab_typ.Content = "Opad frontalny";
            }
            else if (zp.Typ == Typ.konwekcyjny)
            {
                lab_typ.Content = "Opad konwekcyjny";
            }
            else if (zp.Typ == Typ.orograficzny)
            {
                lab_typ.Content = "Opad orograficzny";
            }
        }
        private void MoveBottomRightEdgeOfWindow()
        {
            Left = Application.Current.MainWindow.Left;
            Top = Application.Current.MainWindow.Top;
        }

        private void btn_back_2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
