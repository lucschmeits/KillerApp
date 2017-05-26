using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class BeheerController : Controller
    {
        // GET: Beheer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Leverancier()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Leveranciers"] = Models.Leverancier.RetrieveAll();
                ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Producten()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["producten"] = Product.All();
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Klanten()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["klanten"] = Klant.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Accounts()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["beheerders"] = Beheerder.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Facturen()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["orders"] = Order.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Kortingscodes()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["coupons"] = Coupon.RetrieveAll();
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Korting()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["kortingen"] = Models.Korting.RetrieveAll();
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Edit(int id)
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["BeheerderId"] = Models.Beheerder.RetrieveBeheerder(id);
                return View("BeheerEdit");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Update(FormCollection form, int id)
        {
            if (Session["beheerder"] != null)
            {
                var beheerder = new Beheerder();
                beheerder.Id = id;
                beheerder.Naam = form["naam"];
                beheerder.Email = form["email"];
                beheerder.Wachtwoord = form["wachtwoord"];
                Models.Beheerder.UpdateGebruiker(beheerder);
                return RedirectToAction("Accounts", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            if (Session["beheerder"] != null)
            {
                Models.Beheerder.DeleteBeheerder(id);
                return RedirectToAction("Accounts", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult New()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View("BeheerNew");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Save(FormCollection form)
        {
            if (Session["beheerder"] != null)
            {
                var beheerder = new Beheerder();
                beheerder.Naam = form["naam"];
                beheerder.Email = form["email"];
                beheerder.Wachtwoord = form["wachtwoord"];
                var id = Models.Gebruiker.CreateGebruiker(beheerder);
                Models.Beheerder.CreateBeheerder(id);
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return RedirectToAction("Accounts", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}