using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy OknoListyUslug.xaml
    /// </summary>
    public partial class OknoListyUslug : Window
    {
        private AppDbContext db = new AppDbContext();
        public OknoListyUslug()
        {
            InitializeComponent();

            cmbUslugi.ItemsSource = db.Uslugi.Include(u => u.Sprzety).ToList();
            cmbUslugi.DisplayMemberPath = "NazwaUslugi";
        }
        private void cmbUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUslugi.SelectedItem is Usluga usluga)
            {
                txtNazwa.Text = usluga.NazwaUslugi;
                txtCena.Text = $"Cena: {usluga.CenaPodstawowa} zł";
                txtOpis.Text = usluga.Opis;

                lstSprzet.ItemsSource = usluga.Sprzety;
                lstSprzet.DisplayMemberPath = "Nazwa";
            }
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta2 = new OknoKlient();
            powrotDoOknaKlienta2.Show();

            this.Hide();
        }
    }
}
