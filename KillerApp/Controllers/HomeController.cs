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
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }

           
        }

       
    }
}