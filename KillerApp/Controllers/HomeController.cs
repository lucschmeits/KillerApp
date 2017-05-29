using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productList = new List<Product>();
            foreach (var product in Models.Product.All())
            {
                if (product.Kortingen != null)
                {
                    product.NiewPrijs = product.NewPrijs(product).ToString("C");
                }
                productList.Add(product);
            }
            ViewData["producten"] = (from product in productList
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