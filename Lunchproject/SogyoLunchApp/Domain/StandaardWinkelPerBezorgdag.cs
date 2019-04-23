using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SogyoLunchApp
{
    public class StandaardWinkelPerBezorgdag 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DayOfWeek Dag { get; set; }

        public int? WinkelId { get; set; }
      
        public virtual Winkel Winkel { get; set; }

        public virtual DayOfWeek? BestelDeadlineDag { get; set; }

        public TimeSpan BestelDeadlineTijd { get; set; }

        public StandaardWinkelPerBezorgdag()
        {
            //ef
        }

        public StandaardWinkelPerBezorgdag(DayOfWeek dag, TimeSpan besteldeadlinetijd, Winkel winkel = null, 
            DayOfWeek besteldeadlinedag = DayOfWeek.Saturday)
        {
            this.Winkel = winkel;
            this.Dag = dag;
            if (winkel != null)
            {
                this.BestelDeadlineDag = besteldeadlinedag;
                this.BestelDeadlineTijd = besteldeadlinetijd;
            }
        }

        public DateTime GetDeadlineDatum(DateTime bezorgdatum)
        {
            DateTime deadlineDateTime = bezorgdatum;
            while (deadlineDateTime.DayOfWeek != BestelDeadlineDag)
                deadlineDateTime = deadlineDateTime.AddDays(-1);
            return deadlineDateTime.Add(BestelDeadlineTijd);
        }

        public DateTime GetBezorgdagDatum(DateTime deadlinedatum, DayOfWeek bezorgdag)
        {
            DateTime bezorgdagDateTime = deadlinedatum;
            while (bezorgdagDateTime.DayOfWeek != bezorgdag)
                bezorgdagDateTime = bezorgdagDateTime.AddDays(+1);
            return bezorgdagDateTime;
        }


    }
}
