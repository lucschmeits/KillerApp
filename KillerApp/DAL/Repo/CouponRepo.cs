using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class CouponRepo
    {
        private ICoupon _couponInterface;

        public CouponRepo(ICoupon couponInterface)
        {
            _couponInterface = couponInterface;
        }
    }
}