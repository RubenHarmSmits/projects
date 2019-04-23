using System;
using NUnit.Framework;
using System.Linq;
using Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;

namespace SogyoLunchApp
{
    class ProductenAPITest 
    {
        //dit is voor het gebruik van een inMemory testdatabase
        //bij het daadwerkelijk gebruiken van de Database weglaten van deze opties
        private static ServiceProvider serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        private static DbContextOptions<LunchAppContext> options = new DbContextOptionsBuilder<LunchAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;
        
        private readonly DBoperations Repo = new DBoperations(new LunchAppContext(options));

        [OneTimeSetUp]
        public void Init()
        {

            Winkel appie = new Winkel("appie");
            
            Repo.AddWinkel(appie);


            Product p1 = new Product("kaas", 240, appie);
            Product p2 = new Product("bier", 340, appie);
            Product p3 = new Product("pizza", 540, appie);
            Product p4 = new Product("coffee", 140, appie); 
           

            Repo.AddProduct(p1);
            Repo.AddProduct(p2);
            Repo.AddProduct(p3);
            Repo.AddProduct(p4);
            

            StandaardWinkelPerBezorgdag standaardWinkelPerBesteldag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Wednesday, Winkel=appie };
            Repo.AddStandaardWinkel(standaardWinkelPerBesteldag);

        }
        [Test]
        public void GetProductenPerWinkelTest()
        {
            Winkel snackbar = new Winkel("snackbar");
            Repo.AddWinkel(snackbar);
            Product kroket = new Product("kroket", 180, snackbar);
            Repo.AddProduct(kroket);
            Assert.IsFalse(Repo.GetProducten(Repo.GetWinkel("appie")).Contains<Product>(kroket));
            Assert.IsTrue(Repo.GetProducten(Repo.GetWinkel("snackbar")).Contains<Product>(kroket));
        }

        [TearDown]
        public void TearDown()
        {

        }     

        [Test]
        public void getAllProductenByDateTest()
        {
            Assert.IsTrue(this.Repo.GetProducten(DateTime.Parse("2019-03-13")).First().Naam.Equals("kaas"));
        }

        [Test]
        public void addProductenTest()
        {
            Winkel testwinkel = new Winkel("test");
            Repo.AddProduct(new Product("test", 340, testwinkel));
            bool containsTestProduct = false;
            foreach (Product p in Repo.GetProducten(testwinkel))
            {
                if (p.Naam.Equals("test") && p.Prijs == 340)
                {
                    containsTestProduct = true;
                }
            }
            Assert.IsTrue(containsTestProduct);
        }

        [Test]
        public void GetWinkelDoorWinkelnaamTest()
        {
            Winkel testWinkel = new Winkel("testWinkel");
            Repo.AddWinkel(testWinkel);
            Assert.AreEqual(Repo.GetWinkel("testWinkel"), testWinkel);
        }


    }
}
