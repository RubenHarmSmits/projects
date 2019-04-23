using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Repository;
using SogyoLunchApp;
using SogyoLunchApp.APIService;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class BestellingController : Controller
    {
        private readonly DBoperations Repo;

        private readonly UserManager<AppUser> _userManager;

        public BestellingController(
            DBoperations repo,
            UserManager<AppUser> userManager
        )
        {
            Repo = repo;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult PostBestelling(Bestelling bestelling)
        {           
            Repo.MaakBestelling(bestelling);
            return Ok();         

        }

        [HttpGet]
        public ActionResult GetAlleBestellingen()
        {
            var bestellingen = Repo.GetAlleBestellingen();
            return Json(bestellingen);
        }

        [HttpGet]
        [Route("{datum}")]
        public ActionResult GetAlleBestellingenPerDatum(DateTime datum) {

            return Json(
                Repo.GetBestellingenPerDatum(datum)
            );
        }

        [HttpGet]
        [Route("{datum}/{gebruikerId}")]
        public ActionResult GetBestellingenPerDatumEnGebruiker(DateTime datum, Guid gebruikerId)
        {

            var bestellingen = Repo.GetBestellingenPerDatumEnGebruiker(datum, gebruikerId);
            return Json(bestellingen);
            
        }

        [HttpGet("{maand}")]
        [Route("maand/{maand}/{gebruikerId}")]
        public ActionResult GetBestellingenPerMaandEnGebruiker(DateTime maand, Guid gebruikerId)
        {
            var bestellingen = Repo.GetBestellingenPerMaandEnGebruiker(maand, gebruikerId);
            return Json(bestellingen);
        }
       
        [HttpPut]
        public ActionResult PutBestelling(ProductenPerBestelling ppb)
        {
            Repo.VerwijderProductenPerBestelling(ppb);
            return Ok();
        }

        [HttpPut]
        [Route("notitie")]
        public ActionResult AddNotitie(ProductenPerBestelling ppb)
        {
            Repo.AddNotitie(ppb);
            return Ok();
        }

        [HttpDelete]
        public ActionResult verwijderBestellingenPerDatum(DateTime datum)
        {
            Repo.VerwijderBestellingenPerDatum(datum);
            return Ok();
        }
    }
}