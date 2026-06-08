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
    /// Logika interakcji dla klasy OknoKlient.xaml
    /// </summary>
    public partial class OknoKlient : Window
    {
        public OknoKlient()
        {
            InitializeComponent();
        }

        private void SprawdzUslugi_Click(object sender, RoutedEventArgs e)
        {
            OknoListyUslug oknoSprawdzUslugi = new OknoListyUslug();
            oknoSprawdzUslugi.Show();

            this.Hide();
        }

        private void Sprawdz_zamowienia_Click(object sender, RoutedEventArgs e)
        {
            OknoSprawdzZlecenia oknoSprawdzZlecenia = new OknoSprawdzZlecenia();
            oknoSprawdzZlecenia.Show();

            this.Hide();
        }

        private void UtworzZlecenie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoWyboruLogowania powrotDoOknaLogowania = new OknoWyboruLogowania();
            powrotDoOknaLogowania.Show();

            this.Hide();
        }
    }
}
