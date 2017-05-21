using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = Models.Product.All();
            return View("Producten", products);
        }

        // GET Product/{id}
        public ActionResult Product(int id)
        {
            var product = new Product();
            
            var p = Models.Product.ProductById(id);
            p.GemiddeldeBeoordeling = product.GemiddeldeScore(p);
            return View(p);
        }
    }
}