using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class ProductRepo
    {
        private IProduct _productInterface;

        public ProductRepo(IProduct productInterface)
        {
            _productInterface = productInterface;
        }
    }
}