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
        private AppDbContext _context;

        public Pracownicy()
        {
            InitializeComponent();

            try
            {
                _context = new AppDbContext();
                _context.Database.EnsureCreated(); 

                ZaladujPracownikow();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Błąd podczas otwierania okna:\n{ex.Message}\n\nInnerException:\n{ex.InnerException?.Message}",
                                "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      
        private void ZaladujPracownikow()
        {
            var pracownicy = _context.Pracownicy.ToList();
           
            PracownicyDataGrid.ItemsSource = pracownicy;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                !int.TryParse(WiekTextBox.Text, out int wiek))
            {
                MessageBox.Show("Wprowadź poprawne dane pracownika (wiek musi być liczbą).", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var nowyPracownik = new Pracownik
            {
                Imie = ImieTextBox.Text,
                Nazwisko = NazwiskoTextBox.Text,
                Wiek = wiek
            };

            _context.Pracownicy.Add(nowyPracownik);
            _context.SaveChanges();

            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            WiekTextBox.Clear();

            ZaladujPracownikow();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
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


        private void Wroc_Click(object sender, RoutedEventArgs e)
        {
            OknoAdmin oknoAdmin = new OknoAdmin();
            oknoAdmin.Show();

            this.Close();
        }

    }
}