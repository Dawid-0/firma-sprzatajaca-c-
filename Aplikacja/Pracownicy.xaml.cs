using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy Pracownicy.xaml
    /// </summary>
    public partial class Pracownicy : Window
    {
        // Pole przechowujące kontekst bazy danych
        private AppDbContext _context;

        public Pracownicy()
        {
            InitializeComponent();

            try
            {
                // Inicjalizacja połączenia z bazą danych
                _context = new AppDbContext();
                _context.Database.EnsureCreated(); // Upewnia się, że baza istnieje

                ZaladujPracownikow();
            }
            catch (Exception ex)
            {
                // Wyświetlenie okienka z błędem, który normalnie zamyka aplikację
                MessageBox.Show($"Błąd podczas otwierania okna:\n{ex.Message}\n\nInnerException:\n{ex.InnerException?.Message}",
                                "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Metoda pobierająca dane z bazy SQLite
        private void ZaladujPracownikow()
        {
            var pracownicy = _context.Pracownicy.ToList();
            // Przypisanie danych do tabeli (upewnij się, że w XAML tabela ma x:Name="PracownicyDataGrid")
            PracownicyDataGrid.ItemsSource = pracownicy;
        }

        // Metoda podpięta pod przycisk "Dodaj"
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Walidacja wprowadzonych danych
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                !int.TryParse(WiekTextBox.Text, out int wiek))
            {
                MessageBox.Show("Wprowadź poprawne dane pracownika (wiek musi być liczbą).", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Tworzenie nowego obiektu pracownika
            var nowyPracownik = new Pracownik
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Wiek = wiek
            };

            // Dodanie do bazy i zapisanie zmian
            _context.Pracownicy.Add(nowyPracownik);
            _context.SaveChanges();

            // Czyszczenie pól formularza
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            WiekTextBox.Clear();

            // Odświeżenie widoku tabeli
            ZaladujPracownikow();
        }

        // Metoda podpięta pod przycisk "Usuń"
        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie, czy użytkownik zaznaczył kogoś w tabeli
            if (PracownicyDataGrid.SelectedItem is Pracownik wybranyPracownik)
            {
                _context.Pracownicy.Remove(wybranyPracownik);
                _context.SaveChanges();

                ZaladujPracownikow();
            }
            else
            {
                MessageBox.Show("Wybierz pracownika z listy, aby go usunąć.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Metoda podpięta pod przycisk "Wróć"
        // Metoda podpięta pod przycisk "Wróć"
        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            // Otwarcie z powrotem panelu administratora
            OknoAdmin oknoAdmin = new OknoAdmin();
            oknoAdmin.Show();

            // Zamknięcie obecnego okna pracowników
            this.Close();
        }

    }
}