﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewData["producten"] = Models.Product.All();
            ViewData["categorieen"] = Models.Categorie.RetrieveAll();
            return View("Producten");
        }

        public ActionResult ProductCategorie(int id)
        {
            ViewData["producten"] = Models.Product.RetrieveProductByCategorie(id);
            ViewData["categorieen"] = Models.Categorie.RetrieveAll();
            return View("Producten");
        }

        public ActionResult Search(FormCollection form)
        {
            string search = form["search"];
            ViewData["producten"] = (from product in Models.Product.All()
                where product.Naam.Contains(search)
                select product).ToList();
            ViewData["categorieen"] = Models.Categorie.RetrieveAll();
            return View("Producten");
        }

        public ActionResult Price(int min, int max)
        {
            ViewData["producten"] = (from product in Models.Product.All()
                where product.Prijs >= min && product.Prijs <= max
                select product).ToList();
            ViewData["categorieen"] = Models.Categorie.RetrieveAll();
            return View("Producten");
        }
        // GET Product/{id}
        //public ActionResult Product(int id)
        //{
        //    var product = new Product();
            
        //    var p = Models.Product.ProductById(id);
        //    p.GemiddeldeBeoordeling = product.GemiddeldeScore(p);
        //    if (p.Kortingen != null)
        //    {
        //        ViewData["newprijs"] = p.NewPrijs(p).ToString("C");
        //    }
        //    ViewData["product"] = p;
        //    return View();
        //}
        
        public ActionResult Product(int id, string melding)
        {
            var product = new Product();

            var p = Models.Product.ProductById(id);
            p.GemiddeldeBeoordeling = product.GemiddeldeScore(p);
            if (p.Kortingen != null)
            {
                ViewData["newprijs"] = p.NewPrijs(p).ToString("C");
            }
            ViewData["product"] = p;
            ViewData["melding"] = melding;
            return View();
        }
        public ActionResult New()
        {
            if (Session["beheerder"] != null)
            {
                ViewData["Beheerder"] = (Beheerder)Session["beheerder"];
                ViewData["Leveranciers"] = Leverancier.RetrieveAll();
                ViewData["Categorieen"] = Categorie.RetrieveAll();
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
              
                return View("ProductEdit");
            }
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Save(FormCollection form)
        {
            if (Session["beheerder"] != null)
            {
                var product = new Product();
                product.Categorie = new Categorie();
                product.Leverancier = new Leverancier();
                product.Naam = form["naam"];
                product.Omschrijving = form["omschrijving"];
                product.Prijs = decimal.Parse(form["prijs"]);
                product.Categorie.Id = Convert.ToInt32(form["catId"]);
                product.Leverancier.Id = Convert.ToInt32(form["levId"]);
                product.Voorraad = Convert.ToInt32(form["voorraad"]);
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
              
                product.Id = id;
                product.Naam = form["naam"];
                product.Omschrijving = form["omschrijving"];
                product.Prijs = decimal.Parse(form["prijs"]);
                product.Categorie.Id = Convert.ToInt32(form["catId"]);
                product.Leverancier.Id = Convert.ToInt32(form["levId"]);
              
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

        public ActionResult SaveBeoordeling(FormCollection form, int id)
        {
            if (Session["klant"] != null)
            {
                var beoordeling = new Beoordeling();
                beoordeling.Titel = form["titel"];
                beoordeling.Cijfer = Convert.ToInt32(form["cijfer"]);
                beoordeling.Omschrijving = form["omschrijving"];
                beoordeling.Product = Models.Product.ProductById(id);
                Models.Beoordeling.CreateBeoordeling(beoordeling);
               return RedirectToAction("Product", "Product", new {id});
            }
            var melding = "U moet inloggen om een review te plaatsen.";
            return RedirectToAction("Product", "Product", new {id, melding});
            //return Product(id, melding);
        }
    }
}