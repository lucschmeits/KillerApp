using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public string Code { get; set; }
        public string Omschrijving { get; set; }

        public static List<Coupon> RetrieveAll()
        {
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            return crepo.RetrieveAll();
        }
    }
}