using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SogyoLunchApp
{
    public class ProductenPerBestelling
    {

        public int BestellingId { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Prijs { get; set; }

        public int Aantal { get; set; }

        public string Notitie { get; set; }
    }
}
