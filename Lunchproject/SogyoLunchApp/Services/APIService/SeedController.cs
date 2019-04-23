using Domain;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SogyoLunchApp;
using SogyoLunchApp.APIService;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    //[Authorize("Admin")]
    public class SeedController
    {

        private readonly DBoperations Repo;

        public SeedController(DBoperations repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public String Init()
        {

            //Winkel appie = new Winkel("appie");
            //Winkel artisjok = new Winkel("artisjok");
            //Repo.AddWinkel(appie);
            //Repo.AddWinkel(artisjok);

            //Product p1 = new Product("kaas", 240, appie);
            //Product p2 = new Product("bier", 340, appie);
            //Product p3 = new Product("pizza", 540, appie);
            //Product p4 = new Product("coffee", 140, appie);
            //Product p5 = new Product("broodje kaas", 160, artisjok);
            //Product p6 = new Product("broodje kroket", 160, artisjok);

            //Repo.AddProduct(p1);
            //Repo.AddProduct(p2);
            //Repo.AddProduct(p3);
            //Repo.AddProduct(p4);
            //Repo.AddProduct(p5);
            //Repo.AddProduct(p6);

            //StandaardWinkelPerBesteldag standaardWinkel1 = new StandaardWinkelPerBesteldag(DayOfWeek.Monday, Repo.GetWinkel("appie"), DayOfWeek.Tuesday, "11:00" );
            //StandaardWinkelPerBesteldag standaardWinkel2 = new StandaardWinkelPerBesteldag(DayOfWeek.Tuesday, null);
            //StandaardWinkelPerBesteldag standaardWinkel3 = new StandaardWinkelPerBesteldag(DayOfWeek.Friday, artisjok, DayOfWeek.Friday, "11:00");
            //StandaardWinkelPerBesteldag standaardWinkel4 = new StandaardWinkelPerBesteldag(DayOfWeek.Saturday, null);
            //StandaardWinkelPerBesteldag standaardWinkel5 = new StandaardWinkelPerBesteldag(DayOfWeek.Sunday, null);
            //StandaardWinkelPerBesteldag standaardWinkel6 = new StandaardWinkelPerBesteldag(DayOfWeek.Wednesday, appie, DayOfWeek.Friday, "11:00");
            //StandaardWinkelPerBesteldag standaardWinkel7 = new StandaardWinkelPerBesteldag(DayOfWeek.Thursday, null);

            //Repo.AddStandaardWinkel(standaardWinkel1);
            //Repo.AddStandaardWinkel(standaardWinkel2);
            //Repo.AddStandaardWinkel(standaardWinkel3);
            //Repo.AddStandaardWinkel(standaardWinkel4);
            //Repo.AddStandaardWinkel(standaardWinkel5);
            //Repo.AddStandaardWinkel(standaardWinkel6);
            //Repo.AddStandaardWinkel(standaardWinkel7);

            ////vrijdag 5 april eten we geen friet & moeten we bestellen voor 11 uur
            //WinkelUitzonderingenPerBezorgdag u1 = new WinkelUitzonderingenPerBezorgdag(HelperClass.ParseDateTime("05042019 12:00:00"), appie, (HelperClass.ParseDateTime("05042019 11:00:00")));
            
            return "Op deze manier seeden is uitgeschakeld";
        }



    }
}
