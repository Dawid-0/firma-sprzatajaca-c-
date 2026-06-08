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
    /// Logika interakcji dla klasy OknoListyUslug.xaml
    /// </summary>
    public partial class OknoListyUslug : Window
    {
        public OknoListyUslug()
        {
            InitializeComponent();
        }
        private void cmbUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta2 = new OknoKlient();
            powrotDoOknaKlienta2.Show();

            this.Hide();
        }
    }
}
