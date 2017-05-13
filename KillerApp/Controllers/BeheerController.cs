using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

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
            return View();
        }

        public ActionResult Producten()
        {
            return View();
        }

        public ActionResult Klanten()
        {
            return View();
        }

        public ActionResult Accounts()
        {
            return View();
        }

        public ActionResult Facturen()
        {
            return View();
        }

        public ActionResult Kortingscodes()
        {
            return View();
        }

        public ActionResult Korting()
        {
            return View();
        }
    }
}