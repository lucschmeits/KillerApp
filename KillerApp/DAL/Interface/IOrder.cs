using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IOrder
    {
        List<Order> RetrieveAll();

        void CreateOrder(Order o, Shoppingcart cart);

        Order RetrieveOrder(int id);
    }
}