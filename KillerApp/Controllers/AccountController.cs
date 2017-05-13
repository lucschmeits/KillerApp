using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
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