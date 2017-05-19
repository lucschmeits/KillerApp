using System;
using System.Collections.Generic;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using KillerApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp.Tests
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void TestCreateOrder()
        {
            var plist = new List<Product>();
            var sql = new OrderSQL();
            var repo = new OrderRepo(sql);
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            var psql = new ProductSQL();
            var prepo = new ProductRepo(psql);
            var osql = new OrderSQL();
            var orepo = new OrderRepo(osql);

            var p1 = prepo.RetrieveProduct(279);
            var p2 = prepo.RetrieveProduct(288);
            plist.Add(p1);
            plist.Add(p2);
            var order = new Order();
            order.Datum = DateTime.Now;
            order.Klant = krepo.RetrieveKlant(327);
            order.Coupon = crepo.RetrieveCoupon(1);
            order.Producten = plist;
            var b = new Bestelling();
            b.Aantal = 2;
            b.ProductId = plist[0].Id;
            var b1 = new Bestelling();
            b1.Aantal = 1;
            b1.ProductId = plist[1].Id;
            var s = new Shoppingcart();
            s.Bestellingen.Add(b);
            s.Bestellingen.Add(b1);
            s.KlantId = krepo.RetrieveKlant(327).Id;

            //  repo.CreateOrder(order, s);

            Assert.AreEqual(327, orepo.RetrieveOrder(12).Klant.Id);
        }
    }
}