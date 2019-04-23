using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class GebruikerController : Controller
    {

        private readonly DBoperations Repo;

        public GebruikerController(DBoperations repo)
        {
            this.Repo = repo;
        }

        /*
        [HttpGet]
        public ActionResult GetGebruikers()
        {
            return Json(Repo.GetGebruikers());
        }

        [HttpPost]
        public ActionResult PostGebruikers(string voornaam, string achternaam, string email, Boolean isAdministrator)
        {
            Repo.MaakGebruiker(new Gebruiker(voornaam, achternaam)
            { Email=email,IsAdministrator=isAdministrator});
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteGebruiker(int gebruikerId)
        {
            try
            {
                Repo.DeleteGebruiker(gebruikerId);
                return Ok();
            }
            
            catch(ArgumentNullException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult UpdateGebruiker(int gebruikerId, string voornaam, string achternaam, string email, Boolean isAdministrator)
        {
            try
            {
                Repo.UpdateGebruiker(gebruikerId, voornaam, achternaam, email, isAdministrator);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(InvalidOperationException e)
            {
                return NotFound();
            }
        }*/
    }
}