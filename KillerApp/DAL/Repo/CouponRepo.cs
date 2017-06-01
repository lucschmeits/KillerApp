using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class CouponRepo
    {
        private ICoupon _couponInterface;

        public CouponRepo(ICoupon couponInterface)
        {
            _couponInterface = couponInterface;
        }

        public List<Coupon> RetrieveAll()
        {
            return _couponInterface.RetrieveAll();
        }

        public void CreateCoupon(Coupon c)
        {
            _couponInterface.CreateCoupon(c);
        }

        public Coupon RetrieveCoupon(int id)
        {
            return _couponInterface.RetrieveCoupon(id);
        }

        public void DeleteCoupon(int id)
        {
            _couponInterface.DeleteCoupon(id);
        }

        public void UpdateCoupon(Coupon c)
        {
            _couponInterface.UpdateCoupon(c);
        }

        public Coupon RetrieveCouponByCode(string code)
        {
            return _couponInterface.RetrieveCouponByCode(code);
        }
    }
}