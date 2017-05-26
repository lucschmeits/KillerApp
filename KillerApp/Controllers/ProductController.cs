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

        public ActionResult New()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                return View("ProductNew");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Edit(int id)
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Product"] = Models.Product.ProductById(id);
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["Leveranciers"] = Leverancier.RetrieveAll();
                ViewData["Categorieen"] = Categorie.RetrieveAll();
                ViewData["Kortingen"] = Korting.RetrieveAll();
                return View("ProductEdit");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Save(FormCollection form)
        {
            if (Session["beheerder"] != null)
            {
                var product = new Product();

               
                Models.Product.CreateProduct(product);
                return RedirectToAction("Producten", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Update(FormCollection form, int id)
        {
            if (Session["beheerder"] != null)
            {
                var product = new Product();
               
                product.Categorie = new Categorie();
                product.Leverancier = new Leverancier();
                product.Kortingen = new List<Korting>();
                product.Id = id;
                product.Naam = form["naam"];
                product.Omschrijving = form["omschrijving"];
                product.Prijs = decimal.Parse(form["prijs"]);
                product.Categorie.Id = Convert.ToInt32(form["catId"]);
                product.Leverancier.Id = Convert.ToInt32(form["levId"]);
                var kortingIds = form.GetValues("kortingId");
                if (kortingIds != null)
                {
                    foreach (var KortingId in kortingIds)
                    {
                        var korting = new Korting();
                        korting.Id = Convert.ToInt32(KortingId);
                        product.Kortingen.Add(korting);
                    }
                    Models.Product.UpdateKortingProduct(product.Kortingen, product.Id);
                }
                Models.Product.UpdateProduct(product);
                return RedirectToAction("Producten", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            if (Session["beheerder"] != null)
            {
                Models.Product.DeleteProduct(id);
                return RedirectToAction("Producten", "Beheer");
            }
            return RedirectToAction("Index", "Account");
        }
    }
}