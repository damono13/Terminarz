using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terminarz.Models
{
    public class Lista
    {
        //Informacje o przychodni
		public int IdInformacje { get; set; }
		public string Nazwa { get; set; }
		public string WojewodztwoPrzychodni { get; set; }
		public string MiastoPrzychodni { get; set; }
		public string UlicaPrzychodni { get; set; }
		public int TelefonPrzychodni { get; set; }
		public string EmailPrzychodni { get; set; }

        //Informacje o specjalizacji
        public int IdSpecjalista { get; set; }
        public string NazwaSpecjalisty { get; set; }

        //Informacje o usłudze
        public int IdUsługa { get; set; }
        public string NazwaUsługi { get; set; }
        public int Opłata { get; set; }
        public string DniPrzyjęć { get; set; }
        public string GodzinyPrzyjęć { get; set; }

        //Informacje o lekarzu
        public int IdLekarza { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        #region dodatkowe pole not mapped 
        [NotMapped]
        public string LekarzNazwisko { get { return Imie + " " + Nazwisko; } }
        #endregion
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string Wojewodztwo { get; set; }
        public string Email { get; set; }
        public int Telefon { get; set; }
        public string Obrazek { get; set; }


        //Informacje o KartaRezerwacji
        public int IdKartaRezerwacji { get; set; }
        public string EmailUzytkownika { get; set; }
        public System.DateTime DataWizyty { get; set; }
        public int TelefonUzytkownika { get; set; }
        public string Nazwaspecjalisty { get; set; }
        public string ImieLekarza { get; set; }
        public string NazwiskoLekarza { get; set; }
        public int IdGodzina { get; set; }
        public string GodzinaWizyty { get; set; }
        
    }
}