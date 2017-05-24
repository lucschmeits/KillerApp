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
                Klant.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Accounts()
        {
            if (Session["beheerder"] != null)
            {
                Beheerder.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Facturen()
        {
            if (Session["beheerder"] != null)
            {
                Order.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Kortingscodes()
        {
            if (Session["beheerder"] != null)
            {
                Coupon.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Korting()
        {
            if (Session["beheerder"] != null)
            {
                Models.Korting.RetrieveAll();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

       

       

        
    }
}