using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.Models;

namespace KillerApp.Controllers
{
    public class KortingController : Controller
    {
        // GET: Korting
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Edit(int id)
        {
            try
            {
                if (Session["beheerder"] != null)
                {
                    ViewData["Beheerder"] = (Beheerder) Session["beheerder"];
                    ViewData["korting"] = Korting.RetrieveKortingById(id);
                    ViewData["producten"] = Product.All();
                    return View("KortingEdit");
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
                    return View("KortingNew");
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
                    Korting.DeleteKorting(id);
                    return RedirectToAction("Korting", "Beheer");
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
                    var korting = new Korting();
                    korting.Id = id;
                    korting.Percentage = decimal.Parse(form["percentage"]);
                    korting.Omschrijving = form["omschrijving"];
                    var productIds = form.GetValues("productId");
                    var productIdList = new List<int>();
                    if (productIds != null)
                    {
                        foreach (var productid in productIds)
                        {
                            productIdList.Add(Convert.ToInt32(productid));
                        }
                    }

                    Korting.UpdateKorting(korting, productIdList);
                    return RedirectToAction("Korting", "Beheer");
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
                    var korting = new Korting();

                    korting.Percentage = decimal.Parse(form["percentage"]);
                    korting.Omschrijving = form["omschrijving"];
                    Korting.CreateKorting(korting);
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