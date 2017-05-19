using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = KillerApp.Models.Product.All();
            return View("Producten", products);
        }

        // GET Product/{id}
        public ActionResult Product(int id)
        {
            var p = KillerApp.Models.Product.ProductById(id);
            return View(p);
        }
    }
}