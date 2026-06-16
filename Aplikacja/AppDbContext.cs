using Microsoft.EntityFrameworkCore;
using Aplikacja.Modele;

namespace Aplikacja
{
    public class AppDbContext : DbContext
    {

        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<Zlecenie> Zlecenia { get; set; }

        public AppDbContext()
        {


            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=FirmaSprzatajaca.db");
        }

    }
}