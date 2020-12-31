using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Terminarz.Models
{
    public class TerminarzContext : IdentityDbContext
    {
        public TerminarzContext() : base("Terminarz"){}

        public static TerminarzContext Create()
        {
            return new TerminarzContext();
        }

        
        public DbSet<Informacje> Informacje { get; set; }

        public DbSet<KartaRezerwacji> KartyRezerwacji { get; set; }
        public DbSet<Specjalista> Specjalisci { get; set; }
        public DbSet<Usługa> Usługi { get; set; }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Godzina> Godziny { get; set; }
        public DbSet<DzienTygodnia> DniTygodnia { get; set; }
        //public DbSet<LekarzGodzina> LekarzGodziny { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        //public DbSet<SMSViewModel> SMSViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<LekarzGodzina>().HasKey(lg => new { lg.LekarzId, lg.GodzinaId });

            modelBuilder.Entity<Lekarz>()
                        .HasMany<Godzina>(s => s.Godziny)
                        .WithMany(c => c.Lekarz)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("LekarzRefId");
                            cs.MapRightKey("GodzinaRefId");
                            cs.ToTable("LekarzGodzina");
                        });

            //modelBuilder.Entity<KartaRezerwacji>().HasRequired(x => x.Sp).WithMany(x => x.KartaRezerwacji)
            //    .HasForeignKey(x => x.IdSpecjalista).WillCascadeOnDelete(true);

            modelBuilder.Entity<Lekarz>().HasRequired(x => x.Specjalista).WithMany(x => x.Lekarze)
                .HasForeignKey(x => x.SpecjalistaId).WillCascadeOnDelete(true);

            //modelBuilder.Entity<Lekarz>().HasRequired(d => d.DzienTygodnia).WithMany(d => d.Lekarz)
            //    .HasForeignKey(x => x.IdDzienTygodnia).WillCascadeOnDelete(true);

            modelBuilder.Entity<Godzina>().HasRequired(dt => dt.DzienTygodnia).WithMany(dt => dt.Godzina)
                .HasForeignKey(x => x.DzienTygodniaId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Lekarz>().HasRequired(x => x.Usługa).WithMany(x => x.Lekarz)
                .HasForeignKey(x => x.UsługaId).WillCascadeOnDelete(true);

            modelBuilder.Entity<KartaRezerwacji>().HasRequired(x => x.Godzina).WithMany(x => x.KartyRezerwacji)
                .HasForeignKey(x => x.GodzinaId).WillCascadeOnDelete(true);

            //modelBuilder.Entity<DzienTygodniaGodzina>().HasKey(dg => new { dg.DniTygodnia, dg.Godziny });

            //modelBuilder.Entity<LekarzGodzina>().HasKey(lg => new { lg.Lekarze, lg.Godziny });
        }
    }
}