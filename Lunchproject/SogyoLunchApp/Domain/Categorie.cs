using System;
using System.Collections.Generic;
using System.Text;

namespace SogyoLunchApp
{
    public class Categorie
    {
        public int CategorieId { get; set; }

        public string CategorieNaam { get; set; }
   
        public int? VolgordeNummer { get; set; }

        public int WinkelId { get; set; }
        public Winkel Winkel { get; set; }
    }
}
