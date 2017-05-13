using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class OrderRepo
    {
        private IOrder _orderInterface;

        public OrderRepo(IOrder orderInterface)
        {
            _orderInterface = orderInterface;
        }
    }
}