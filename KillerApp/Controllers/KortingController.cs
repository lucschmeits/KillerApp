using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class KortingController : Controller
    {
        // GET: Korting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["korting"] = Korting.RetrieveKortingById(id);
                return View("KortingEdit");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult New()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View("KortingNew");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            if (Session["beheerder"] != null)
            {
                Korting.DeleteKorting(id);
                return RedirectToAction("Korting", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Update(FormCollection form, int id)
        {
            if (Session["beheerder"] != null)
            {
                var korting = new Korting();
                korting.Id = id;
                korting.Percentage = decimal.Parse(form["percentage"]);
                korting.Omschrijving = form["omschrijving"];
                
               Korting.UpdateKorting(korting);
                return RedirectToAction("Korting", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Save(FormCollection form)
        {
            if (Session["beheerder"] != null)
            {
                var korting = new Korting();
             
                korting.Percentage = decimal.Parse(form["percentage"]);
                korting.Omschrijving = form["omschrijving"];
                Korting.CreateKorting(korting);
                return RedirectToAction("Kortingscodes", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}