using System;
using System.Collections.Generic;

namespace Aplikacja
{
    public class Klient
    {
        public int Id { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Adres { get; set; }
        public string Telefon { get; set; }
    }

    public class Usluga
    {
        public int Id { get; set; }

        public string NazwaUslugi { get; set; }

        public decimal CenaPodstawowa { get; set; }

        public string Opis { get; set; }

        public List<Sprzet> Sprzety { get; set; } = new();
    }

    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string PelneNazwisko => $"{Imie} {Nazwisko}";
        //public bool CzyWybrany { get; set; }
    }

    public class Sprzet
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
      //  public bool CzyWybrany { get; set; }

        public List<Usluga> Uslugi { get; set; } = new();
    }

    public class Zlecenie
    {
        public int Id { get; set; }

        public int WybranyKlientId { get; set; }
        public Klient WybranyKlient { get; set; }

        public int WybranaUslugaId { get; set; }
        public Usluga WybranaUsluga { get; set; }

        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }

        public int PracownikId { get; set; }
        public Pracownik Pracownik { get; set; }

        public int SprzetId { get; set; }
        public Sprzet Sprzet { get; set; }
    }
}