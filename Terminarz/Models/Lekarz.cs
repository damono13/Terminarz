using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terminarz.Models
{
    public class Lekarz
    {
        public Lekarz()
        {
            this.Godziny = new HashSet<Godzina>();
        }
        [Display(Name = "IdSpecjalistaentyfikator lekarza")]
        public int LekarzId { get; set; }

        [Required(ErrorMessage = "Prosze podać imie lekarza.")]
        [Display(Name = "Imie")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"[A-ZŻŹŚŁĆ]{1}[a-zżźńółęąćś]+", ErrorMessage = "NieprawIdSpecjalistałowa wartość w polu Imie")]
        public string ImieLekarza { get; set; }

        [Required(ErrorMessage = "Proszę podać Nazwisko lekarza")]
        [Display(Name = "Nazwisko")]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"[A-ZŻŹŚŁĆ]{1}[a-zżźńółęąćś]+", ErrorMessage = "NieprawIdSpecjalistałowa wartość w polu Nazwisko")]
        public string NazwiskoLekarza { get; set; }

        #region dodatkowe pole not mapped 
        [NotMapped] 
        [Display(Name = "Lekarz")]
        public string LekarzImieNazwisko { get { return ImieLekarza + " " + NazwiskoLekarza; } }
        #endregion

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Proszę podać miasto lekarza")]
        public string Miasto { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Proszę podać ulice lekarza")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Proszę wproawdzić numer teleofnu")]
        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "NieprawIdSpecjalistałowy numer telefonu")]
        public int Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Wpisz poprawny adres meilowy")]
        [Required(ErrorMessage = "Uzupełnij pole Adres meilowy")]
        [Display(Name = "Adres meilowy")]
        public string Email { get; set; }

        [Display(Name = "IdSpecjalistaentyfikator specjalisty")]
        public int SpecjalistaId { get; set; }
        public virtual Specjalista Specjalista { get; set; }

        [Display(Name = "IdSpecjalistaentyfikator usługi")]
        public int UsługaId { get; set; }
        public virtual Usługa Usługa { get; set; }
        public virtual ICollection<KartaRezerwacji> KartyRezerwacji { get; set; }
        public virtual ICollection<Godzina> Godziny { get; set; }
    }
}