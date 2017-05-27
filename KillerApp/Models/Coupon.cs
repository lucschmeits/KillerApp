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

        public static Coupon RetrieveCoupon(int id)
        {
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            return crepo.RetrieveCoupon(id);
        }

        public static void UpdateCoupon(Coupon c)
        {
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            crepo.UpdateCoupon(c);
        }

        public static void DeleteCoupon(int id)
        {
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            crepo.DeleteCoupon(id);
        }

        public static void CreateCoupon(Coupon c)
        {
            var csql = new CouponSQL();
            var crepo = new CouponRepo(csql);
            crepo.CreateCoupon(c);
        }
    }
}