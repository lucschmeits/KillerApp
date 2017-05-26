using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class OrderRepo
    {
        private IOrder _orderInterface;

        public OrderRepo(IOrder orderInterface)
        {
            _orderInterface = orderInterface;
        }

        public List<Order> RetrieveAll()
        {
            return _orderInterface.RetrieveAll();
        }

        public void CreateOrder(Order o, Shoppingcart cart)
        {
            _orderInterface.CreateOrder(o, cart);
        }

        public Order RetrieveOrder(int id)
        {
            return _orderInterface.RetrieveOrder(id);
        }

        public void DeleteOrder(int id)
        {
            _orderInterface.DeleteOrder(id);
        }
    }
}