using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terminarz.Models
{
    public class Godzina
    {
        public Godzina()
        {
            this.Lekarz = new HashSet<Lekarz>();
        }
        [Display(Name = "GodzinaId")]
        public int GodzinaId { get; set; }

        [Display(Name = "Godzina")]
        public string GodzinaWizyty { get; set; } 

        public int DzienTygodniaId { get; set; }
        public virtual DzienTygodnia DzienTygodnia { get; set; }
        public virtual ICollection<Lekarz> Lekarz { get; set; }
        public virtual ICollection<KartaRezerwacji> KartyRezerwacji { get; set; }
    }
}