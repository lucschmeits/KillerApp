using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class CouponController : Controller
    {
        // GET: Coupon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["coupon"] = Coupon.RetrieveCoupon(id);
                    return View("CouponEdit");
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
                    Coupon.DeleteCoupon(id);
                    return RedirectToAction("Kortingscodes", "Beheer");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update(FormCollection form, int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    var coupon = new Coupon();
                    coupon.Id = id;
                    coupon.Code = form["code"];
                    coupon.Omschrijving = form["omschrijving"];
                    coupon.Percentage = decimal.Parse(form["percentage"]);
                    Coupon.UpdateCoupon(coupon);
                    return RedirectToAction("Kortingscodes", "Beheer");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult New()
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    return View("CouponNew");
                }
                return RedirectToAction("Index", "Account");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Save(FormCollection form)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    var coupon = new Coupon();
                    coupon.Code = form["code"];
                    coupon.Omschrijving = form["omschrijving"];
                    coupon.Percentage = decimal.Parse(form["percentage"]);
                    Coupon.CreateCoupon(coupon);
                    return RedirectToAction("Kortingscodes", "Beheer");
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