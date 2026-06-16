using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Aplikacja.Modele;

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

            // Wczytujemy listę usług bez błędnego .Include()
            cmbUslugi.ItemsSource = db.Uslugi.ToList();
            cmbUslugi.DisplayMemberPath = "NazwaUslugi";
        }

        private void cmbUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUslugi.SelectedItem is Usluga usluga)
            {
                // Wypełniamy dane, które faktycznie istnieją w modelu
                txtNazwa.Text = usluga.NazwaUslugi;
                txtCena.Text = $"Cena: {usluga.CenaPodstawowa} zł";

                // Poniższe linie są zakomentowane, dopóki nie dodasz 
                // właściwości 'Opis' oraz relacji 'Sprzety' do modelu Usluga w bazie danych

                // txtOpis.Text = usluga.Opis;
                // lstSprzet.ItemsSource = usluga.Sprzety;
                // lstSprzet.DisplayMemberPath = "Nazwa";
            }
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta = new OknoKlient();
            powrotDoOknaKlienta.Show();

            this.Hide();
        }
    }
}