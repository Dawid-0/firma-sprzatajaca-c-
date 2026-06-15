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

namespace Aplikacja
{
    public partial class OknoSprzet : Window
    {
        private AppDbContext _db = new AppDbContext();

        public OknoSprzet()
        {
            InitializeComponent();
            WczytajSprzet();
        }
        private void WczytajSprzet()
        {
            dgSprzet.ItemsSource = _db.Sprzety.ToList();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            OknoAdmin powrotDoOknaAdmina = new OknoAdmin();
            powrotDoOknaAdmina.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _db.Dispose();
            Application.Current.Shutdown();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwa.Text) || string.IsNullOrWhiteSpace(txtTyp.Text))
            {
                MessageBox.Show("Proszę wypełnić nazwę i typ sprzętu!", "Brak danych", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var nowySprzet = new Sprzet
            {
                Nazwa = txtNazwa.Text,
                Typ = txtTyp.Text,
                Opis = string.IsNullOrWhiteSpace(txtOpis.Text) ? "Brak opisu" : txtOpis.Text,
                CzyWybrany = false
            };

            _db.Sprzety.Add(nowySprzet);
            _db.SaveChanges();

            txtNazwa.Clear();
            txtTyp.Clear();
            txtOpis.Clear();
            WczytajSprzet();

            MessageBox.Show("Sprzęt został pomyślnie dodany do bazy!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            if (dgSprzet.SelectedItem is Sprzet wybranySprzet)
            {
                var wynik = MessageBox.Show($"Czy na pewno chcesz usunąć sprzęt: {wybranySprzet.Nazwa}?",
                                            "Potwierdzenie usunięcia",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question);

                if (wynik == MessageBoxResult.Yes)
                {
                    _db.Sprzety.Remove(wybranySprzet);
                    _db.SaveChanges();
                    WczytajSprzet();
                }
            }
            else
            {
                MessageBox.Show("Najpierw zaznacz na liście sprzęt, który chcesz usunąć.", "Wskazówka", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}