using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SogyoLunchApp
{
    /*
    class BestellingAPITest
    {
        private static ServiceProvider serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        private static DbContextOptions<LunchAppContext> options = new DbContextOptionsBuilder<LunchAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;

        private readonly DBoperations Repo = new DBoperations(new LunchAppContext(options));

        static Winkel winkel = new Winkel("appie");
        static Gebruiker ruben = new Gebruiker("Ruben", "Smits");
        static Gebruiker dummy = new Gebruiker("Dummy", "Pop");
        static Product bier = new Product("bier", 2, winkel.WinkelId);
        static Product wijn = new Product("wijn", 2, winkel.WinkelId);
        static Product kaas = new Product("kaas", 2, winkel.WinkelId);
        static ProductenPerBestelling ppb1 = new ProductenPerBestelling() { ProductId = bier.ProductId,Aantal=1};
        static ProductenPerBestelling ppb2 = new ProductenPerBestelling() { ProductId = wijn.ProductId, Aantal = 2 };
        static ProductenPerBestelling ppb3 = new ProductenPerBestelling() { ProductId = kaas.ProductId };
        static ProductenPerBestelling ppb4 = new ProductenPerBestelling() { ProductId = kaas.ProductId };
        static ProductenPerBestelling ppb5 = new ProductenPerBestelling() { ProductId = kaas.ProductId };
        static Bestelling bestelling = new Bestelling() { GebruikerId =1, Bezorgdatum = DateTime.Parse("01-01-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb1, ppb2 } };

        [OneTimeSetUp]
        public void SetUpTests()
        {
            Repo.AddWinkel(winkel);
            Repo.MaakGebruiker(ruben);
            Repo.MaakGebruiker(dummy);
            Repo.AddProduct(bier);
            Repo.AddProduct(wijn);
            Repo.AddProduct(kaas);
            Repo.MaakBestelling(bestelling);
        }

        [Test]
        public void AddBestellingTest()
        {

            var a = Repo.GetAlleBestellingen().ToList();
            Assert.IsTrue(Repo.GetAlleBestellingen().Contains<Bestelling>(bestelling));
        }

        [Test]
        public void VoegBestellingenSamenTest()
        {
            ProductenPerBestelling ppb = new ProductenPerBestelling() { ProductId = 4, Aantal=2 };
            ProductenPerBestelling ppb2 = new ProductenPerBestelling() { ProductId = 45, Aantal = 2 };
            Bestelling bestelling2 = new Bestelling() { GebruikerId = 1, Bezorgdatum = DateTime.Parse("01-01-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> {ppb,ppb2}};

            Assert.IsTrue(bestelling.ProductenPerBestellingen.Count == 2);
            Repo.VoegBestellingenSamen(bestelling2);
            Bestelling a = bestelling;
            Assert.IsTrue(bestelling.ProductenPerBestellingen.Count == 3);
        }


        public void CheckOfBestelBestaatTest()
        {
            Assert.IsTrue(Repo.CheckOfBestelBestaat(bestelling));
        }

        [Test]
        public void GetBestellingenPerDatumEnGebruikerTest()
        {
            Bestelling bestelling2 = new Bestelling() { GebruikerId = ruben.GebruikerId, Bezorgdatum = DateTime.Parse("02-01-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb3 } };
            Repo.MaakBestelling(bestelling2);
            var b = Repo.GetBestellingenPerDatumEnGebruiker(DateTime.Parse("02-01-2019"), ruben.GebruikerId).First();
            Assert.IsTrue(b == bestelling2);

        }

        [Test]
        public void GetBestellingenPerDatumTest()
        {
            Bestelling bestelling3 = new Bestelling() { GebruikerId = dummy.GebruikerId, Bezorgdatum = DateTime.Parse("02-02-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb5 } };
            Repo.MaakBestelling(bestelling3);
            var c = Repo.GetBestellingenPerDatum(DateTime.Parse("02-02-2019")).First();
            Assert.IsTrue(c == bestelling3);

        }


        [Test]
        public void VerwijderProductenPerBestellingTest()
        {
            ProductenPerBestelling ppb = new ProductenPerBestelling() { ProductId = kaas.ProductId };
            Bestelling bestelling = new Bestelling() { GebruikerId = ruben.GebruikerId, Bezorgdatum = DateTime.Parse("01-08-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb } };
            Repo.MaakBestelling(bestelling);         
            Assert.IsTrue(bestelling.ProductenPerBestellingen.Count == 1);            
            Repo.VerwijderProductenPerBestelling(ppb);
            Assert.IsTrue(bestelling.ProductenPerBestellingen.Count == 0);
        }
    }*/
}