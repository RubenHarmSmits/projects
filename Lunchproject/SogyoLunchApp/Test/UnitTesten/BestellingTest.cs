using Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SogyoLunchApp.UnitTesten
{
    /*class BestellingTest
    {


        static Winkel winkel = new Winkel("appie");
        static Gebruiker ruben = new Gebruiker("Ruben", "Smits");
        static Product bier = new Product("bier", 2, winkel.WinkelId) { ProductId=1};
        static Product wijn = new Product("wijn", 2, winkel.WinkelId) { ProductId = 2 };
        static Product kaas = new Product("bier", 2, winkel.WinkelId) { ProductId = 3 };
        static ProductenPerBestelling ppb1 = new ProductenPerBestelling() { ProductId = 1, Aantal = 3 };
        static ProductenPerBestelling ppb2 = new ProductenPerBestelling() { ProductId = 2, Aantal = 2 };
        static ProductenPerBestelling ppb3 = new ProductenPerBestelling() { ProductId = 3, Aantal = 4 };
        static Bestelling bestelling1 = new Bestelling() { GebruikerId = ruben.GebruikerId, Besteldatum = DateTime.Now, Bezorgdatum = DateTime.Parse("01-01-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb1, ppb2 } };
        static Bestelling bestelling2 = new Bestelling() { GebruikerId = ruben.GebruikerId, Besteldatum = DateTime.Now, Bezorgdatum = DateTime.Parse("01-01-2019"), ProductenPerBestellingen = new List<ProductenPerBestelling> { ppb1, ppb3 } };

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void UpdateBestellingTest()
        {
            List<ProductenPerBestelling> nieuw = bestelling1.VoegBestellingenSamen(bestelling2);
            Assert.True(nieuw[0].ProductId == 1);
            Assert.True(nieuw.Count == 3);
            Assert.True(nieuw[0].Aantal == 6);           
        }
    } */
}
