using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace KillerApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public List<Product> Producten { get; set; }
        public Klant Klant { get; set; }

        public Coupon Coupon { get; set; }
    }
}