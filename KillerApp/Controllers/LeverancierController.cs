using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class LeverancierController : Controller
    {
        // GET: Leverancier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View("LeverancierNew");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Edit(int id)
        {
            if (Session["beheerder"] != null)
            {
                ViewData["leverancier"] = Models.Leverancier.RetrieveLeverancier(id);
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View("LeverancierId");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Update(FormCollection form, int id)
        {
            if (Session["beheerder"] != null)
            {
                var leverancier = new Leverancier();
                leverancier.Id = id;
                leverancier.Naam = form["naam"];
                leverancier.LeveranciersNr = Convert.ToInt32(form["levNr"]);
                leverancier.TelefoonNr = form["telNr"];
                leverancier.Plaats = form["plaats"];
                leverancier.Straat = form["straat"];
                leverancier.HuisNr = form["huisNr"];
                leverancier.Postcode = form["postcode"];
                leverancier.Land = form["land"];
                Models.Leverancier.UpdateLeverancier(leverancier);
                return RedirectToAction("Leverancier", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Save(FormCollection form)
        {
            if (Session["beheerder"] != null)
            {
                var leverancier = new Leverancier();
                
                leverancier.Naam = form["naam"];
                leverancier.LeveranciersNr = Convert.ToInt32(form["levNr"]);
                leverancier.TelefoonNr = form["telNr"];
                leverancier.Plaats = form["plaats"];
                leverancier.Straat = form["straat"];
                leverancier.HuisNr = form["huisNr"];
                leverancier.Postcode = form["postcode"];
                leverancier.Land = form["land"];
                Models.Leverancier.CreateLeverancier(leverancier);
                return RedirectToAction("Leverancier", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            if (Session["beheerder"] != null)
            {
                Models.Leverancier.DeleteLeverancier(id);
                return RedirectToAction("Leverancier", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}