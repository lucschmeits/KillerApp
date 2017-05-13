using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class ProductCategorieRepo
    {
        private IProductCategorie _productCategorieInterface;

        public ProductCategorieRepo(IProductCategorie productCategorieInterface)
        {
            _productCategorieInterface = productCategorieInterface;
        }
    }
}