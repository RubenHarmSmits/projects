using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SogyoLunchApp.APIService;

namespace SogyoLunchApp
{
    class WinkelAPITest
    {
        private static ServiceProvider serviceProvider = new ServiceCollection()
           .AddEntityFrameworkInMemoryDatabase()
           .BuildServiceProvider();

        private static DbContextOptions<LunchAppContext> options = new DbContextOptionsBuilder<LunchAppContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;


        private readonly DBoperations Repo = new DBoperations(new LunchAppContext(options));


        [Test]
        public void AddWinkelTest()
        {
            Winkel winkel = new Winkel("testWinkel");
            Repo.AddWinkel(winkel);
            Assert.IsTrue(Repo.GetWinkels().Contains<Winkel>(winkel));
        }

  
        [Test]
        public void DeleteWinkelTest()
        {
            Winkel winkel = new Winkel("testwinkel");
            Repo.AddWinkel(winkel);
            Repo.DeleteWinkel(winkel.WinkelId);
            Assert.IsTrue(!Repo.GetWinkels().Contains<Winkel>(winkel));

        }


        [Test]
        public void UpdateWinkelTest()
        {
            Winkel winkel = new Winkel("testwinkel") { Winkellocatie = "Amsterdam" };
            Repo.AddWinkel(winkel);
            winkel.Winkellocatie = "De Bilt";
            Repo.UpdateWinkel(winkel);
            Winkel updatedWinkel = Repo.GetWinkelBijId(winkel.WinkelId);
            Assert.IsTrue(updatedWinkel.Winkellocatie== "De Bilt");
        }

        [Test]
        public void getWinkelPerDatumTest()
        {
            Winkel winkel = new Winkel("testWinkel");
            Repo.AddWinkel(winkel);
            StandaardWinkelPerBezorgdag std = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Wednesday, Winkel = winkel, BestelDeadlineDag = DayOfWeek.Tuesday };
            Repo.AddStandaardWinkel(std);
            Winkel someOtherwinkel = Repo.GetWinkelPerDatum(DateTime.Parse("2019-03-20"));
            Assert.IsTrue(someOtherwinkel.Winkelnaam.Equals("testWinkel"));
        }
        

        //[Test]
        //public void getWinkelByDateMaarMetUitzonderingTest()
        //{
        //    //add test die controleerd of hij de uitzonderingsdagen meepakt
        //}

    }
}
