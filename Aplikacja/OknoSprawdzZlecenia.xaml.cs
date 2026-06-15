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
    /// Logika interakcji dla klasy OknoSprawdzZlecenia.xaml
    /// </summary>
    public partial class OknoSprawdzZlecenia : Window
    {
        private AppDbContext db = new AppDbContext();
        private List<Zlecenie> wszystkieZlecenia;

        public OknoSprawdzZlecenia()
        {
            InitializeComponent();
            ZaladujZlecenia();
        }

        private void ZaladujZlecenia()
        {
            wszystkieZlecenia = db.Zlecenia
                .Include(z => z.WybranyKlient)
                .Include(z => z.WybranaUsluga)
                .Include(z => z.Pracownik)
                .Include(z => z.Sprzet)
                .ToList();

            dgZlecenia.ItemsSource = wszystkieZlecenia;

            var klienci = wszystkieZlecenia
                .Select(z => z.WybranyKlient)
                .Distinct()
                .ToList();

            cbKlienci.ItemsSource = klienci;
            cbKlienci.DisplayMemberPath = "PelneDane";
            dgZlecenia.ItemsSource = null;
            cbKlienci.SelectedIndex = -1;
        }
        private void cbKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKlienci.SelectedItem == null)
            {
                dgZlecenia.ItemsSource = null;
                return;
            }

            var wybranyKlient = (Klient)cbKlienci.SelectedItem;

            dgZlecenia.ItemsSource = wszystkieZlecenia
                .Where(z => z.WybranyKlientId == wybranyKlient.Id)
                .ToList();
        }


        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta = new OknoKlient();
            powrotDoOknaKlienta.Show();

            this.Hide();
        }
    }
}
