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
using Aplikacja.Modele;
namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy OknoSprawdzZlecenia.xaml
    /// </summary>
    public partial class OknoSprawdzZlecenia : Window
    {
        private AppDbContext db = new AppDbContext();

        public OknoSprawdzZlecenia()
        {
            InitializeComponent();
            ZaladujZlecenia();
        }

        private void ZaladujZlecenia()
        {
            dgZlecenia.ItemsSource = db.Zlecenia.Include(z => z.Klient).Include(z => z.Usluga).ToList();
        }

        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            OknoKlient powrotDoOknaKlienta = new OknoKlient();
            powrotDoOknaKlienta.Show();

            this.Hide();
        }
    }
}
