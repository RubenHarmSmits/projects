using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using SogyoLunchApp;
using SogyoLunchApp.APIService;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class StandaardWinkelController : Controller
    {
        private readonly DBoperations Repo;

        public StandaardWinkelController(DBoperations repo)
        {
            Repo = repo;
        }

        //[HttpGet]
        //public ActionResult StandaardWinkel()
        //{
        //    try
        //    {
        //        var stddagen = Repo.GetStandaardWinkel().AsQueryable();
        //        return Json(stddagen);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //[HttpGet("{Winkelnaam}")]
        //public ActionResult getStandaardBezorgdagen(string winkelnaam)
        //{
        //    try
        //    {
        //        Winkel winkel = Repo.GetWinkel(winkelnaam);
        //        var bezorgdagen =  Repo.GetStandaardBezorgdagen(winkel).AsQueryable();
        //        return Json(bezorgdagen);
        //    }
        //    catch (Exception e)
        //    {
        //        if (e is InvalidOperationException)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        }
        //    }
        //}

        //[HttpPut]
        //public ActionResult EditStandaardBezorgWinkelPerDag(int bezorgdag, string winkelnaam, int deadlinedag, TimeSpan deadlineuur)
        //{
        //    try
        //    {
        //        if (bezorgdag > 6 | deadlinedag > 6)
        //        {
        //            throw new ArgumentException();
        //        }
        //        //try format time for deadline
        //        DateTime dt = DateTime.ParseExact(deadlineuur, "hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        //        Winkel winkel = Repo.GetWinkel(winkelnaam);

        //        Repo.EditStandaardWinkel(new StandaardWinkelPerBesteldag((DayOfWeek)bezorgdag, deadlineuur, winkel, (DayOfWeek)deadlinedag));
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        string msg = "An error occurred";
        //        if (e is FormatException)
        //        {
        //            msg = "invalide tijd voor deadline";
        //        }
        //        else if (e is ArgumentException)
        //        {
        //            msg = "invalide int voor dayofweek";
        //        }
        //        else if (e is InvalidOperationException)
        //        {
        //            msg = "kan niet worden gevonden, controleer of object bestaat en of de spelling klopt";
        //        }
        //        return StatusCode(StatusCodes.Status500InternalServerError, msg);
        //    }
        //}
    }
}
