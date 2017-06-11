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
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Leveranciers"] = Models.Leverancier.RetrieveAll();
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Producten()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["producten"] = Product.All();
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Klanten()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["klanten"] = Klant.RetrieveAll();
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Accounts()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["beheerders"] = Beheerder.RetrieveAll();
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Facturen()
        {
            try
            {

                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["orders"] = Order.RetrieveAll();
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Kortingscodes()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["coupons"] = Coupon.RetrieveAll();
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Korting()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["kortingen"] = Models.Korting.RetrieveAll();
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View();
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["BeheerderId"] = Models.Beheerder.RetrieveBeheerder(id);
                    return View("BeheerEdit");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update(FormCollection form, int id)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    Models.Beheerder.DeleteBeheerder(id);
                    return RedirectToAction("Accounts", "Beheer");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult New()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View("BeheerNew");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Save(FormCollection form)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    var beheerder = new Beheerder();
                    beheerder.Naam = form["naam"];
                    beheerder.Email = form["email"];
                    beheerder.Wachtwoord = form["wachtwoord"];
                    var id = Models.Gebruiker.CreateGebruiker(beheerder);
                    Models.Beheerder.CreateBeheerder(id);
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return RedirectToAction("Accounts", "Beheer");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}