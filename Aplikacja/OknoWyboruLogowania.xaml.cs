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
    /// Logika interakcji dla klasy OknoWyboruLogowania.xaml
    /// </summary>
    public partial class OknoWyboruLogowania : Window
    {
        public OknoWyboruLogowania()
        {
            InitializeComponent();
        }
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            OknoAdmin oknoAdmina = new OknoAdmin();
            oknoAdmina.Show();

            this.Hide();

        }

        private void Klient_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient oknoKlienta = new OknoKlient();
            oknoKlienta.Show();

            this.Hide();

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
