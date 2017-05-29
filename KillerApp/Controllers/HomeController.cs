using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["producten"] = (from product in Models.Product.All()
                select product).Reverse().Take(3).Reverse().ToList();
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Producten()
        //{
        //    ViewBag.Message = "Your product page.";
        //    return View();
        //}

        //public ActionResult Account()
        //{
        //    return View();
        //}
    }
}