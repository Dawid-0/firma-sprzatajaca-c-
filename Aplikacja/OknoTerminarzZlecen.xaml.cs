using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja
{
    public partial class OknoTerminarzZlecen : Window
    {
        private AppDbContext db = new AppDbContext();

        public OknoTerminarzZlecen()
        {
            InitializeComponent();

            dpData.SelectedDate = DateTime.Today;
            WczytajDane(DateTime.Today);
        }

        private void dpData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpData.SelectedDate.HasValue)
            {
                WczytajDane(dpData.SelectedDate.Value);
            }
        }

        private void WczytajDane(DateTime data)
        {
            var lista = db.Zlecenia
                .Include(z => z.WybranyKlient)
                .Include(z => z.WybranaUsluga)
                .Include(z => z.Pracownik)
                .Include(z => z.Sprzet)
                .Where(z => z.DataOd <= data && z.DataDo >= data)
                .Select(z => new
                {
                    Klient = z.WybranyKlient.Imie + " " + z.WybranyKlient.Nazwisko,
                    Usluga = z.WybranaUsluga.NazwaUslugi,
                    Pracownik = z.Pracownik.Imie + " " + z.Pracownik.Nazwisko,
                    Sprzet = z.Sprzet.Nazwa,
                    z.DataOd,
                    z.DataDo
                })
                .ToList();

            dgTerminarz.ItemsSource = lista;
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            var okno = new OknoAdmin(); 
            okno.Show();
            this.Close();
        }
    }
}