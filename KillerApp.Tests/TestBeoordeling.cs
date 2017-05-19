using System;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp.Tests
{
    [TestClass]
    public class TestBeoordeling
    {
        [TestMethod]
        public void TestBeoordelingByProduct()
        {
            var beoordelingSql = new BeoordelingSQL();
            var beroodelingRepo = new BeoordelingRepo(beoordelingSql);

            var list = beroodelingRepo.BeoordelingByProduct(220);

            Assert.AreEqual(3, list[0].Cijfer);
        }
    }
}