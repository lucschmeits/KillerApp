using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using KillerApp.DAL;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class AccountController : Controller
    {
      
        public ActionResult Index()
        {
            return View("Account");
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var email = form["email"];
            var wachtwoord = form["password"];
            var gebruiker = Auth.CheckLogin(email, wachtwoord);
            if (gebruiker != null)
            {
                if (gebruiker.GetType() == typeof(Klant))
                {
                    Session["klant"] = gebruiker;
                    return View("KlantHome", gebruiker);
                }
                if (gebruiker.GetType() == typeof(Beheerder))
                {
                    Session["beheerder"] = gebruiker;
                    return View("BeheerderHome", gebruiker);
                }
            }
            return View("Account");
        }

        public ActionResult Registreer(FormCollection form)
        {
            var naam = form["naam-r"];
            var email = form["email-r"];
            var wachtwoord = form["password-r"];
            var straat = form["straat-r"];
            var nr = form["nr-r"];
            var postcode = form["postcode-r"];
            var woonplaats = form["woonplaats-r"];
            var land = form["land-r"];
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            var gsql = new GebruikerSQL();
            var grepo = new GebruikerRepo(gsql);
            var gebruiker = new Gebruiker();
            gebruiker.Email = email;
            gebruiker.Naam = naam;
            gebruiker.Wachtwoord = wachtwoord;
            var id = grepo.CreateGebruiker(gebruiker);
            var klant = new Klant();
            klant.Straat = straat;
            klant.HuisNr = nr;
            klant.Postcode = postcode;
            klant.Woonplaats = woonplaats;
            klant.Land = land;
            krepo.CreateKlant(id, klant);
            return View("Account");
        }
        public ActionResult Klant()
        {
            return View("KlantHome");
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Beheerder()
        {
            return View("BeheerderHome");
        }
    }
}