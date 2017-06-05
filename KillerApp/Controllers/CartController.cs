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
                if (form.Count != 0)
                {
                    bestelling.Aantal = Convert.ToInt32(form["aantal"]);
                }
                else
                {
                    bestelling.Aantal = 1;
                }
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
               
                var totaal = Shoppingcart.GetTotaalWinkelwagen(shoppingCart.Bestellingen, null);
                Session["totaal"] = totaal;
               
                return RedirectToAction("Index");
            }
            if (Session["cart"] != null)
            {
                var bestelling = new Bestelling();
                if (form.Count != 0)
                {
                    bestelling.Aantal = Convert.ToInt32(form["aantal"]);
                }
                else
                {
                    bestelling.Aantal = 1;
                }
                
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


                var totaal = Shoppingcart.GetTotaalWinkelwagen(cart.Bestellingen, null);
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
                        foreach (Bestelling bes in cart.Bestellingen)
                        {
                            productList.Add(bes.Product);
                            
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

       [HttpPost]
        public ActionResult ApplyCoupon(string code)
        {

            if (Session["cart"] != null)
            {
                var cart = Session["cart"] as Shoppingcart;
               
              
                    var order = new Order();
                    if (!string.IsNullOrEmpty(code))
                    {
                        order.Coupon = Coupon.RetrieveCouponByCode(code);
                    }
                    else
                    {
                        order.Coupon = Coupon.RetrieveCoupon(5);
                    }

                    var totaal = Shoppingcart.GetTotaalWinkelwagen(cart.Bestellingen, order.Coupon);
                    Session["totaal"] = totaal;
                    // return Json(code + true);
                    var redirectUrlCart = new UrlHelper(Request.RequestContext).Action("Index", "Cart");
                    return Json(new { Url = redirectUrlCart });
                  
               
               

            }
            var redirectUrlProduct = new UrlHelper(Request.RequestContext).Action("Index", "Product");
            return Json(new { Url = redirectUrlProduct });
           
        }

        public ActionResult Remove(int id)
        {
         
            var cart = Session["cart"] as Shoppingcart;
            var bestel = (from bestelling in cart.Bestellingen
                where bestelling.Product.Id == id
                select bestelling).First();
           
            cart.Bestellingen.Remove(bestel);
            var totaal = Shoppingcart.GetTotaalWinkelwagen(cart.Bestellingen, null);
            Session["totaal"] = totaal;
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCart(int id, int aantal)
        {
            if (Session["cart"] != null)
            {
                var cart = Session["cart"] as Shoppingcart;
               
               

                        var bestel = (from bestelling in cart.Bestellingen
                        where bestelling.Product.Id == id
                        select bestelling).First();

                    bestel.Aantal = aantal;

                    var totaal = Shoppingcart.GetTotaalWinkelwagen(cart.Bestellingen, null);
                    Session["totaal"] = totaal;
                  
                    var redirectUrlCart = new UrlHelper(Request.RequestContext).Action("Index", "Cart");
                    return Json(new { Url = redirectUrlCart });

              


            }
            var redirectUrlProduct = new UrlHelper(Request.RequestContext).Action("Index", "Product");
            return Json(new { Url = redirectUrlProduct });
        }
    }
}