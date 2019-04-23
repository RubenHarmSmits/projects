using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SogyoLunchApp
{
    public class WinkelUitzonderingenPerBezorgdag 
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime Date { get; set; }

        public virtual Winkel Winkel { get; set; }
        public virtual int? WinkelId { get; set; }
        public virtual DateTime? BestelDeadline { get; set; }
        
        private WinkelUitzonderingenPerBezorgdag()
        {
            //EF
        }

        //public WinkelUitzonderingenPerBezorgdag(DateTime datum, Winkel winkel = null, DateTime? deadline = null)
        //{
        //    this.Winkel = winkel;
        //    this.Date = datum;
        //    this.BestelDeadline = deadline;
        //}
        

    }
}
