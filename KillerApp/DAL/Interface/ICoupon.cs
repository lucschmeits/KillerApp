using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface ICoupon
    {
        List<Coupon> RetrieveAll();

        void CreateCoupon(Coupon c);

        Coupon RetrieveCoupon(int id);

        void DeleteCoupon(int id);

        void UpdateCoupon(Coupon c);

        Coupon RetrieveCouponByCode(string code);

    }
}