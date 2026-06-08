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
    /// Logika interakcji dla klasy OknoSprzet.xaml
    /// </summary>
    public partial class OknoSprzet : Window
    {
        public OknoSprzet()
        {
            InitializeComponent();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            OknoAdmin powrotDoOknaAdmina = new OknoAdmin();
            powrotDoOknaAdmina.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("w trakcie robienia");
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("w trakcie robienia");
        }
    }
}
