using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SogyoLunchApp;

namespace Services.APIService
{
    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class WinkelUitzonderingenPerBezorgdagController : Controller
    {

        private readonly DBoperations Repo;

        public WinkelUitzonderingenPerBezorgdagController (DBoperations repo)
        {
            Repo = repo;
        }

        [HttpPost] 
        public ActionResult PostWinkelUitzondering(WinkelUitzonderingenPerBezorgdag wupb)
        {
            Repo.AddWinkelUitzonderingenPerBezorgdag(wupb);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteWinkelUitzondering(DateTime datum)
        {
            Repo.DeleteWinkelUitzonderingPerBezorgdag(datum);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAlleWinkelUitzonderingenPerBezorgdag()
        {
            return Json(Repo.GetAlleWinkelUitzonderingenPerBezorgdag());
        }
    }
}