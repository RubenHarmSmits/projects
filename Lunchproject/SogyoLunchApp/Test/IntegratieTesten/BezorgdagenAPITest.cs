using System;
using NUnit.Framework;
using System.Linq;
using Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace SogyoLunchApp
{
    class BezorgdagenAPITest
    {

        private static ServiceProvider serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        private static DbContextOptions<LunchAppContext> options = new DbContextOptionsBuilder<LunchAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;

        private DBoperations Repo = new DBoperations(new LunchAppContext(options));


        [OneTimeSetUp]
        public void Init()
        {
            Winkel supermarkt = new Winkel("AH");
            Repo.AddWinkel(supermarkt);
            Winkel snackbar = new Winkel("Artisjok");
            Repo.AddWinkel(snackbar);
            StandaardWinkelPerBezorgdag maandag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Monday, BestelDeadlineDag = DayOfWeek.Friday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = supermarkt.WinkelId };
            StandaardWinkelPerBezorgdag dinsdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Tuesday };
            StandaardWinkelPerBezorgdag woensdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Wednesday, BestelDeadlineDag = DayOfWeek.Monday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = supermarkt.WinkelId };
            StandaardWinkelPerBezorgdag donderdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Thursday };
            StandaardWinkelPerBezorgdag vrijdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Friday, BestelDeadlineDag = DayOfWeek.Friday, BestelDeadlineTijd = TimeSpan.FromHours(11), WinkelId = snackbar.WinkelId };
            StandaardWinkelPerBezorgdag zaterdag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Saturday };
            StandaardWinkelPerBezorgdag zondag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Sunday };
            Repo.AddStandaardWinkel(maandag);
            Repo.AddStandaardWinkel(dinsdag);
            Repo.AddStandaardWinkel(woensdag);
            Repo.AddStandaardWinkel(donderdag);
            Repo.AddStandaardWinkel(vrijdag);
            Repo.AddStandaardWinkel(zaterdag);
            Repo.AddStandaardWinkel(zondag);
        }

        [Test]
        public void getAlleBezorgdagenTest()
        {
            Assert.IsTrue(Repo.GetStandaardWinkel().ToArray()[0].Dag.Equals(DayOfWeek.Monday));
            Assert.IsTrue(Repo.GetStandaardWinkel().ToArray()[1].Dag.Equals(DayOfWeek.Wednesday));
            Assert.IsTrue(Repo.GetStandaardWinkel().ToArray()[2].Dag.Equals(DayOfWeek.Friday));
        }

        [Test]
        public void getBezorgdagenPerWinkelTest()
        {
            var supermarkt = Repo.GetWinkel("AH");
            var snackbar = Repo.GetWinkel("Artisjok");
            Assert.IsTrue(Repo.GetStandaardBezorgdagenPerWinkel(supermarkt).ToArray()[0].Dag.Equals(DayOfWeek.Monday));
            Assert.IsTrue(Repo.GetStandaardBezorgdagenPerWinkel(supermarkt).ToArray()[1].Dag.Equals(DayOfWeek.Wednesday));
            Assert.IsTrue(Repo.GetStandaardBezorgdagenPerWinkel(snackbar).ToArray()[0].Dag.Equals(DayOfWeek.Friday));
        }

        [Test]
        public void GetBezorgDagenTest()
        {
            List<DateTime> bezorgdagen = Repo.GetBezorgdagen(40);
            
            Assert.True(bezorgdagen.Any(x => x.Day == 1));
            Assert.False(bezorgdagen.Any(x => x.Day == 2));
            Assert.True(bezorgdagen.Any(x => x.Date >= DateTime.Now));

        }

        [Test]
        public void GetBezorgdatumsPerDeadlineTest()
        {
            DateTime deadline = DateTime.Parse("2019-04-05");
            List<DateTime> bezorgdagenbijdeadline = Repo.GetBezorgdatumsPerDeadline(deadline);

            Assert.True(bezorgdagenbijdeadline.Any(x => (int)x.DayOfWeek == 5));
            Assert.True(bezorgdagenbijdeadline.Any(x => (int)x.DayOfWeek == 1));

        }

    }
}
