using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Terminarz.Models
{
    public class KartaHistoriUzytkownika
    {

        [Display(Name = "KartaHistoriUzytkownikaId")]
        public int IdKartaHistoriUzytkownika { get; set; }

        [Display(Name = "IdKartaRezerwacji")]
        public int IdKartaRezerwacji { get; set; }
        public virtual KartaRezerwacji KartaRezerwacji { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public virtual Uzytkownik Uzytkownicy { get; set; }

        [Required(ErrorMessage = "Proszę wybrać datę wizyty")]
        [Display(Name = "Data wizyty")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataWizyty { get; set; }

        [Required(ErrorMessage = "Proszę wproawdzić numer teleofnu")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Nieprawidłowy numer telefonu")]
        public int Telefon { get; set; }

        public int IdGodzina { get; set; }
        public virtual Godzina Godziny { get; set; }
        public int IdLekarz { get; set; }
        public virtual Lekarz Lekarze { get; set; }
        //public int SpecjalistaId { get; set; }
        //public virtual Specjalista Specjalisci { get; set; }
        
    }
}