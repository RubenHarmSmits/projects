using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SogyoLunchApp
{
    /*
    class GebruikerAPITest
    {
        private static ServiceProvider serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        private static DbContextOptions<LunchAppContext> options = new DbContextOptionsBuilder<LunchAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;

        private readonly DBoperations Repo = new DBoperations(new LunchAppContext(options));

        Gebruiker Ruben = new Gebruiker("Ruben", "Smits");

        [OneTimeSetUp]
        public void SetUpTests()
        {         
            Repo.MaakGebruiker(Ruben);
        }


        [Test]
        public void AddGebruikerTest()
        {
            Assert.IsTrue(Repo.GetGebruikers().Contains<Gebruiker>(Ruben));
        }
       
        

        [Test]
        public void DeleteGebruikerTest()
        {

            Assert.IsTrue(Repo.GetGebruikers().Contains<Gebruiker>(Ruben));
            Repo.DeleteGebruiker(Ruben.GebruikerId);
            Assert.IsFalse(Repo.GetGebruikers().Contains<Gebruiker>(Ruben));
        }

        [Test]
        public void UpdateGebruikerTest()
        {
            Gebruiker Ruben = new Gebruiker("Ruben", "Smits");
            Repo.MaakGebruiker(Ruben);
            Assert.AreEqual("Ruben", Repo.GetGebruikers().First().Voornaam);
            Repo.UpdateGebruiker(Ruben.GebruikerId, "RubenSogyo");
            Assert.AreEqual("RubenSogyo", Repo.GetGebruikers().First().Voornaam);
            Repo.UpdateGebruiker(Ruben.GebruikerId, achternaam:"SmitsSogyo");
            Assert.AreEqual("SmitsSogyo", Repo.GetGebruikers().First().Achternaam);

        }


    } */
}
