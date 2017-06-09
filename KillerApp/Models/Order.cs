using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public List<Product> Producten { get; set; }
        public Klant Klant { get; set; }

        public decimal Totaal { get; set; }
        public Coupon Coupon { get; set; }



        public static List<Order> RetrieveAll()
        {
            var osql = new OrderSQL();
            var orepo = new OrderRepo(osql);
            return orepo.RetrieveAll();
        }

        public static Order RetrieveOrder(int id)
        {
            var osql = new OrderSQL();
            var orepo = new OrderRepo(osql);
            return orepo.RetrieveOrder(id);
        }

        public static void DeleteOrder(int id)
        {
            var osql = new OrderSQL();
            var orepo = new OrderRepo(osql);
            orepo.DeleteOrder(id);
        }

        public static void CreateOrder(Order o, Shoppingcart cart)
        {
            var osql = new OrderSQL();
            var orepo = new OrderRepo(osql);
            orepo.CreateOrder(o, cart);
        }
    }
}