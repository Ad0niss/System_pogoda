using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy DodajZjawiskoWindow.xaml
    /// </summary>
    public partial class DodajZjawiskoWindow : Window
    {
        public string dataObserwacji;
        public string dataZakonczenia;
        public Stacja_pomiarowa sp;
        public Centrala c_Slask_xml = new Centrala();
        Skala_zagr skala;
        Typ typ;
        SkalaFujity skalaF;
        public DodajZjawiskoWindow(Stacja_pomiarowa s)
        {
            c_Slask_xml = (Centrala)c_Slask_xml.OdczytajXML("test.xml");
            sp = c_Slask_xml.Znajdz(s.Nazwa);
            MoveBottomRightEdgeOfWindow();
            InitializeComponent();
            slider_cisnienie.Value = 1000;
            lab_cisnienie_wart.Visibility = Visibility.Collapsed;
            Ukryj();
        }

        private void Ukryj()
        {
            lab_format.Visibility = Visibility.Collapsed;
            lab_skalaZagrozenia.Visibility = Visibility.Collapsed;
            slider_skalaZagrozenia.Visibility = Visibility.Collapsed;
            lab_temp.Visibility = Visibility.Collapsed;
            slider_temp.Visibility = Visibility.Collapsed;
            lab_cisnienie.Visibility = Visibility.Collapsed;
            slider_cisnienie.Visibility = Visibility.Collapsed;
            slider_predkoscWiatru.Visibility = Visibility.Collapsed;
            lab_predkoscWiatru.Visibility = Visibility.Collapsed;
            slider_iloscOpadow.Visibility = Visibility.Collapsed;
            lab_iloscOpadow.Visibility = Visibility.Collapsed;
            slider_srednicaKropel.Visibility = Visibility.Collapsed;
            lab_srednicaKropel.Visibility = Visibility.Collapsed;
            comboBox_typOpadow.Visibility = Visibility.Collapsed;
            lab_typOpadow.Visibility = Visibility.Collapsed;
            lab_iloscWyladowan.Visibility = Visibility.Collapsed;
            textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
            comboBox_skalaFujity.Visibility = Visibility.Collapsed;
            btn_add.Visibility = Visibility.Collapsed;
            lab_Error.Visibility = Visibility.Collapsed;
            btn_tryAgain.Visibility = Visibility.Collapsed;
            lab_cisnienie_wart.Visibility = Visibility.Collapsed;
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

        private void Pokaz()
        {
            lab_skalaZagrozenia.Visibility = Visibility.Visible;
            slider_skalaZagrozenia.Visibility = Visibility.Visible;
            lab_temp.Visibility = Visibility.Visible;
            slider_temp.Visibility = Visibility.Visible;
            lab_cisnienie.Visibility = Visibility.Visible;
            slider_cisnienie.Minimum = 800;
            slider_cisnienie.Visibility = Visibility.Visible;
            slider_predkoscWiatru.Visibility = Visibility.Visible;
            lab_predkoscWiatru.Visibility = Visibility.Visible;
            slider_iloscOpadow.Visibility = Visibility.Visible;
            lab_iloscOpadow.Visibility = Visibility.Visible;
            slider_srednicaKropel.Visibility = Visibility.Visible;
            lab_srednicaKropel.Visibility = Visibility.Visible;
            lab_typOpadow.Visibility = Visibility.Visible;
            comboBox_typOpadow.Visibility = Visibility.Visible;
            btn_add.Visibility = Visibility.Visible;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (comboBox_Zjawiska.SelectedIndex != 3)
            //{
            //    Pokaz();
            //    textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
            //    comboBox_skalaFujity.Visibility = Visibility.Collapsed;
            //    lab_iloscWyladowan.Visibility = Visibility.Collapsed;
            //    textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
            //}
            if (lab_cisnienie_wart.Content.ToString() == "1000 hPa")
            {
                lab_cisnienie_wart.Visibility = Visibility.Collapsed;
            }
            if (comboBox_Zjawiska.SelectedIndex == 0)
            {
                Pokaz();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica kropel";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 1)
            {
                Pokaz();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica płatków";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 2)
            {
                Pokaz();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica brylek lodu";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 3)
            {
                Pokaz();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Visible;
                lab_srednicaKropel.Content = "Średnica kropel";
                lab_iloscWyladowan.Content = "Ilość wyładowań";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 4)
            {
                Pokaz();
                lab_srednicaKropel.Visibility = Visibility.Collapsed;
                lab_srednicaKropel_wart.Visibility = Visibility.Collapsed;
                slider_srednicaKropel.Visibility = Visibility.Collapsed;
                lab_iloscOpadow.Visibility = Visibility.Collapsed;
                lab_iloscOpadow_wart.Visibility = Visibility.Collapsed;
                slider_iloscOpadow.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Visible;
                comboBox_skalaFujity.Visibility = Visibility.Visible;
                lab_iloscWyladowan.Content = "Skala Fujity";
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                if (comboBox_skalaFujity.SelectedIndex == 0)
                {
                    skalaF = SkalaFujity.F0;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 1)
                {
                    skalaF = SkalaFujity.F1;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 2)
                {
                    skalaF = SkalaFujity.F2;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 3)
                {
                    skalaF = SkalaFujity.F3;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 4)
                {
                    skalaF = SkalaFujity.F4;
                }
                else if (comboBox_skalaFujity.SelectedIndex ==5)
                {
                    skalaF = SkalaFujity.F5;
                }
            }
        }

        private void slider_skalaZagrozenia_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Math.Round(slider_skalaZagrozenia.Value, 0) == 0)
            {
                lab_Zagrozenie.Content = "Neutralne";
                lab_Zagrozenie.Foreground = Brushes.Gray;
                lab_Zagrozenie.FontSize = 16;
                skala = Skala_zagr.neutralne;
            }
            else if (Math.Round(slider_skalaZagrozenia.Value, 0) == 1)
            {
                lab_Zagrozenie.Content = "Możliwie niebezpieczne";
                lab_Zagrozenie.Foreground = Brushes.Yellow;
                lab_Zagrozenie.FontSize=18;
                skala = Skala_zagr.możliwie_niebezpieczne;
            }
            else if (Math.Round(slider_skalaZagrozenia.Value, 0) == 2)
            {
                lab_Zagrozenie.Content = "Niebezpieczne!";
                lab_Zagrozenie.Foreground = Brushes.Orange;
                lab_Zagrozenie.FontSize=20;
                skala = Skala_zagr.niebezpieczne;
            }
            else if (Math.Round(slider_skalaZagrozenia.Value, 0) == 3)
            {
                lab_Zagrozenie.Content = "Bardzo niebezpieczne!";
                lab_Zagrozenie.Foreground = Brushes.Red;
                lab_Zagrozenie.FontSize=22;
                skala = Skala_zagr.bardzo_niebezpieczne;
            }
        }


        private void slider_temp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            int number = (int)double.Parse(slider_temp.Value.ToString());
            if (slider_temp.Value > 0)
            {
                brush.Color = Color.FromRgb(255, (byte)(255 - number * 4), (byte)(255 - number * 5));
            }
            else
            {
                brush.Color = Color.FromRgb((byte)(255 - Math.Abs(number * 5)), (byte)(255 - Math.Abs(number * 2.5)), 255);
            }

            lab_temp_wart.Foreground = brush;
            lab_temp_wart.Content = Math.Round(slider_temp.Value, 2).ToString() + "°C";
        }

        private void slider_cisnienie_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            int number = (int)double.Parse(slider_cisnienie.Value.ToString());
            brush.Color = Color.FromRgb((byte)(255 - Math.Abs(1000 - number) * 1.26), (byte)(255 - Math.Abs(1000-number) * 0.9), 255);
            lab_cisnienie_wart.Visibility = Visibility.Visible;
            lab_cisnienie_wart.Content = Math.Round(slider_cisnienie.Value, 0).ToString() + " hPa";
            lab_cisnienie_wart.Foreground = brush;
        }

        private void slider_predkoscWiatru_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            int number = (int)double.Parse(slider_predkoscWiatru.Value.ToString());
            brush.Color = Color.FromRgb(255, (byte)(255 - (number) * 0.72), (byte)(255 - (number) * 0.72));
            lab_predkoscWiatru_wart.Content = Math.Round(slider_predkoscWiatru.Value, 2).ToString() + " km/h";
            lab_predkoscWiatru_wart.Foreground = brush;
        }

        private void slider_iloscOpadow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            int number = (int)double.Parse(slider_iloscOpadow.Value.ToString());
            brush.Color = Color.FromRgb((byte)(255 - (number) * 1.5), (byte)(255 - number),255);
            lab_iloscOpadow_wart.Content = Math.Round(slider_iloscOpadow.Value, 0).ToString() + " mm/m²";
            lab_iloscOpadow_wart.Foreground = brush;
        }

        private void slider_srednicaKropel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush brush = new SolidColorBrush();
            int number = (int)double.Parse(slider_srednicaKropel.Value.ToString());
            brush.Color = Color.FromRgb((byte)(255 - (number) * 60), 255, (byte)(255 - number * 30));
            lab_srednicaKropel_wart.Content = Math.Round(slider_srednicaKropel.Value, 3).ToString() + " mm";
            lab_srednicaKropel_wart.Foreground = brush;
        }

        private void ComboBox_Typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (SprawdzCzyDatySaWpisane())
            {
                if (SprawdzDaty())
                {
                    if (SprawdzCzas())
                    {
                        if (comboBox_Zjawiska.SelectedIndex == 0)
                        {
                            if (SprawdzPola_123())
                            {
                                typ = SprawdzTyp();
                                Opad_deszczu od = new Opad_deszczu(UstawCzasObs(), UstawCzasZak(), skala, Math.Round(slider_iloscOpadow.Value, 0), Math.Round(slider_srednicaKropel.Value, 3), typ, (decimal)Math.Round(slider_temp.Value, 2), Math.Round(slider_cisnienie.Value, 0), Math.Round(slider_predkoscWiatru.Value, 2));
                                sp.Dodaj(od);
                                c_Slask_xml.ZapiszXML("test.xml");
                                End();
                            }
                            else
                            {
                                WyswietlBladPola();
                                lab_Error.Content = "Nie podano jakiejś wartości!!";
                            }
                        }
                        else if (comboBox_Zjawiska.SelectedIndex == 1)
                        {
                            if (SprawdzPola_123())
                            {
                                typ = SprawdzTyp();
                                Opad_sniegu os = new Opad_sniegu(UstawCzasObs(), UstawCzasZak(), skala, Math.Round(slider_iloscOpadow.Value, 0), Math.Round(slider_srednicaKropel.Value, 3), typ, (decimal)Math.Round(slider_temp.Value, 2), Math.Round(slider_cisnienie.Value, 0), Math.Round(slider_predkoscWiatru.Value, 2));
                                sp.Dodaj(os);
                                c_Slask_xml.ZapiszXML("test.xml");
                                End();
                            }
                            else
                            {
                                WyswietlBladPola();
                                lab_Error.Content = "Nie podano jakiejś wartości!!";
                            }
                        }
                        else if (comboBox_Zjawiska.SelectedIndex == 2)
                        {
                            if (SprawdzPola_123())
                            {
                                typ = SprawdzTyp();
                                Opad_gradu og = new Opad_gradu(UstawCzasObs(), UstawCzasZak(), skala, Math.Round(slider_iloscOpadow.Value, 0), Math.Round(slider_srednicaKropel.Value, 3), typ, (decimal)Math.Round(slider_temp.Value, 2), Math.Round(slider_cisnienie.Value, 0), Math.Round(slider_predkoscWiatru.Value, 2));
                                sp.Dodaj(og);
                                c_Slask_xml.ZapiszXML("test.xml");
                                End();
                            }
                            else
                            {
                                WyswietlBladPola();
                                lab_Error.Content = "Nie podano jakiejś wartości!!";
                            }
                        }
                        else if (comboBox_Zjawiska.SelectedIndex == 3)
                        {
                            if (SprawdzPola_4())
                            {
                                if (SprawdzWyladowania())
                                {
                                    typ = SprawdzTyp();
                                    int wyladowania = Int32.Parse(textBox_iloscWyladowan.Text);
                                    Burza b = new Burza(UstawCzasObs(), UstawCzasZak(), skala, wyladowania, Math.Round(slider_iloscOpadow.Value, 0), Math.Round(slider_srednicaKropel.Value, 3), typ, (decimal)Math.Round(slider_temp.Value, 2), Math.Round(slider_cisnienie.Value, 0), Math.Round(slider_predkoscWiatru.Value, 2));
                                    sp.Dodaj(b);
                                    c_Slask_xml.ZapiszXML("test.xml");
                                    End();
                                }
                                else
                                {
                                    WyswietlBladPola();
                                    lab_Error.Content = "Podano błędną ilość wyładowań!!";
                                }
                            }
                            else
                            {
                                WyswietlBladPola();
                                lab_Error.Content = "Nie podano jakiejś wartości!!";
                            }
                        }
                        else if (comboBox_Zjawiska.SelectedIndex == 4)
                        {
                            if (SprawdzPola_5())
                            {
                                typ = SprawdzTyp();
                                Tornado tornado = new Tornado(UstawCzasObs(), UstawCzasZak(), skala, (decimal)Math.Round(slider_temp.Value, 2), Math.Round(slider_cisnienie.Value, 0), Math.Round(slider_predkoscWiatru.Value, 2), SprawdzSkale());
                                sp.Dodaj(tornado);
                                c_Slask_xml.ZapiszXML("test.xml");
                                End();
                            }
                            else
                            {
                                WyswietlBladPola();
                                lab_Error.Content = "Nie podano jakiejś wartości!!";
                            }
                        }
                    }
                    else
                    {
                        WyswietlBladPola();
                        lab_Error.Content = "Podano złą godzinę!!";
                        lab_format.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    WyswietlBladPola();
                    lab_Error.Content = "Podano błędne daty!!";
                }
            }
            else
            {
                WyswietlBladPola();
                lab_Error.Content = "Nie podano daty!!";
            }
        }
            

        private bool SprawdzCzyDatySaWpisane()
        {
            if (data_drozp.SelectedDate.ToString() == "")
            {
                return false;
            }
            else if (data_dzak.SelectedDate.ToString() == "")
            {
                return false;
            }
            return true;
        }

        private bool SprawdzCzas()
        {
            string pattern = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            Regex czas = new Regex(pattern);
            if (czas.IsMatch(txtbox_dataObs.Text))
            {
                if (czas.IsMatch(txtbox_dataZak.Text))
                {
                    if (txtbox_dataObs.Text == "Czas obserwacji:" || txtbox_dataObs.Text.Length < 1)
                    {
                        return false;
                    }
                    else if (txtbox_dataZak.Text == "Czas zakończenia:" || txtbox_dataZak.Text.Length < 1)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        private bool SprawdzPola_123()
        {
            if (lab_Zagrozenie.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_cisnienie_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_predkoscWiatru_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_iloscOpadow_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_srednicaKropel_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_temp_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (comboBox_typOpadow.SelectedIndex < 0)
            {
                return false;
            }
            return true;
        }

        private bool SprawdzPola_4()
        {

            if (lab_Zagrozenie.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_cisnienie_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_predkoscWiatru_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_iloscOpadow_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_srednicaKropel_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_temp_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (textBox_iloscWyladowan.Text.Length < 1)
            {
                return false;
            }
            else if (comboBox_typOpadow.SelectedIndex < 0)
            {
                return false;
            }
            return true;
        }

        private bool SprawdzPola_5()
        {
            if (lab_Zagrozenie.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_cisnienie_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_predkoscWiatru_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (lab_temp_wart.Content.ToString().Length <= 1)
            {
                return false;
            }
            else if (comboBox_skalaFujity.SelectedIndex < 0)
            {
                return false;
            }
            return true;
        }

        private bool SprawdzWyladowania()
        {
            int n;
            if (int.TryParse(textBox_iloscWyladowan.Text, out n))
            {
                return true;
            }
            return false;
        }

        private void WyswietlBladPola()
        {
            Ukryj();
            lab_iloscOpadow_wart.Visibility = Visibility.Collapsed;
            lab_cisnienie_wart.Visibility = Visibility.Collapsed;
            lab_temp_wart.Visibility = Visibility.Collapsed;
            lab_srednicaKropel_wart.Visibility = Visibility.Collapsed;
            lab_predkoscWiatru_wart.Visibility = Visibility.Collapsed;
            lab_Zagrozenie.Visibility = Visibility.Collapsed;
            lab_dodajZajwisko.Visibility = Visibility.Collapsed;
            comboBox_Zjawiska.Visibility = Visibility.Collapsed;
            lab_dataObs.Visibility = Visibility.Collapsed;
            lab_dataZak.Visibility = Visibility.Collapsed;
            data_drozp.Visibility = Visibility.Collapsed;
            data_dzak.Visibility = Visibility.Collapsed;
            txtbox_dataObs.Visibility = Visibility.Collapsed;
            txtbox_dataZak.Visibility = Visibility.Collapsed;
            lab_Error.Visibility = Visibility.Visible;
            btn_tryAgain.Visibility = Visibility.Visible;
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

        private Typ SprawdzTyp()
        {
            if (comboBox_typOpadow.SelectedIndex == 0)
            {
                typ = Typ.orograficzny;
            }
            else if (comboBox_typOpadow.SelectedIndex == 1)
            {
                typ = Typ.konwekcyjny;
            }
            else if (comboBox_typOpadow.SelectedIndex == 2)
            {
                typ = Typ.fronatlny;
            }
            return typ;
        }

        private SkalaFujity SprawdzSkale()
        {
            if (comboBox_skalaFujity.SelectedIndex == 0)
            {
                skalaF = SkalaFujity.F0;
            }
            else if (comboBox_skalaFujity.SelectedIndex == 1)
            {
                skalaF = SkalaFujity.F1;
            }
            else if (comboBox_skalaFujity.SelectedIndex == 2)
            {
                skalaF = SkalaFujity.F2;
            }
            else if (comboBox_skalaFujity.SelectedIndex == 3)
            {
                skalaF = SkalaFujity.F3;
            }
            else if (comboBox_skalaFujity.SelectedIndex == 4)
            {
                skalaF = SkalaFujity.F4;
            }
            else if (comboBox_skalaFujity.SelectedIndex == 5)
            {
                skalaF = SkalaFujity.F5;
            }
            return skalaF;
        }
        //private void slider_godzinaObs_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    string minuty = Math.Round((slider_godzinaObs.Value % 1) * 60, 0).ToString();
        //    lab_godzinaZak_wart.Content = slider_godzinaObs.Value.ToString();
        //    if (Math.Round((slider_godzinaObs.Value % 1) * 60, 0) < 10)
        //    {
        //        minuty = "0" + minuty;
        //    }

        //    lab_godzObs_wart.Content = Math.Truncate(slider_godzinaObs.Value).ToString() +":"+ minuty;
        //}

        private string UstawCzasObs()
        {
            string godzina;
            string godzina_a = txtbox_dataObs.Text.Split(':')[0];
            string godzina_b = txtbox_dataObs.Text.Split(':')[1];
            if (godzina_a.Length == 1)
            {
                godzina_a = "0" + godzina_a;
            }
            godzina = godzina_a + ":" + godzina_b;
            dataObserwacji = data_drozp.SelectedDate.ToString().Split(' ')[0] + " " + godzina;
            return dataObserwacji;
        }

        private string UstawCzasZak()
        {
            string godzina;
            string godzina_a = txtbox_dataZak.Text.Split(':')[0];
            string godzina_b = txtbox_dataZak.Text.Split(':')[1];
            if (godzina_a.Length == 1)
            {
                godzina_a = "0" + godzina_a;
            }
            godzina = godzina_a + ":" + godzina_b;
            dataZakonczenia = data_dzak.SelectedDate.ToString().Split(' ')[0] + " " + godzina;
            return dataZakonczenia;
        }
        

        private bool SprawdzDaty()
        {
            //MessageBox.Show(data_dzak.SelectedDate.ToString());
            //MessageBox.Show(data_drozp.SelectedDate.ToString());
            string godzina_a = txtbox_dataObs.Text.Split(':')[0];
            string godzina_b = txtbox_dataZak.Text.Split(':')[0];
            if (godzina_a.Length == 1)
            {
                godzina_a = "0" + godzina_a;
            }
            if (godzina_b.Length == 1)
            {
                godzina_b = "0" + godzina_b;
            }
            if ((data_dzak.SelectedDate.Value - data_drozp.SelectedDate.Value).TotalDays > 0)
            {
                return true;
            }
            else if ((data_dzak.SelectedDate.Value - data_drozp.SelectedDate.Value).TotalDays == 0)
            {
                if (Int32.Parse(godzina_b) > Int32.Parse(godzina_a))
                {
                    return true;
                }
                else if (Int32.Parse(godzina_b) == Int32.Parse(godzina_a))
                {
                    if (Int32.Parse(txtbox_dataZak.Text.Split(':')[1]) > Int32.Parse(txtbox_dataObs.Text.Split(':')[1]))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;

        }

        private void iloscWyladowan_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PokazStale()
        {
            lab_dodajZajwisko.Visibility = Visibility.Visible;
            comboBox_Zjawiska.Visibility = Visibility.Visible;
            lab_dataObs.Visibility = Visibility.Visible;
            data_drozp.Visibility = Visibility.Visible;
            txtbox_dataObs.Visibility = Visibility.Visible;
            lab_dataZak.Visibility = Visibility.Visible;
            data_dzak.Visibility = Visibility.Visible;
            txtbox_dataZak.Visibility = Visibility.Visible;
            lab_skalaZagrozenia.Visibility = Visibility.Visible;
            slider_skalaZagrozenia.Visibility = Visibility.Visible;
            lab_temp.Visibility = Visibility.Visible;
            slider_temp.Visibility = Visibility.Visible;
            lab_cisnienie.Visibility = Visibility.Visible;
            slider_cisnienie.Visibility = Visibility.Visible;
            lab_Zagrozenie.Visibility = Visibility.Visible;
            lab_temp_wart.Visibility = Visibility.Visible;
            lab_cisnienie_wart.Visibility = Visibility.Visible;
            lab_predkoscWiatru.Visibility = Visibility.Visible;
            slider_predkoscWiatru.Visibility = Visibility.Visible;
            lab_predkoscWiatru_wart.Visibility = Visibility.Visible;
            btn_add.Visibility = Visibility.Visible;
            lab_iloscOpadow_wart.Visibility = Visibility.Visible;
            lab_srednicaKropel_wart.Visibility = Visibility.Visible;
            lab_cisnienie_wart.Visibility = Visibility.Visible;
        }

        private void btn_tryAgain_Click(object sender, RoutedEventArgs e)
        {
            lab_format.Visibility = Visibility.Collapsed;
            lab_Error.Visibility = Visibility.Collapsed;
            btn_tryAgain.Visibility = Visibility.Collapsed;
            if (comboBox_Zjawiska.SelectedIndex != 3)
            {
                Pokaz();
                PokazStale();
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
            }
            if (comboBox_Zjawiska.SelectedIndex == 0)
            {
                Pokaz();
                PokazStale();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica kropel";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 1)
            {
                Pokaz();
                PokazStale();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica płatków";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 2)
            {
                Pokaz();
                PokazStale();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                lab_srednicaKropel.Content = "Średnica brylek lodu";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 3)
            {
                Pokaz();
                PokazStale();
                lab_iloscOpadow_wart.Visibility = Visibility.Visible;
                lab_srednicaKropel_wart.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Visible;
                textBox_iloscWyladowan.Visibility = Visibility.Visible;
                lab_srednicaKropel.Content = "Średnica kropel";
                lab_iloscWyladowan.Content = "Ilość wyładowań";
            }
            else if (comboBox_Zjawiska.SelectedIndex == 4)
            {
                Pokaz();
                PokazStale();
                lab_srednicaKropel.Visibility = Visibility.Collapsed;
                lab_srednicaKropel_wart.Visibility = Visibility.Collapsed;
                slider_srednicaKropel.Visibility = Visibility.Collapsed;
                lab_iloscOpadow.Visibility = Visibility.Collapsed;
                lab_iloscOpadow_wart.Visibility = Visibility.Collapsed;
                slider_iloscOpadow.Visibility = Visibility.Collapsed;
                lab_iloscWyladowan.Visibility = Visibility.Collapsed;
                comboBox_skalaFujity.Visibility = Visibility.Visible;
                lab_iloscWyladowan.Content = "Skala Fujity";
                if (comboBox_skalaFujity.SelectedIndex == 0)
                {
                    skalaF = SkalaFujity.F0;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 1)
                {
                    skalaF = SkalaFujity.F1;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 2)
                {
                    skalaF = SkalaFujity.F2;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 3)
                {
                    skalaF = SkalaFujity.F3;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 4)
                {
                    skalaF = SkalaFujity.F4;
                }
                else if (comboBox_skalaFujity.SelectedIndex == 5)
                {
                    skalaF = SkalaFujity.F5;
                }
            }
        }

        private void czasObs_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void czasZak_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
