using System.ComponentModel.DataAnnotations;

namespace Terminarz.Models
{
    public class Informacje
    {
        [Key]
        [Display(Name = "Identyfikator informacji")]
        public int IdInformacje { get; set; }

        [Display(Name = "Nazwa placówki")]
        public string Nazwa { get; set; }

        [Display(Name = "Wojewódźtwo")]
        public string Wojewódźtwo { get; set; }

        [Display(Name = "Miasto")]
        public string Miasto { get; set; }

        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Display(Name = "Telefon")]
        public int Telefon { set; get; }

        [Display(Name = "E-mail")]
        public string Email { set; get; }
    }
}