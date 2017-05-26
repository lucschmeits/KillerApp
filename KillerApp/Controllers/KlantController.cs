using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class KlantController : Controller
    {
        // GET: Klant
        public ActionResult Index()
        {
            if (Session["klant"] != null)
            {
                return View();
            }
            return Redirect("/Account");
        }

        public ActionResult Orders(int id)
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                ViewData["Order"] = Models.Order.RetrieveOrder(id);
                return View(klant);
            }
            return Redirect("/Account");
           
        }

        public ActionResult Info()
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                return View("Info", klant);
            }
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Edit(int id)
        {
            if (Session["beheerder"] != null)
            {
                ViewData["beheerder"] = (Beheerder) Session["beheerder"];
                var klant = Models.Klant.RetrieveKlant(id);
                return View("KlantEdit", klant);
            }
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Update(FormCollection form, int id)
        {
            var klant = new Klant();
            klant.Id = id;
            klant.Naam = form["naam"];
            klant.Email = form["email"];
            klant.Wachtwoord = form["wachtwoord"];
            klant.Straat = form["straat"];
            klant.HuisNr = form["huisnr"];
            klant.Postcode = form["postcode"];
            klant.Woonplaats = form["woonplaats"];
            klant.Land = form["land"];

            if (Session["beheerder"] != null)
            {
                Models.Klant.UpdateKlant(klant);
                return RedirectToAction("Beheerder", "Account");
            }
            if (Session["klant"] != null)
            {
                Models.Klant.UpdateKlant(klant);
                return RedirectToAction("Klant", "Account");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            if (Session["beheerder"] != null)
            {
                Models.Klant.DeleteKlant(id);
                return RedirectToAction("Beheerder", "Account");
            }
            if (Session["klant"] != null)
            {
                Models.Klant.DeleteKlant(id);
                return RedirectToAction("Klant", "Account");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}