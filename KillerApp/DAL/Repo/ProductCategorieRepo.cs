using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class ProductCategorieRepo
    {
        private IProductCategorie _productCategorieInterface;

        public ProductCategorieRepo(IProductCategorie productCategorieInterface)
        {
            _productCategorieInterface = productCategorieInterface;
        }

        public List<Categorie> RetrieveAll()
        {
            return _productCategorieInterface.RetrieveAll();
        }

        public void CreateCategorie(Categorie c)
        {
            _productCategorieInterface.CreateCategorie(c);
        }

        public Categorie RetrieveCategorie(int id)
        {
            return _productCategorieInterface.RetrieveCategorie(id);
        }

        public void DeleteCategorie(int id)
        {
            _productCategorieInterface.DeleteCategorie(id);
        }

        public void UpdateCategorie(Categorie c)
        {
            _productCategorieInterface.UpdateCategorie(c);
        }
    }
}