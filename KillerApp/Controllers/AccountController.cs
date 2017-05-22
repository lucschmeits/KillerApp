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
                    return RedirectToAction("Klant");
                }
                if (gebruiker.GetType() == typeof(Beheerder))
                {
                    Session["beheerder"] = gebruiker;
                    return RedirectToAction("Beheerder");
                }
            }
           
                return Index();
          
        }

        public ActionResult Registreer(FormCollection form)
        {
            var gebruiker = new Gebruiker();
            gebruiker.Email = form["email-r"]; 
            gebruiker.Naam = form["naam-r"]; 
            gebruiker.Wachtwoord = form["password-r"]; ;
            var id = Gebruiker.CreateGebruiker(gebruiker);
            var klant = new Klant();
            klant.Straat = form["straat-r"];
            klant.HuisNr = form["nr-r"];
            klant.Postcode = form["postcode-r"];
            klant.Woonplaats = form["postcode-r"];
            klant.Land = form["land-r"];
            Models.Klant.CreateKlant(id, klant);
            return Index();
        }
        public ActionResult Klant()
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                var orders = Models.Order.RetrieveAll();
                var klantOrders = (from order in orders
                    where order.Klant.Id == klant.Id
                    select order).ToList();
                ViewData["Orders"] = klantOrders;
                return View("KlantHome", klant);
            }
           
                return Index();
          
        }

        public ActionResult Order(int id)
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                ViewData["Order"] = Models.Order.RetrieveOrder(id);
                return View(klant);
            }
            return Index();
        }

        public ActionResult Beheerder()
        {
            if (Session["beheerder"] != null)
            {
                
                var beheerder = (Beheerder)Session["beheerder"];
                return View("BeheerderHome", beheerder);
            }
           
                return Index();
          
        }
    }
}