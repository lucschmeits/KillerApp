using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IProduct
    {
        List<Product> RetrieveAll();

        void CreateProduct(Product p);

        Product RetrieveProduct(int id);

        void DeleteProduct(int id);

        void UpdateProduct(Product p);

        List<Product> RetrieveProductByOrder(int id);

        void UpdateKortingProduct(List<Korting> kortingList, int productId);
    }
}