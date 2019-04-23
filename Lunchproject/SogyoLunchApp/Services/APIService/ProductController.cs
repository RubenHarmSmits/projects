using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SogyoLunchApp.APIService;
using SogyoLunchApp;

namespace Services.APIService
{

    [Route("sogyolunchapi/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DBoperations Repo;

        public ProductController(DBoperations repo)
        {
            Repo = repo;
        }
        
        //momenteel geen update methode, niet nodig??



        [HttpPost]        
        public ActionResult AddProduct(Product product)
        {
            Repo.AddProduct(product);
            return Ok();
        }

             
        [HttpDelete("{id}")]
        public ActionResult DeleteProducten(int id)
        {
            try
            {
                Repo.DeleteProduct(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e is InvalidOperationException)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpGet("{Winkelnaam}")]
        [Route("Winkel/{Winkelnaam}")]
        public ActionResult GetProductenPerWinkel(string winkelnaam)
        {

            List<Product> producten = new List<Product>();
            Winkel winkel;

            try
            {
                winkel = Repo.GetWinkel(winkelnaam);
                producten = Repo.GetProducten(winkel).ToList();
                return Json(producten);
            }

            catch (Exception e)
            {
                if (e is InvalidOperationException)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpGet]
        [Route("categorie")]
        public ActionResult GetProductenPerCategorie(int categorieId)
        {
            return Json(Repo.GetProductenPerCategorie(categorieId));
        }

        [HttpGet("{Date}")]
        public ActionResult GetProductenbijDatum(DateTime date)
        {
            List<Product> producten = new List<Product>();
            //DateTime datum;

            try
            {
                //datum = HelperClass.ParseDateTime(date);
                //if (datum.Date < DateTime.Now.Date)
                //{
                //    throw new ArgumentException();
                //}
                Repo.GetProducten(date).ToList().ForEach(p => producten.Add(p));
                return Json(producten);
            }
            catch (Exception e)
            {
                if (e is NotSupportedException || e is IndexOutOfRangeException)
                {
                    return BadRequest("Dit is een onjuiste datum, voer de datum in het juiste formaat in: 'ddmmyyyy hh:mm:ss' ");
                }
                else if (e is ArgumentException)
                {
                    return BadRequest("je kunt niet voor het verleden bestellen");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                
            }
        }

    }
}
