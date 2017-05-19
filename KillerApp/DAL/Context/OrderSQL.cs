using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class OrderSQL : IOrder
    {
        public void CreateOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public List<Order> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Order RetrieveOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}