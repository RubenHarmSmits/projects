using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Remotion.Linq.Clauses;
using SogyoLunchApp;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace Repository
{
    public class DBoperations
    {

        private readonly LunchAppContext Context;

        public DBoperations(LunchAppContext context)
        {
            Context = context;
        }

        #region ProductRegion

        public IQueryable<Product> GetProducten(Winkel winkel)
        {
            return Context.Producten.Include(x=>x.Categorie).Where(x => x.Winkel == winkel).AsQueryable();
        }

        public IQueryable<Product> GetProducten(DateTime date)
        {
            Winkel winkel = GetWinkelPerDatum(date);
            return GetProducten(winkel);
        }

        public void AddProduct(Product product)
        {
            Context.Producten.Add(product);
            Context.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            var product = Context.Producten.Where(p => p.ProductId == Id).Single();
            Context.Producten.Remove(product);
            Context.SaveChanges();
        }

        public IQueryable GetProductenPerCategorie(int categorieId)
        {
            return Context.Producten.Include(x=>x.Categorie).Where(x => x.CategorieId == categorieId);
        }

        #endregion

        #region WinkelRegion

        public void AddWinkel(Winkel winkel)
        {
            Context.Winkels.Add(winkel);
            Context.SaveChanges();
        }

        public Winkel GetWinkelBijId(int id)
        {
            return Context.Winkels.Find(id);
        }

        public Winkel GetWinkel(string name)
        {
            try
            {
                return Context.Winkels.Where(w => w.Winkelnaam.Equals(name)).AsQueryable().First();
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }

        }

        public Winkel GetWinkelPerDatum(DateTime datum)
        {
            if (DatumIsUitzondering(datum))
            {
                return Context.WinkelUitzonderingenPerBezorgdagen.Include(s => s.Winkel).Where(s => s.Date.Date == datum.Date).First().Winkel;
            }
            return Context.StandaardWinkelsPerBezorgdagen.Include(s => s.Winkel).Where(s => s.Dag == datum.DayOfWeek).Single().Winkel;
        }

        public Winkel GetStandaardWinkel(DayOfWeek dag)
        {
            if (Context.StandaardWinkelsPerBezorgdagen.Where(s => s.Dag == dag).Any())
            {
                return Context.StandaardWinkelsPerBezorgdagen.Include(s => s.Winkel).Where(s => s.Dag == dag).First().Winkel;
            }
            else return null;
        }

        public IQueryable<Winkel> GetWinkels()
        {
            return Context.Winkels.AsQueryable();
        }

        public void DeleteWinkel(int WinkelId)
        {
            var winkel = Context.Winkels.Where(w => w.WinkelId == WinkelId).Single();
            Context.Winkels.Remove(winkel);
            Context.SaveChanges();
        }

        //public void UpdateWinkel(int winkelId, string winkelNaam = null, string winkelLocatie = null)
        //{
        //    Winkel winkel = GetWinkelBijId(winkelId);
        //    if (winkelNaam != null) winkel.Winkelnaam = winkelNaam;
        //    if (winkelLocatie != null) winkel.Winkellocatie = winkelLocatie;
        //    Context.SaveChanges();
        //}

        public void UpdateWinkel(Winkel winkel)
        {
            Context.Entry(winkel).State = EntityState.Modified;
            Context.SaveChanges();
        }



        #endregion

        #region StandaardWinkelPerBezorgDag

        public void AddStandaardWinkel(StandaardWinkelPerBezorgdag winkeldefault)
        {
            if (GetStandaardWinkel(winkeldefault.Dag) != null)
            {
                EditStandaardWinkel(winkeldefault);
            }
            else if (GetStandaardWinkel(winkeldefault.Dag) == null)
            {
                Context.StandaardWinkelsPerBezorgdagen.Add(winkeldefault);
                Context.SaveChanges();
            }
        }

        public void EditStandaardWinkel(StandaardWinkelPerBezorgdag nieuweStandaardWinkelPerBesteldag)
        {
            StandaardWinkelPerBezorgdag wd = Context.StandaardWinkelsPerBezorgdagen.Include(s => s.Winkel).Where(d => d.Dag == nieuweStandaardWinkelPerBesteldag.Dag).Single();
            wd.Winkel = nieuweStandaardWinkelPerBesteldag.Winkel;
            wd.WinkelId = nieuweStandaardWinkelPerBesteldag.WinkelId;
            wd.BestelDeadlineDag = nieuweStandaardWinkelPerBesteldag.BestelDeadlineDag;
            wd.BestelDeadlineTijd = nieuweStandaardWinkelPerBesteldag.BestelDeadlineTijd;
            Context.SaveChanges();
        }

        public IQueryable<StandaardWinkelPerBezorgdag> GetStandaardWinkel()
        {
            return Context.StandaardWinkelsPerBezorgdagen.Where(wd => wd.Winkel != null).AsQueryable();
        }

        public IQueryable<StandaardWinkelPerBezorgdag> GetStandaardBezorgdagenPerWinkel(Winkel eenWinkel)
        {
            return Context.StandaardWinkelsPerBezorgdagen.Where(wd => wd.Winkel == eenWinkel).AsQueryable();
        }

        #endregion

        #region Deadline

        public DateTime GetDeadlinePerDatum(DateTime bezorgdatum)
        {
            if (DatumIsUitzondering(bezorgdatum))
            {
                WinkelUitzonderingenPerBezorgdag wupb = Context.WinkelUitzonderingenPerBezorgdagen.Where(w => w.Date == bezorgdatum).Single();
                return (DateTime)wupb.BestelDeadline;
            }
            else
            {
                DayOfWeek bezorgdag = bezorgdatum.DayOfWeek;
                StandaardWinkelPerBezorgdag winkelDezeDag = Context.StandaardWinkelsPerBezorgdagen.Where(x => x.Dag == bezorgdag).Single();
                return winkelDezeDag.GetDeadlineDatum(bezorgdatum);
            }

        }


        #endregion

        #region WinkelUitzonderingenPerBezorgdag


        public void AddWinkelUitzonderingenPerBezorgdag(WinkelUitzonderingenPerBezorgdag wupb)
        {
            Context.WinkelUitzonderingenPerBezorgdagen.Add(wupb);
            Context.SaveChanges();
        }

        public void DeleteWinkelUitzonderingPerBezorgdag(DateTime datum)
        {
            WinkelUitzonderingenPerBezorgdag wupb = Context.WinkelUitzonderingenPerBezorgdagen.Where(x => x.Date.Date == datum.Date).Single();
            Context.Entry(wupb).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public IQueryable<WinkelUitzonderingenPerBezorgdag> GetAlleWinkelUitzonderingenPerBezorgdag()
        {
            return Context.WinkelUitzonderingenPerBezorgdagen.Include(x => x.Winkel).Where(x => x.Date.Date >= DateTime.Now);
        }


        public Boolean DatumIsUitzondering(DateTime datum)
        {
            return Context.WinkelUitzonderingenPerBezorgdagen.Where(x => x.Date.Date == datum.Date).Any();
        }

        #endregion

        #region BezorgDagen

        public List<DateTime> GetBezorgdagen(int aantalDagen)
        {
            List<DateTime> Bezorgdagen = new List<DateTime>();
            for (int x = 0; x < aantalDagen; x++)
            {
                DateTime datum = DateTime.Now.AddDays(x);

                if (DatumIsUitzondering(datum))
                {
                    WinkelUitzonderingenPerBezorgdag wupb = Context.WinkelUitzonderingenPerBezorgdagen.Where(w => w.Date.Date == datum.Date).Single();
                    if (wupb.WinkelId != null) Bezorgdagen.Add(datum);                 
                }

                else
                {
                    StandaardWinkelPerBezorgdag winkelDezeDag = Context.StandaardWinkelsPerBezorgdagen.Where(y => y.Dag == datum.DayOfWeek).Single();
                    Boolean heeftWinkel = !winkelDezeDag.WinkelId.Equals(null);
                    if (heeftWinkel && DateTime.Now < winkelDezeDag.GetDeadlineDatum(datum.Date)) Bezorgdagen.Add(datum);
                }
            }
            return Bezorgdagen;
        }

        public List<DateTime> GetGeenBezorgdagen(int aantalDagen)
        {
            List<DateTime> Bezorgdagen = new List<DateTime>();
            for (int x = 0; x < aantalDagen; x++)
            {
                DateTime datum = DateTime.Now.AddDays(x);
                if (DatumIsUitzondering(datum))
                {
                    WinkelUitzonderingenPerBezorgdag wupb = Context.WinkelUitzonderingenPerBezorgdagen.Where(w => w.Date.Date == datum.Date).Single();
                    if (wupb.WinkelId == null) Bezorgdagen.Add(datum);
                }
                else
                {
                    StandaardWinkelPerBezorgdag winkelDezeDag = Context.StandaardWinkelsPerBezorgdagen.Where(y => y.Dag == datum.DayOfWeek).Single();
                    Boolean heeftWinkel = !winkelDezeDag.WinkelId.Equals(null);
                    if (!heeftWinkel) Bezorgdagen.Add(datum);
                }
            }
            return Bezorgdagen;
        }



        public List<DateTime> GetBezorgdatumsPerDeadline(DateTime deadlinedatum)
        {
            List<DateTime> BezorgdagenBijDeadline = new List<DateTime>();
            DayOfWeek deadlinedag = deadlinedatum.DayOfWeek;
            List<StandaardWinkelPerBezorgdag> winkelsDezeDag = Context.StandaardWinkelsPerBezorgdagen.Where(x => x.BestelDeadlineDag == deadlinedag).ToList();
            foreach (StandaardWinkelPerBezorgdag winkelDezeDag in winkelsDezeDag)
            {
                BezorgdagenBijDeadline.Add(winkelDezeDag.GetBezorgdagDatum(deadlinedatum, winkelDezeDag.Dag));
            };
            return BezorgdagenBijDeadline;

        }

        #endregion

        /*#region GebruikerRegion

        public IQueryable<Gebruiker> GetGebruikers()
        {
            return Context.Gebruikers;
        }

        public void MaakGebruiker(Gebruiker gebruiker)
        {
            Context.Gebruikers.Add(gebruiker);
            Context.SaveChanges();
        }

        public void DeleteGebruiker(int gebruikerId)
        {
            Gebruiker gebruiker = Context.Gebruikers.Find(gebruikerId);
            Context.Remove(gebruiker);
            Context.SaveChanges(); 
        }

        public void UpdateGebruiker(int gebruikerId,string voornaam =null, string achternaam=null, string email=null, Boolean isAdministrator=false)
        {
            var gebruiker = GetGebruikerBijId(gebruikerId);          
            if(voornaam!=null) gebruiker.Voornaam = voornaam;
            if (achternaam != null) gebruiker.Achternaam = achternaam;
            if (email != null) gebruiker.Email = email;
            gebruiker.IsAdministrator = isAdministrator;          
            Context.SaveChanges(); 
        }

        public Gebruiker GetGebruikerBijId(int gebruikerId)
        { 
            return Context.Gebruikers.Where(x => x.GebruikerId == gebruikerId).Single();
        }

        #endregion
        */

        #region BestellingRegion

        public IQueryable<Bestelling> GetAlleBestellingen()
        {
            return Context.Bestellingen.Include(x => x.ProductenPerBestellingen).ThenInclude(x=> x.Product);
        }

        public void MaakBestelling(Bestelling bestelling)
        {
            if (!CheckOfBestelBestaat(bestelling)) Context.Bestellingen.Add(bestelling);
            else VoegBestellingenSamen(bestelling);

            Context.SaveChanges();
        }

        public void VoegBestellingenSamen(Bestelling bestelling)
        {
            Bestelling origineleBestelling = Context.Bestellingen
                .Include(x=>x.ProductenPerBestellingen)
                .Where(x => x.GebruikerId == bestelling.GebruikerId)
                .Where(x => x.Bezorgdatum.Date == bestelling.Bezorgdatum.Date).First();

            origineleBestelling.ProductenPerBestellingen = origineleBestelling.VoegBestellingenSamen(bestelling);

        }

        public Boolean CheckOfBestelBestaat(Bestelling bestelling)
        {
            if (Context.Bestellingen
                .Where(x => x.GebruikerId == bestelling.GebruikerId)
                .Where(x => x.Bezorgdatum.Date == bestelling.Bezorgdatum.Date).Any()) return true;
            else return false;
        }


        public IQueryable<Bestelling> GetBestellingenPerDatumEnGebruiker(DateTime date, Guid gebruikerId)
        {
            return Context.Bestellingen
                .Include(x => x.ProductenPerBestellingen)
                .ThenInclude(x => x.Product)
                .Where(x => x.Bezorgdatum.Date == date.Date)
                .Where(x => x.GebruikerId == gebruikerId);
        }

        public IQueryable<Bestelling> GetBestellingenPerDatum(DateTime date)
        {
            return Context.Bestellingen
                .Include(x => x.ProductenPerBestellingen)
                .ThenInclude(x => x.Product)
                .Where(x => x.Bezorgdatum.Date == date.Date);
        }

        public IQueryable<Bestelling> GetBestellingenPerMaandEnGebruiker(DateTime maand, Guid gebruikerId)
        {
            return Context.Bestellingen
                .Include(x => x.ProductenPerBestellingen)
                .ThenInclude(x => x.Product)
                .Where(x => x.Bezorgdatum.Month == maand.Month)
                .Where(x=>x.Bezorgdatum.Year==maand.Year)
                .Where(x => x.GebruikerId == gebruikerId);
        }



        public void VerwijderProductenPerBestelling(ProductenPerBestelling ppb)
        {
            ProductenPerBestelling ppbOrigineel = Context.ProductenPerBestellingen.Where(x => x.ProductId == ppb.ProductId).Where(x => x.BestellingId == ppb.BestellingId).Single();

            Context.Entry(ppbOrigineel).State = EntityState.Deleted;

            Context.SaveChanges();
        }

        public void VerwijderBestellingenPerDatum(DateTime datum)
        {
            var bestellingen = Context.Bestellingen.Where(x => x.Bezorgdatum.Date==datum.Date);

            Context.Bestellingen.RemoveRange(bestellingen);

            Context.SaveChanges();
        }




        #endregion

        #region Categorieregion

        public void AddCategorie(Categorie categorie)
        {
            Context.Categorien.Add(categorie);
            Context.SaveChanges();
        }

        public IQueryable<Categorie> GetAlleCategorien()
        {
            return Context.Categorien.Include(x=>x.Winkel);
        }

        public IQueryable<Categorie> GetCategorienPerWinkel(int winkelId)
        {
            return Context.Categorien.Include(x => x.Winkel).Where(x => x.WinkelId == winkelId);
        }

        public void UpdateCategorie(Categorie categorie)
        {
            Context.Entry(categorie).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void DeleteCategorie(int categorieId)
        {
            Categorie categorie = Context.Categorien.Find(categorieId);

            Context.Producten.Where(v => v.CategorieId == categorieId).Load();

            Context.Entry(categorie).State = EntityState.Deleted;
            Context.SaveChanges();

            Context.SaveChanges();

        }
        public void AddNotitie(ProductenPerBestelling ppb)
        {
            Context.Entry(ppb).State = EntityState.Modified;
            Context.SaveChanges();
        }

        #endregion

    }

}

