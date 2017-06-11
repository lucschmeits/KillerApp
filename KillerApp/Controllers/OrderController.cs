using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["order"] = Order.RetrieveOrder(id);
                    return View("OrderEdit");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {

                    Order.DeleteOrder(id);
                    return RedirectToAction("Facturen", "Beheer");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}