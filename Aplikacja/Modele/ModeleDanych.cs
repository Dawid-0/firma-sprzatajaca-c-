using System;

namespace Aplikacja.Modele
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
    }

    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
       
        public string PelneDane => $"{Imie} {Nazwisko}";
    }

    public class Sprzet
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Typ { get; set; }
        public bool CzyDostepny { get; set; } = true;
    }

    public class Usluga
    {
        public int Id { get; set; }
        public string NazwaUslugi { get; set; }
        public decimal CenaPodstawowa { get; set; }
    }

    public class Zlecenie
    {
        public int Id { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }

        // Kluczy obcych do innych tabel
        public int KlientId { get; set; }
        public Klient Klient { get; set; }

        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }

        public int PracownikId { get; set; }
        public Pracownik Pracownik { get; set; }

        public int SprzetId { get; set; }
        public Sprzet Sprzet { get; set; }
    }
}