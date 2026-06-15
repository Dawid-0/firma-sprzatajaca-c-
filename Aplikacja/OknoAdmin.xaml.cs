using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy OknoAdmin.xaml
    /// </summary>
    public partial class OknoAdmin : Window
    {
        public OknoAdmin()
        {
            InitializeComponent();
        }

        private void Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            OknoWyboruLogowania powrotDoOknaWyboruLogowania = new OknoWyboruLogowania();
            powrotDoOknaWyboruLogowania.Show();
            this.Hide();

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Sprzet_Click(object sender, RoutedEventArgs e)
        {
            OknoSprzet oknosprzetu = new OknoSprzet();
            oknosprzetu.Show();
            this.Hide();
        }

        private void Pracownicy_Click(object sender, RoutedEventArgs e)
        {
            Pracownicy oknoPracownicy = new Pracownicy();
            oknoPracownicy.Show();
            this.Hide();

        }
    }
}
