using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class ProductRepo
    {
        private IProduct _productInterface;

        public ProductRepo(IProduct productInterface)
        {
            _productInterface = productInterface;
        }

        public List<Product> RetrieveAll()
        {
            return _productInterface.RetrieveAll();
        }

        public void CreateProduct(Product p)
        {
            _productInterface.CreateProduct(p);
        }

        public Product RetrieveProduct(int id)
        {
            return _productInterface.RetrieveProduct(id);
        }

        public void DeleteProduct(int id)
        {
            _productInterface.DeleteProduct(id);
        }

        public List<Product> RetrieveProductByOrder(int id)
        {
            return _productInterface.RetrieveProductByOrder(id);
        }

        public void UpdateProduct(Product p)
        {
            _productInterface.UpdateProduct(p);
        }

        public void UpdateKortingProduct(List<Korting> kortingList, int productId)
        {
            _productInterface.UpdateKortingProduct(kortingList, productId);
        }

        public List<Product> RetrieveProductByCategorie(int categorieId)
        {
            return _productInterface.RetrieveProductByCategorie(categorieId);
        }
    }
}