using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace SogyoLunchApp
{
    public class Bestelling 
    {

        public int BestellingId { get; set; }

        public DateTime Besteldatum { get; set; }

        public DateTime Bezorgdatum { get; set; }

        public AppUser Gebruiker { get; set; }
        public Guid GebruikerId { get; set; }

        public ICollection<ProductenPerBestelling> ProductenPerBestellingen { get; set; }


        public List<ProductenPerBestelling> VoegBestellingenSamen(Bestelling nieuweBestelling)
        {
            var origineel = ProductenPerBestellingen.ToList();
            var nieuw = nieuweBestelling.ProductenPerBestellingen.ToList();
            var samengevoegd = new List<ProductenPerBestelling>();

            foreach (ProductenPerBestelling ppb in origineel.ToList()) {            
                foreach (ProductenPerBestelling ppb2 in nieuw.ToList()) {                
                    if (ppb.ProductId == ppb2.ProductId)
                    {
                        ppb.Aantal += ppb2.Aantal;
                        samengevoegd.Add(ppb);
                        origineel.Remove(ppb);
                        nieuw.Remove(ppb2);
                    }
                }
            }

            foreach (ProductenPerBestelling ppb in origineel) samengevoegd.Add(ppb);      

            foreach (ProductenPerBestelling ppb in nieuw) samengevoegd.Add(ppb);
          
           return samengevoegd;
        }
    }
}
