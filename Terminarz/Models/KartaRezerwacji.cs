using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terminarz.Models
{
    public class KartaRezerwacji
    {
        [Display(Name = "KartaRezerwacjiId")]
        public int KartaRezerwacjiId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public virtual Uzytkownik Uzytkownicy { get; set; }

        [Required(ErrorMessage = "Proszę wybrać datę wizyty")]
        //[Display(Name = "Data wizyty")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DataWizyty { get; set; }

        [Required(ErrorMessage = "Proszę wproawdzić numer teleofnu")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Nieprawidłowy numer telefonu")]
        public int Telefon { get; set; }
        
        [Display(Name = "Identyfikator lekarza")]
        public int LekarzId { get; set; }
        public virtual Lekarz Lekarz { get; set; }

        [Display(Name = "Identyfikator godziny")]
        public int GodzinaId { get; set; }
        public virtual Godzina Godzina { get; set; }

    }
}