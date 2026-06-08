using Microsoft.EntityFrameworkCore;
using Aplikacja.Modele;

namespace Aplikacja
{
    public class AppDbContext : DbContext
    {
        // Beda reprezentowac tabele w bazie danych
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Zlecenie> Zlecenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Wskazujemy, że chcemy używać bazy danych SQLite i podajemy nazwę pliku bazy danych
            optionsBuilder.UseSqlite("Data Source=FirmaSprzatajaca.db");
        }
    }
}