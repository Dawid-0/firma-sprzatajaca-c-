using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace Aplikacja
{
    public partial class OknoDostepneUslugi : Window
    {
        private AppDbContext _db = new AppDbContext();

        public OknoDostepneUslugi()
        {
            InitializeComponent();
            WczytajUslugi();
            WczytajSprzet();
        }

        private void WczytajUslugi()
        {
            dgUslugi.ItemsSource = _db.Uslugi.ToList();
        }

        private void WczytajSprzet()
        {
            cbSprzet.ItemsSource = _db.Sprzety.ToList();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(txtCena.Text, out decimal cena))
            {
                MessageBox.Show("Błędna cena!");
                return;
            }

            var usluga = new Usluga
            {
                NazwaUslugi = txtNazwa.Text,
                CenaPodstawowa = cena,
                Opis = txtOpis.Text
            };

            if (cbSprzet.SelectedItem is Sprzet sprzet)
            {
                usluga.Sprzety.Add(sprzet);
            }

            _db.Uslugi.Add(usluga);
            _db.SaveChanges();

            txtNazwa.Clear();
            txtCena.Clear();
            txtOpis.Clear();

            WczytajUslugi();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            if (dgUslugi.SelectedItem is Usluga u)
            {
                _db.Uslugi.Remove(u);
                _db.SaveChanges();
                WczytajUslugi();
            }
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            new OknoAdmin().Show();
            this.Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _db.Dispose();
            Application.Current.Shutdown();
        }
    }
}