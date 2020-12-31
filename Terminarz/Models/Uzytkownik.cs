using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Terminarz.Models
{
    public class Uzytkownik : IdentityUser
    {
        //public Uzytkownik()
        //{
        //    this.KartaRezerwacji = new HashSet<KartaRezerwacji>();
        //}

        public virtual ICollection<KartaRezerwacji> KartaRezerwacji { get; set; }

        [Display(Name = "Imie użytkownika")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko użytkownka")]
        public string Nazwisko { get; set; }

        //[Display(Name = "Telefon")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Nieprawidłowy numer telefonu")]
        //public System.Int32 Telefon { get; set; }

        #region dodatkowe pole not mapped
        [NotMapped]
        [Display(Name = "Uzytkownik")]
        public string UzytkownikNazwisko
        {
            get { return Imie + " " + Nazwisko; }
        }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }
}