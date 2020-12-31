namespace Terminarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DzienTygodnia",
                c => new
                    {
                        DzienTygodniaId = c.Int(nullable: false, identity: true),
                        Dzien = c.String(),
                    })
                .PrimaryKey(t => t.DzienTygodniaId);
            
            CreateTable(
                "dbo.Godzina",
                c => new
                    {
                        GodzinaId = c.Int(nullable: false, identity: true),
                        GodzinaWizyty = c.String(),
                        DzienTygodniaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GodzinaId)
                .ForeignKey("dbo.DzienTygodnia", t => t.DzienTygodniaId, cascadeDelete: true)
                .Index(t => t.DzienTygodniaId);
            
            CreateTable(
                "dbo.KartaRezerwacji",
                c => new
                    {
                        KartaRezerwacjiId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        DataWizyty = c.DateTime(nullable: false),
                        Telefon = c.Int(nullable: false),
                        LekarzId = c.Int(nullable: false),
                        GodzinaId = c.Int(nullable: false),
                        Uzytkownicy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.KartaRezerwacjiId)
                .ForeignKey("dbo.Godzina", t => t.GodzinaId, cascadeDelete: true)
                .ForeignKey("dbo.Lekarz", t => t.LekarzId)
                .ForeignKey("dbo.AspNetUsers", t => t.Uzytkownicy_Id)
                .Index(t => t.LekarzId)
                .Index(t => t.GodzinaId)
                .Index(t => t.Uzytkownicy_Id);
            
            CreateTable(
                "dbo.Lekarz",
                c => new
                    {
                        LekarzId = c.Int(nullable: false, identity: true),
                        ImieLekarza = c.String(nullable: false, maxLength: 30),
                        NazwiskoLekarza = c.String(nullable: false, maxLength: 30),
                        Miasto = c.String(nullable: false),
                        Ulica = c.String(nullable: false),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        SpecjalistaId = c.Int(nullable: false),
                        UsługaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LekarzId)
                .ForeignKey("dbo.Specjalista", t => t.SpecjalistaId, cascadeDelete: true)
                .ForeignKey("dbo.Usługa", t => t.UsługaId, cascadeDelete: true)
                .Index(t => t.SpecjalistaId)
                .Index(t => t.UsługaId);
            
            CreateTable(
                "dbo.Specjalista",
                c => new
                    {
                        SpecjalistaId = c.Int(nullable: false, identity: true),
                        NazwaSpecjalisty = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpecjalistaId);
            
            CreateTable(
                "dbo.Usługa",
                c => new
                    {
                        UsługaId = c.Int(nullable: false, identity: true),
                        NazwaUsługi = c.String(nullable: false),
                        Opłata = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsługaId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Informacje",
                c => new
                    {
                        IdInformacje = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Wojewódźtwo = c.String(),
                        Miasto = c.String(),
                        Ulica = c.String(),
                        Telefon = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdInformacje);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.LekarzGodzina",
                c => new
                    {
                        LekarzRefId = c.Int(nullable: false),
                        GodzinaRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LekarzRefId, t.GodzinaRefId })
                .ForeignKey("dbo.Lekarz", t => t.LekarzRefId, cascadeDelete: true)
                .ForeignKey("dbo.Godzina", t => t.GodzinaRefId, cascadeDelete: true)
                .Index(t => t.LekarzRefId)
                .Index(t => t.GodzinaRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.KartaRezerwacji", "Uzytkownicy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lekarz", "UsługaId", "dbo.Usługa");
            DropForeignKey("dbo.Lekarz", "SpecjalistaId", "dbo.Specjalista");
            DropForeignKey("dbo.KartaRezerwacji", "LekarzId", "dbo.Lekarz");
            DropForeignKey("dbo.LekarzGodzina", "GodzinaRefId", "dbo.Godzina");
            DropForeignKey("dbo.LekarzGodzina", "LekarzRefId", "dbo.Lekarz");
            DropForeignKey("dbo.KartaRezerwacji", "GodzinaId", "dbo.Godzina");
            DropForeignKey("dbo.Godzina", "DzienTygodniaId", "dbo.DzienTygodnia");
            DropIndex("dbo.LekarzGodzina", new[] { "GodzinaRefId" });
            DropIndex("dbo.LekarzGodzina", new[] { "LekarzRefId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Lekarz", new[] { "UsługaId" });
            DropIndex("dbo.Lekarz", new[] { "SpecjalistaId" });
            DropIndex("dbo.KartaRezerwacji", new[] { "Uzytkownicy_Id" });
            DropIndex("dbo.KartaRezerwacji", new[] { "GodzinaId" });
            DropIndex("dbo.KartaRezerwacji", new[] { "LekarzId" });
            DropIndex("dbo.Godzina", new[] { "DzienTygodniaId" });
            DropTable("dbo.LekarzGodzina");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Informacje");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Usługa");
            DropTable("dbo.Specjalista");
            DropTable("dbo.Lekarz");
            DropTable("dbo.KartaRezerwacji");
            DropTable("dbo.Godzina");
            DropTable("dbo.DzienTygodnia");
        }
    }
}
