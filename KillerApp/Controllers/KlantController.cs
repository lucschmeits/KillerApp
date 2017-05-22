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
            return View();
        }

        public ActionResult Orders(int id)
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                ViewData["Order"] = Models.Order.RetrieveOrder(id);
                return View(klant);
            }
            return Index();
           
        }

        public ActionResult Info()
        {
            if (Session["klant"] != null)
            {
                var klant = (Klant)Session["Klant"];
                return View("Info", klant);
            }
            return Index();
        }

        public ActionResult Update(FormCollection form)
        {
            return null;
        }
    }
}