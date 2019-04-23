using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class DeadlineController : Controller
    {
        private readonly DBoperations Repo;

        public DeadlineController(DBoperations repo)
        {
            Repo = repo;
        }

        
        [HttpGet("{bezorgdatum}")]
        public ActionResult GetDeadlinePerDatum(DateTime bezorgdatum)
        {
            DateTime deadlinedatum = Repo.GetDeadlinePerDatum(bezorgdatum);

            return Json(deadlinedatum);
        }
    }
}