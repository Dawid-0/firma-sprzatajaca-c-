using System;
using System.Linq;
using System.Windows;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy Klienci.xaml
    /// </summary>
    public partial class Klienci : Window
    {
        // POPRAWKA: Dodano "= null!" aby uspokoić kompilator
        private AppDbContext _context = null!;

        public Klienci()
        {
            InitializeComponent();

            try
            {
                _context = new AppDbContext();
                _context.Database.EnsureCreated();

                ZaladujKlientow();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas otwierania okna:\n{ex.Message}\n\nInnerException:\n{ex.InnerException?.Message}",
                                "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ZaladujKlientow()
        {
            // Pobieramy klientów z bazy danych
            var klienci = _context.Klienci.ToList();

            KlienciDataGrid.ItemsSource = klienci;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Prosta walidacja - upewniamy się, że żadne pole nie jest puste
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                string.IsNullOrWhiteSpace(AdresTextBox.Text) ||
                string.IsNullOrWhiteSpace(TelefonTextBox.Text))
            {
                MessageBox.Show("Wprowadź wszystkie dane klienta (Imię, Nazwisko, Adres, Telefon).", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tworzenie nowego obiektu klienta na podstawie modelu
            var nowyKlient = new Klient
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Adres = AdresTextBox.Text,
                Telefon = TelefonTextBox.Text
            };

            // Dodanie do bazy i zapisanie zmian
            _context.Klienci.Add(nowyKlient);
            _context.SaveChanges();

            // Czyszczenie pól tekstowych
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            AdresTextBox.Clear();
            TelefonTextBox.Clear();

            // Odświeżenie widoku
            ZaladujKlientow();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie, czy wybrano element z siatki i czy jest to Klient
            if (KlienciDataGrid.SelectedItem is Klient wybranyKlient)
            {
                _context.Klienci.Remove(wybranyKlient);
                _context.SaveChanges();

                ZaladujKlientow();
            }
            else
            {
                MessageBox.Show("Wybierz klienta z listy, aby go usunąć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            // Powrót do panelu administratora
            OknoAdmin oknoAdmin = new OknoAdmin();
            oknoAdmin.Show();

            this.Close();
        }

        // Dodana metoda zamykająca całkowicie aplikację
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}