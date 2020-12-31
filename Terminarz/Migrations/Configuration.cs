namespace Terminarz.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Terminarz.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Terminarz.Models.TerminarzContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Terminarz.Models.TerminarzContext context)
        {
            Role(context);
            Uzytkowicy(context);
            //Us³ugi(context);
            //Specjalisci(context);
            //Lekarze(context);
            //LekarzeGodziny(context);
            //DniTygodniaGodziny(context);
            //GodzinyWizyt(context);
            //DniTygodnia(context);
            Informacje(context);
        }

        //private void LekarzeGodziny(TerminarzContext context)
        //{
        //    var lekarzgodzina = new List<LekarzGodzina>
        //    {
        //        //W³odzimierz Pawlak
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =1,IdGodzina=15},
        //        //barbara nowak
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =2,IdGodzina=15},
        //        //Tomarz Krupiœnki
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =3,IdGodzina=15},
        //        //Monika Fel
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =4,IdGodzina=15},
        //        //Ignacy Bielak
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =5,IdGodzina=15},
        //        //Jerzy Resiak
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =6,IdGodzina=15},
        //        //Zbigniew kosek
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =7,IdGodzina=15},
        //        //Tadeusz Bielak
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =8,IdGodzina=15},
        //        //Doroba Wimœniewska
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =9,IdGodzina=15},
        //        //Aga Lipska
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=1},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=2},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=3},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=4},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=6},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=7},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=8},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=9},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=11},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=12},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=13},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=14},
        //        new LekarzGodzina { IdLekarz =10,IdGodzina=15},
        //    };
        //    lekarzgodzina.ForEach(lG => context.LekarzeGodziny.AddOrUpdate(lG));
        //    context.SaveChanges();
        //}

        //private void DniTygodniaGodziny(TerminarzContext context)
        //{
        //    var dzientygodniaGodzina = new List<DzienTygodniaGodzina>
        //    {
        //        //Poniedzia³ek
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=1},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=2},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=3},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=4},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=5},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=6},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=7},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=8},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=9},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=10},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=11},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=12},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 1,IdGodzina=13},
        //        //Wtorek
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=1},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=2},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=3},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=4},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=5},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=6},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=7},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=8},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=9},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=10},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=11},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=12},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 2,IdGodzina=13},
        //        //Œroda
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=1},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=2},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=3},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=4},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=5},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=6},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=7},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=8},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=9},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=10},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=11},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=12},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 3,IdGodzina=13},
        //        //Czwartek
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=1},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=2},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=3},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=4},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=5},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=6},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=7},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=8},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=9},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=10},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=11},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=12},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 4,IdGodzina=13},
        //        //Pi¹tek
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=1},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=2},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=3},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=4},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=5},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=6},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=7},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=8},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=9},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=10},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=11},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=12},
        //        new DzienTygodniaGodzina { IdDzienTygodnia = 5,IdGodzina=13},
        //    };
        //    dzientygodniaGodzina.ForEach(dTg => context.DniTygodniaGodziny.AddOrUpdate(dTg));
        //    context.SaveChanges();
        //}

        //private void DniTygodnia(TerminarzContext context)
        //{
        //    var dzientygodnia = new List<DzienTygodnia>
        //    {
        //        new DzienTygodnia { Dzien = "Poniedzia³ek"},
        //        new DzienTygodnia { Dzien = "Wtorek"},
        //        new DzienTygodnia { Dzien = "Œroda"},
        //        new DzienTygodnia { Dzien = "Czwartek"},
        //        new DzienTygodnia { Dzien = "Pi¹tek"},
        //    };
        //    dzientygodnia.ForEach(dT => context.DniTygodnia.AddOrUpdate(dT));
        //    context.SaveChanges();
        //}

        private void Role(TerminarzContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Rejestrator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Rejestrator";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Lekarz"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Lekarz";
                roleManager.Create(role);
            }
        }

        private void Uzytkowicy(TerminarzContext context)
        {
            var store = new UserStore<Uzytkownik>(context);
            var manager = new UserManager<Uzytkownik>(store);

            if (!context.Users.Any(u => u.UserName == "admin@pamed.pl"))
            {
                var user = new Uzytkownik { UserName = "admin@pamed.pl", Email = "admin@pamed.pl" };
                var adminresult = manager.Create(user, "administrator1!");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
            if (!context.Users.Any(u => u.UserName == "lekarz@pamed.pl"))
            {
                var user = new Uzytkownik { UserName = "lekarz@pamed.pl", Email = "lekarz@pamed.pl" };
                var adminresult = manager.Create(user, "lekarz2!");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Lekarz");
            }
            if (!context.Users.Any(u => u.UserName == "rejestrator@pamed.pl"))
            {
                var user = new Uzytkownik { UserName = "rejestrator@pamed.pl", Email = "rejestrator@pamed.pl" };
                var adminresult = manager.Create(user, "rejestrator3!");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Rejestrator");
            }
        }

        //private void Us³ugi(TerminarzContext context)
        //{
        //    var us³uga = new List<Us³uga>
        //    {
        //        //Neurolog
        //        new Us³uga { NazwaUs³ugi = "padaczka", Op³ata=300},
        //        new Us³uga { NazwaUs³ugi = "udar mózgu", Op³ata=460},
        //        new Us³uga { NazwaUs³ugi = "guz mózgu", Op³ata=540},
        //        new Us³uga { NazwaUs³ugi = "migrena", Op³ata=240},

        //        //Kardiolog
        //        new Us³uga { NazwaUs³ugi = "nadciœnienie têtnicze", Op³ata=450},
        //        new Us³uga { NazwaUs³ugi = "niewydolnoœæ serca", Op³ata=600},
        //        new Us³uga { NazwaUs³ugi = "zawa³ miêœnia sercowego", Op³ata=600},
        //        new Us³uga { NazwaUs³ugi = "mia¿d¿yca", Op³ata=580},

        //        //Laryngolog
        //        new Us³uga { NazwaUs³ugi = " zatkanego ucha, szumy uszne, ból ucha", Op³ata=250},
        //        new Us³uga { NazwaUs³ugi = "krwawienie z nosa", Op³ata=200},
        //        new Us³uga { NazwaUs³ugi = "przewlek³y katar", Op³ata=150},
        //        new Us³uga { NazwaUs³ugi = "chrapanie", Op³ata=120},

        //        //Okulista
        //        new Us³uga { NazwaUs³ugi = "pogorszenie ostroœci wzroku", Op³ata=360},
        //        new Us³uga { NazwaUs³ugi = "czêste mruganie", Op³ata=230},
        //        new Us³uga { NazwaUs³ugi = "czêste stany zapalne powiek i spojówek", Op³ata=250},
        //        new Us³uga { NazwaUs³ugi = "mru¿enie oczu podczas czytania", Op³ata=280},

        //        //Rodzinny
        //        new Us³uga {IdUs³uga = 17 , NazwaUs³ugi = "udzielanie rad", Op³ata=100},
        //        new Us³uga {IdUs³uga = 18 , NazwaUs³ugi = "kierowanie do specjalistów", Op³ata=50},
        //    };
        //    us³uga.ForEach(U => context.Us³ugi.AddOrUpdate(U));
        //    context.SaveChanges();
        //}

        //private void Specjalisci(TerminarzContext context)
        //{
        //    var specjalista = new List<Specjalista>
        //    {
        //        //Neurolog
        //        new Specjalista { NazwaSpecjalisty = "Neurolog"},

        //        //Kardiolog
        //        new Specjalista { NazwaSpecjalisty = "Kardiolog"},

        //        //Laryngolog
        //        new Specjalista { NazwaSpecjalisty = "Laryngolog"},

        //        //Okulista
        //        new Specjalista { NazwaSpecjalisty = "Okulista"},

        //        //Rodzinny
        //        new Specjalista { NazwaSpecjalisty = "Rodzinny"},
        //    };
        //    specjalista.ForEach(S => context.Specjalisci.AddOrUpdate(S));
        //    context.SaveChanges();
        //}

        //private void Lekarze(TerminarzContext context)
        //{
        //    var lekarz = new List<Lekarz>
        //        {
                
        //            //Neurolog
        //            new Lekarz { ImieLekarza = "W³odzimierz", NazwiskoLekarza = "Pawlak", Ulica = "Koœciuszki 14", Miasto = "M³awa", Telefon = 884425368, Email = "wlodzimierzp@interia.pl",  IdDzienTygodnia = 2, GodzinyPrzyjêæ = "8:30-14:00", IdSpecjalista = 1, IdUs³uga = 1},
        //            new Lekarz { ImieLekarza="Barbara", NazwiskoLekarza="Nowak", Ulica="G³ówna 2", Miasto = "P³ock", Telefon=505120123, Email="barbaranowak@wp.pl", IdDzienTygodnia=1, GodzinyPrzyjêæ="8:30-14:00", IdSpecjalista = 1 , IdUs³uga = 1},

        //            //Kardiolog 2
        //            new Lekarz { ImieLekarza="Tomasz", NazwiskoLekarza="Krupiñski", Ulica="S³oneczna 10", Miasto = "Sierpc", Telefon=645285756, Email="TKrupisnki@wp.pl", IdDzienTygodnia=3, GodzinyPrzyjêæ="8:30-12:00", IdSpecjalista = 2 , IdUs³uga = 5},
        //            new Lekarz { ImieLekarza="Monika", NazwiskoLekarza="Fel", Ulica="Wiatraczna 4", Miasto = "P³ock", Telefon=784256356, Email="monikafel4@onet.pl", IdDzienTygodnia=4, GodzinyPrzyjêæ="9:00-14:00", IdSpecjalista = 2 , IdUs³uga = 8 },

        //            //Laryngolog 3
        //            new Lekarz { ImieLekarza="Ignacy", NazwiskoLekarza="Bielak", Ulica="Warszawska 24", Miasto = "¯uromin",  Telefon=754952658, Email="ignacybielak24@interia.pl", IdDzienTygodnia=3, GodzinyPrzyjêæ="9:30-13:30", IdSpecjalista = 3 ,  IdUs³uga = 10 },
        //            new Lekarz { ImieLekarza="Jerzy", NazwiskoLekarza="Resiak", Ulica="D³ugosza 18", Miasto = "¯uromin",  Telefon=574125789, Email="jerzyresiak18@onet.pl",  IdDzienTygodnia=5, GodzinyPrzyjêæ="8:00-13:00", IdSpecjalista = 3 , IdUs³uga = 11 ,},

        //            //Okulista 4
        //            new Lekarz { ImieLekarza="Zbigniew", NazwiskoLekarza="Kosek", Ulica="3 Maja 12/15", Miasto = "M³awa",  Telefon=558447236, Email="zbigniewkosek@interia.pl", IdDzienTygodnia=2, GodzinyPrzyjêæ="9:30-13:00", IdSpecjalista = 4 , IdUs³uga = 14 },
        //            new Lekarz { ImieLekarza="Tadeusz", NazwiskoLekarza="Nowak", Ulica="Szczytna 3", Miasto = "Sierpc",  Telefon=884558963, Email="NowakTadeusz@interia.pl", IdDzienTygodnia=1, GodzinyPrzyjêæ="9:00-13:00", IdSpecjalista = 4 , IdUs³uga = 13 },

        //            //Rodzinny 5
        //            new Lekarz { ImieLekarza="Dorota", NazwiskoLekarza="Wiœniewska", Ulica="Witosa 25", Miasto = "¯uromin",  Telefon=510234123, Email="dorotaw25@wp.pl", IdDzienTygodnia=2, GodzinyPrzyjêæ="8:30-15:00", IdSpecjalista = 5 ,  IdUs³uga = 17  },
        //            new Lekarz { ImieLekarza="Agata", NazwiskoLekarza="Lipska", Ulica="S³oneczna 1", Miasto = "¯uromin",  Telefon=510412454, Email="agatalipska1@interia.pl",IdDzienTygodnia=4, GodzinyPrzyjêæ="8:30-14:30", IdSpecjalista = 5 ,  IdUs³uga = 18 , }

        //        };
        //    lekarz.ForEach(L => context.Lekarze.AddOrUpdate(L));
        //    context.SaveChanges();
        //}

        //private void GodzinyWizyt(TerminarzContext context)
        //{
        //    var godzinawizyty = new List<GodzinaWizyty>
        //    {
        //        new GodzinaWizyty { Godzina="8:00"},
        //        new GodzinaWizyty { Godzina="08:30"},
        //        new GodzinaWizyty { Godzina="09:00"},
        //        new GodzinaWizyty { Godzina="09:30"},
        //        new GodzinaWizyty { Godzina="10:00"},
        //        new GodzinaWizyty { Godzina="10:30"},
        //        new GodzinaWizyty { Godzina="11:00"},
        //        new GodzinaWizyty { Godzina="11:30"},
        //        new GodzinaWizyty { Godzina="12:00"},
        //        new GodzinaWizyty { Godzina="12:30"},
        //        new GodzinaWizyty { Godzina="13:00"},
        //        new GodzinaWizyty { Godzina="13:30"},
        //        new GodzinaWizyty { Godzina="14:00"},
        //        new GodzinaWizyty { Godzina="14:30"},
        //        new GodzinaWizyty { Godzina="15:30"},
        //    };
        //    godzinawizyty.ForEach(gw => context.GodzinyWizyt.AddOrUpdate(gw));
        //    context.SaveChanges();
        //}

        private void Informacje(TerminarzContext context)
        {
            var informacje = new List<Informacje>
            {
                new Informacje {Nazwa="Pamed",WojewódŸtwo="Mazowieckie",Miasto="¯uromin",Ulica="M³awska 20",Telefon=910876202,Email="pamed@pamed.pl"}
            };
            informacje.ForEach(i => context.Informacje.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}
