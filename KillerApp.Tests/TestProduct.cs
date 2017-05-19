using System;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp.Tests
{
    [TestClass]
    public class TestProduct
    {
        [TestMethod]
        public void TestAllProducts()
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);

            var list = repo.RetrieveAll();

            Assert.AreEqual(72, list[0].Voorraad);
        }

        [TestMethod]
        public void TestRetrieveProduct()
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);

            var p = repo.RetrieveProduct(202);

            Assert.AreEqual(72, p.Voorraad);
        }

        [TestMethod]
        public void TestRetrieveProductsByOrder()
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);

            var pList = repo.RetrieveProductByOrder(1);

            Assert.AreEqual(238, pList[0].Id);
        }
    }
}