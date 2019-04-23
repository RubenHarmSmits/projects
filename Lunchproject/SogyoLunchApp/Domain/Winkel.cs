using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain;

namespace SogyoLunchApp
{

    public class Winkel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WinkelId { get; set; }

        [Required]
        public string Winkelnaam { get; set; }

        public string Winkellocatie { get; set; }
        
        private Winkel()
        {
            //voor ef
        }

        public Winkel(string winkelnaam)
        {
            this.Winkelnaam = winkelnaam;
        }

    }


}

