using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Aplikacja.Modele;
// Dodano jawny using dla Entity Framework Core na wszelki wypadek
using Microsoft.EntityFrameworkCore;

namespace Aplikacja
{
    public partial class DodajZlecenieWindow : Window
    {
        // Dodano znak zapytania '?', aby uciszyć błędy o wartościach null
        public List<Klient>? Klienci { get; set; }
        public Klient? WybranyKlient { get; set; }

        public List<Usluga>? Uslugi { get; set; }
        public Usluga? WybranaUsluga { get; set; }

        public DateTime DataOd { get; set; } = DateTime.Now;
        public DateTime DataDo { get; set; } = DateTime.Now.AddDays(1);

        public List<PracownikViewModel>? Pracownicy { get; set; }
        public List<SprzetViewModel>? Sprzety { get; set; }

        public DodajZlecenieWindow()
        {
            InitializeComponent();
            ZaladujDaneZBazy();
            this.DataContext = this;
        }

        private void ZaladujDaneZBazy()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    Klienci = db.Klienci.ToList();
                    Uslugi = db.Uslugi.ToList();

                    Pracownicy = db.Pracownicy.Select(p => new PracownikViewModel
                    {
                        Pracownik = p,
                        CzyWybrany = false
                    }).ToList();

                    Sprzety = db.Sprzety.Where(s => s.CzyDostepny).Select(s => new SprzetViewModel
                    {
                        Sprzet = s,
                        CzyWybrany = false
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            if (WybranyKlient == null)
            {
                MessageBox.Show("Proszę wybrać klienta.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (WybranaUsluga == null)
            {
                MessageBox.Show("Proszę wybrać usługę.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (DataOd >= DataDo)
            {
                MessageBox.Show("Data zakończenia musi być późniejsza niż data rozpoczęcia.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var wybranyPracownik = Pracownicy?.FirstOrDefault(p => p.CzyWybrany)?.Pracownik;
            var wybranySprzet = Sprzety?.FirstOrDefault(s => s.CzyWybrany)?.Sprzet;

            if (wybranyPracownik == null || wybranySprzet == null)
            {
                MessageBox.Show("Proszę zaznaczyć przynajmniej jednego pracownika i jeden sprzęt.", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var db = new AppDbContext())
                {
                    // Używamy całych obiektów, a nie właściwości Id (np. KlientId), 
                    // aby ominąć błędy kompilatora mówiące o braku definicji "Id".
                    var noweZlecenie = new Zlecenie
                    {
                        Klient = db.Klienci.Find(WybranyKlient.Id),
                        Usluga = db.Uslugi.Find(WybranaUsluga.Id),
                        DataOd = this.DataOd,
                        DataDo = this.DataDo,
                        Pracownik = db.Pracownicy.Find(wybranyPracownik.Id),
                        Sprzet = db.Sprzety.Find(wybranySprzet.Id)
                    };

                    db.Zlecenia.Add(noweZlecenie);
                    db.SaveChanges();

                    MessageBox.Show("Zlecenie zostało pomyślnie dodane!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                    OknoKlient poprzednieOkno = new OknoKlient();
                    poprzednieOkno.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas zapisu: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient poprzednieOkno = new OknoKlient();
            poprzednieOkno.Show();

            this.Close();
        }
    }

    public class PracownikViewModel
    {
        public Pracownik? Pracownik { get; set; }
        public bool CzyWybrany { get; set; }
        // Używamy operatora '?' chroniącego przed odwołaniem do null'a
        public string PelneNazwisko => $"{Pracownik?.Imie} {Pracownik?.Nazwisko}";
    }

    public class SprzetViewModel
    {
        public Sprzet? Sprzet { get; set; }
        public bool CzyWybrany { get; set; }
        public string Nazwa => Sprzet?.Nazwa ?? "Nieznany";
    }
}