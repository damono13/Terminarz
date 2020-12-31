using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Terminarz.Models
{
    public class Usługa
    {
        [Display(Name = "Identyfikator usługi")]
        public int UsługaId { get; set; }

        [Display(Name = "Nazwa usługi")]
        [Required(ErrorMessage = "Pole nazwa usługi jest wymagane", AllowEmptyStrings = false)]
        public string NazwaUsługi { get; set; }

        [Display(Name = "Opłata")]
        [Required(ErrorMessage = "Pole opłata jest wymagane", AllowEmptyStrings = false)]
        public int Opłata { get; set; }

        public virtual ICollection<Lekarz> Lekarz { get; set; }
    }
}