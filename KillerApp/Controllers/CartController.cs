using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["cart"] != null)
            {
                ViewData["winkelmand"] = Session["cart"];
                ViewData["totaal"] = Session["totaal"];
                //var shoppingcart = (Shoppingcart) Session["cart"];

            }
            return View("Winkelmand");
        }

        public ActionResult AddToCart(FormCollection form, int id)
        {
          
            if (Session["cart"] == null)
            {
                var bestelling = new Bestelling();
                bestelling.Aantal = Convert.ToInt32(form["aantal"]);
                bestelling.Product = Product.ProductById(id);
               if (bestelling.Product.Kortingen != null || bestelling.Product.Kortingen.Count >= 1)
                {
                    bestelling.Product.NiewPrijs = bestelling.Product.NewPrijs(bestelling.Product).ToString("C");
                    bestelling.Totaal = Shoppingcart.GetTotaalProductDecimal(bestelling.Product.NewPrijs(bestelling.Product),
                        bestelling.Aantal);
                }
                if (bestelling.Product.Kortingen == null || bestelling.Product.Kortingen.Count == 0)
                {
                    bestelling.Totaal = Shoppingcart.GetTotaalProductDecimal(bestelling.Product.Prijs,
                        bestelling.Aantal);
                }
                var shoppingCart = new Shoppingcart();
                shoppingCart.Bestellingen.Add(bestelling);
                if (Session["klant"] != null)
                {
                    var klant =  (Klant)Session["klant"];
                    shoppingCart.KlantId = klant.Id;
                }
                Session["cart"] = shoppingCart;
               
                var totaal = Shoppingcart.GetTotaalWinkelwagen(shoppingCart.Bestellingen);
                Session["totaal"] = totaal;
               
                return RedirectToAction("Index");
            }
            if (Session["cart"] != null)
            {
                var bestelling = new Bestelling();
                bestelling.Aantal = Convert.ToInt32(form["aantal"]);
                bestelling.Product = Product.ProductById(id);
               
                if (bestelling.Product.Kortingen != null || bestelling.Product.Kortingen.Count >= 1)
                {
                    bestelling.Product.NiewPrijs = bestelling.Product.NewPrijs(bestelling.Product).ToString("C");
                    bestelling.Totaal = Shoppingcart.GetTotaalProductDecimal(bestelling.Product.NewPrijs(bestelling.Product),
                        bestelling.Aantal);
                }
                if (bestelling.Product.Kortingen == null || bestelling.Product.Kortingen.Count == 0)
                {
                    bestelling.Totaal = Shoppingcart.GetTotaalProductDecimal(bestelling.Product.Prijs,
                        bestelling.Aantal);
                }
                var cart = (Shoppingcart) Session["cart"];
                cart.Bestellingen.Add(bestelling);
                if (Session["klant"] != null)
                {
                    var klant = (Klant)Session["klant"];
                    cart.KlantId = klant.Id;
                }


                var totaal = Shoppingcart.GetTotaalWinkelwagen(cart.Bestellingen);
                Session["totaal"] = totaal;
                return RedirectToAction("Index");
            }
            return null;
        }

        public ActionResult Order(FormCollection form)
        {
            if (Session["cart"] != null)
            {
                var cart = Session["cart"] as Shoppingcart;
                var productList = new List<Product>();
                if (Session["klant"] != null)
                {
                    var klant = (Klant)Session["klant"];
                    var order = new Order();
                    order.Datum = DateTime.Now;
                    order.Klant = Klant.RetrieveKlant(klant.Id);
                    if (form["coupon"] != "")
                    {
                        order.Coupon = Coupon.RetrieveCouponByCode(form["coupon"].ToString());
                    }
                    else
                    {
                        order.Coupon = Coupon.RetrieveCoupon(5);
                    }
                    
                    if (cart != null)
                    {
                        for (int i = 0; i < cart.Bestellingen.Count; i++)
                        {
                            productList.Add(cart.Bestellingen[i].Product);
                        }
                    }
                  
                    order.Producten = productList;

                    Models.Order.CreateOrder(order, cart);
                    Session["cart"] = null;
                    return RedirectToAction("Klant", "Account");
                }


                return RedirectToAction("Index", "Account");
            }
            return null;
        }
    }
}