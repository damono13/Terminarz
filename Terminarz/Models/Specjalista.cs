using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Terminarz.Models
{
    public class Specjalista
    {
        [Display(Name = "Specjalista Id")]
        public int SpecjalistaId { get; set; }

        [Display(Name = "Nazwa specjalisty")]
        [Required(ErrorMessage = "Proszę podać nazwe specjalisty")]
        public string NazwaSpecjalisty { get; set; }
        public virtual ICollection<Lekarz> Lekarze { get; set; }
    }
}