using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Microsoft.EntityFrameworkCore;
using Domain;
using Newtonsoft.Json;
using SogyoLunchApp;
using Microsoft.AspNetCore.Http;

namespace Services.APIService
    {
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class BezorgdagController : Controller
    {
        private readonly DBoperations Repo;

        public BezorgdagController(DBoperations repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public ActionResult getBezorgdagen(int aantalDagen)
        {
            try
            {
                List<DateTime> bezorgdagen = Repo.GetBezorgdagen(aantalDagen);
                return Json(bezorgdagen);
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    return BadRequest("oeps, you broke the internet");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("geen")]
        public ActionResult getGeenBezorgdagen(int aantalDagen)
        {

            List<DateTime> bezorgdagen = Repo.GetGeenBezorgdagen(aantalDagen);
            return Json(bezorgdagen);

        }


        [HttpGet]
        [Route("{deadlineDatum}")]
        public ActionResult getBezorgdatumsPerDeadline(DateTime deadlineDatum)
        {
            try
            {
                List<DateTime> bezorgdagen = Repo.GetBezorgdatumsPerDeadline(deadlineDatum);
                return Json(bezorgdagen);
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    return BadRequest("oeps, j hebt het internet gebroken");
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
