using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using SogyoLunchApp;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Repository
{
    // Using a single DB context for identity and domain objects
    // https://stackoverflow.com/questions/19902756/asp-net-identity-dbcontext-confusion
    public class LunchAppContext : IdentityDbContext<AppUser, AppRole, Guid>, IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public DbSet<Product> Producten { get; set; }
        public DbSet<Winkel> Winkels { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<StandaardWinkelPerBezorgdag> StandaardWinkelsPerBezorgdagen { get; set; }
        public DbSet<WinkelUitzonderingenPerBezorgdag> WinkelUitzonderingenPerBezorgdagen { get; set; }
        public DbSet<ProductenPerBestelling> ProductenPerBestellingen { get; set; }
        public DbSet<Categorie> Categorien { get; set; }

        public LunchAppContext(DbContextOptions<LunchAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityRelationsDefinitions(modelBuilder);
        }

        private void EntityRelationsDefinitions(ModelBuilder modelBuilder)
        {
            SetupTables(modelBuilder);
            Seed(modelBuilder);
        }

        public void SetupTables(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<ProductenPerBestelling>().HasKey(p => new { p.BestellingId, p.ProductId });
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            // Default roles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin" });

            Winkel appie = new Winkel("Albert Heijn Bezorgservice") { WinkelId = 1 };
            Winkel snackbar = new Winkel("snackbar") { WinkelId = 2 };
            modelBuilder.Entity<Winkel>().HasData(appie, snackbar);

            Product kaas = new Product("Kaas", 120, appie.WinkelId) { ProductId = -1 };
            Product bier = new Product("Bier", 220, appie.WinkelId) { ProductId = -2 };
            Product kroket = new Product("Kroket", 180, snackbar.WinkelId) { ProductId = -3 };
            modelBuilder.Entity<Product>().HasData(kaas, bier, kroket);

            StandaardWinkelPerBezorgdag maandag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Monday, BestelDeadlineDag = DayOfWeek.Friday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = appie.WinkelId };
            StandaardWinkelPerBezorgdag dinsdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Tuesday };
            StandaardWinkelPerBezorgdag woensdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Wednesday, BestelDeadlineDag = DayOfWeek.Monday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = appie.WinkelId };
            StandaardWinkelPerBezorgdag donderdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Thursday };
            StandaardWinkelPerBezorgdag vrijdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Friday, BestelDeadlineDag = DayOfWeek.Friday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = snackbar.WinkelId };
            StandaardWinkelPerBezorgdag zaterdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Saturday };
            StandaardWinkelPerBezorgdag zondag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Sunday };
            modelBuilder.Entity<StandaardWinkelPerBezorgdag>().HasData(maandag, dinsdag, woensdag, donderdag, vrijdag, zaterdag, zondag);

        }


    }
}



