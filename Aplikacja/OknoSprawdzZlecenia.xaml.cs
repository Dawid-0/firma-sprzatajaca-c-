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
    /// Logika interakcji dla klasy OknoSprawdzZlecenia.xaml
    /// </summary>
    public partial class OknoSprawdzZlecenia : Window
    {
        public OknoSprawdzZlecenia()
        {
            InitializeComponent();
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta = new OknoKlient();
            powrotDoOknaKlienta.Show();

            this.Hide();
        }
    }
}
