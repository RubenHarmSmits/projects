using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using SogyoLunchApp;
using SogyoLunchApp.APIService;


namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class WinkelController : Controller
    {
        private readonly DBoperations Repo;

        public WinkelController(DBoperations repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public ActionResult getWinkels()
        {
            return Json(Repo.GetWinkels());
        }

        [HttpGet("{Date}")]
        public ActionResult GetWinkelBijDatum(DateTime date)
        {
            
            try
            {
                Winkel winkel = Repo.GetWinkelPerDatum(date);
                return Json(winkel);
            }
            catch (Exception e)
            {
                string msg = "An error occured";
                if (e is IndexOutOfRangeException) 
                    msg = "De opgegeven datum is te lang, format [yyyy-mm-dd]";
                
                else if (e is NotSupportedException) 
                    msg = "De opgegeven datum wordt niet herkent als datum [yyyy-mm-dd]";
  
                else if (e is FormatException) 
                    msg = "De opgegeven datum bestaat niet";
 
                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            }
        }

        [HttpPut]
        public ActionResult UpdateWinkel(Winkel winkel)
        {
            Repo.UpdateWinkel(winkel);
            return Ok();
        }


        [HttpPost]
        public ActionResult AddWinkel(Winkel winkel)
        {
            Repo.AddWinkel(winkel);
            return Ok();
        }

        //[HttpPost]
        //public ActionResult AddWinkel(string winkelnaam, string winkelLocatie)
        //{
        //    Winkel winkel = new Winkel(winkelnaam) {Winkellocatie=winkelLocatie };
        //    Repo.AddWinkel(winkel);
        //    return Ok();
        //}

        [HttpDelete("{id}")]
        public ActionResult DeleteWinkel(int id)
        {            
                Repo.DeleteWinkel(id);
                return Ok();         
        }


    }
}