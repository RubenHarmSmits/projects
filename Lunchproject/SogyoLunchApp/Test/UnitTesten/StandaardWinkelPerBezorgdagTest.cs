using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SogyoLunchApp
{
    class StandaardWinkelPerBezorgdagTest
    {
        [Test]
        public void TestGetDeadlineDag()
        {
            StandaardWinkelPerBezorgdag standaardWinkelPerBesteldag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Monday, BestelDeadlineDag = DayOfWeek.Friday };
            DateTime bezorgdatum = DateTime.Parse("2019-04-01");
            Assert.AreEqual(standaardWinkelPerBesteldag.GetDeadlineDatum(bezorgdatum).Date, DateTime.Parse("2019-03-29").Date);
        }

        [Test]
        public void TestGetBezorgDatumPerDeadline()
        {
            StandaardWinkelPerBezorgdag standaardWinkelPerBesteldag = new StandaardWinkelPerBezorgdag() { Dag = DayOfWeek.Monday, BestelDeadlineDag = DayOfWeek.Friday };
            DateTime deadlinedatum = DateTime.Parse("2019-04-05");
            Assert.AreEqual(standaardWinkelPerBesteldag.GetBezorgdagDatum(deadlinedatum, DayOfWeek.Monday).Date, DateTime.Parse("2019-04-08").Date);
        }
    }
}
