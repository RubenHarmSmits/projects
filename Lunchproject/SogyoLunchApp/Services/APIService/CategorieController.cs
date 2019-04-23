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
    public class CategorieController : Controller
    {
        private readonly DBoperations Repo;

        public CategorieController(DBoperations repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public ActionResult AddCategorie(Categorie categorie)
        {
            Repo.AddCategorie(categorie);
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAlleCategorien()
        {
            return Json(Repo.GetAlleCategorien());
        }

        [HttpGet]
        [Route("winkel")]
        public ActionResult GetCategorienPerWinkel(int winkelId)
        {
            return Json(Repo.GetCategorienPerWinkel(winkelId));
        }

        [HttpPut]
        public ActionResult UpdateCategorie(Categorie categorie)
        {
            Repo.UpdateCategorie(categorie);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteCategorie(int categorieId)
        {
            Repo.DeleteCategorie(categorieId);
            return Ok();
        }


    }
}