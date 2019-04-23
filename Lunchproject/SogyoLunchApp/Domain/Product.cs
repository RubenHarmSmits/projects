using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SogyoLunchApp;

namespace Domain
{
    public class Product 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string Naam { get; set; }

        public int Prijs { get; set; }

        public int WinkelId { get; set; }
        public virtual Winkel Winkel { get; set; }

        public int? CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        private Product()
        {
            //enkel voor entity framework
        }

        public Product(string naam, int prijs, Winkel winkel)
        {
            Naam = naam;
            Prijs = prijs;
            Winkel = winkel;
        }

        public Product(string naam, int prijs, int winkelId)
        {
            Naam = naam;
            Prijs = prijs;
            WinkelId = winkelId;
        }


    }
}
