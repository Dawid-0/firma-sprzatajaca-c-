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
            // UWAGA: Uruchom aplikację raz z odblokowaną linijką poniżej, 
            // a potem ZAKOMENTUJ JĄ (// Database.EnsureDeleted();)
          //  Database.EnsureDeleted();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite("Data Source=FirmaSprzatajaca.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- KLIENCI ---
            modelBuilder.Entity<Klient>().HasData(
                new Klient { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", Adres = "ul. Fiołkowa 5, Warszawa", Telefon = "111222333" },
                new Klient { Id = 2, Imie = "Anna", Nazwisko = "Nowak", Adres = "ul. Złota 12, Kraków", Telefon = "444555666" },
                new Klient { Id = 3, Imie = "Piotr", Nazwisko = "Wiśniewski", Adres = "ul. Długa 8/12, Poznań", Telefon = "777888999" },
                new Klient { Id = 4, Imie = "Maria", Nazwisko = "Wójcik", Adres = "ul. Krótka 1, Gdańsk", Telefon = "666111222" },
                new Klient { Id = 5, Imie = "Tomasz", Nazwisko = "Kamiński", Adres = "ul. Leśna 45, Wrocław", Telefon = "500600700" },
                new Klient { Id = 6, Imie = "Magdalena", Nazwisko = "Lewandowska", Adres = "ul. Polna 12, Łódź", Telefon = "800900100" }
            );

            // --- USŁUGI ---
            modelBuilder.Entity<Usluga>().HasData(
                new Usluga { Id = 1, NazwaUslugi = "Kompleksowe sprzątanie biura", CenaPodstawowa = 250.00m },
                new Usluga { Id = 2, NazwaUslugi = "Mycie okien (do 10 sztuk)", CenaPodstawowa = 100.00m },
                new Usluga { Id = 3, NazwaUslugi = "Pranie dywanów i wykładzin", CenaPodstawowa = 150.00m },
                new Usluga { Id = 4, NazwaUslugi = "Sprzątanie po remoncie", CenaPodstawowa = 500.00m },
                new Usluga { Id = 5, NazwaUslugi = "Czyszczenie tapicerki meblowej", CenaPodstawowa = 120.00m },
                new Usluga { Id = 6, NazwaUslugi = "Ozonowanie pomieszczeń", CenaPodstawowa = 200.00m },
                new Usluga { Id = 7, NazwaUslugi = "Sprzątanie klatek schodowych", CenaPodstawowa = 300.00m }
            );

            // --- PRACOWNICY ---
            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik { Id = 1, Imie = "Adam", Nazwisko = "Pracowity", Wiek = 35 },
                new Pracownik { Id = 2, Imie = "Ewa", Nazwisko = "Czysta", Wiek = 28 },
                new Pracownik { Id = 3, Imie = "Michał", Nazwisko = "Szybki", Wiek = 24 },
                new Pracownik { Id = 4, Imie = "Karolina", Nazwisko = "Dokładna", Wiek = 41 },
                new Pracownik { Id = 5, Imie = "Krzysztof", Nazwisko = "Miotła", Wiek = 50 },
                new Pracownik { Id = 6, Imie = "Agnieszka", Nazwisko = "Lśniąca", Wiek = 31 }
            );

            // --- SPRZĘT ---
            modelBuilder.Entity<Sprzet>().HasData(
                new Sprzet { Id = 1, Nazwa = "Odkurzacz Przemysłowy Karcher", Typ = "Elektryczny", CzyDostepny = true },
                new Sprzet { Id = 2, Nazwa = "Mop parowy Vileda", Typ = "Ręczny", CzyDostepny = true },
                new Sprzet { Id = 3, Nazwa = "Szorowarka do podłóg Taski", Typ = "Elektryczny", CzyDostepny = true },
                new Sprzet { Id = 4, Nazwa = "Odkurzacz piorący Numatic", Typ = "Elektryczny", CzyDostepny = true },
                new Sprzet { Id = 5, Nazwa = "Zestaw do mycia okien Unger", Typ = "Ręczny", CzyDostepny = true },
                new Sprzet { Id = 6, Nazwa = "Generator ozonu", Typ = "Elektryczny", CzyDostepny = true },
                new Sprzet { Id = 7, Nazwa = "Wózek do sprzątania dwuwiadrowy", Typ = "Ręczny", CzyDostepny = true },
                new Sprzet { Id = 8, Nazwa = "Myjka ciśnieniowa Karcher", Typ = "Elektryczny", CzyDostepny = true }
            );
        }
    }
}