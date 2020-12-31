using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Terminarz.Models
{
    public class DzienTygodnia
    {
        public int DzienTygodniaId { get; set; }
        public string Dzien { get; set; }

        public virtual ICollection<Godzina> Godzina { get; set; }
    }
}