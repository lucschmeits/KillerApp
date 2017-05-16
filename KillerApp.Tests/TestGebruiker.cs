using System;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using KillerApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KillerApp.Tests
{
    [TestClass]
    public class TestGebruiker
    {
        [TestMethod]
        public void TestCreateBeheerder()
        {
            var i = 0;
            var sql = new GebruikerSQL();
            var repo = new GebruikerRepo(sql);
            var g = new Gebruiker
            {
                Naam = "Admin",
                Wachtwoord = "Test1234",
                Email = "Admin@killerproducts.nl"
            };
            i = repo.CreateGebruiker(g);
            var bsql = new BeheerderSQL();
            var brepo = new BeheerderRepo(bsql);
            brepo.CreateBeheerder(i);
            Assert.AreEqual(421, i);
        }

        [TestMethod]
        public void TestCreateKlant()
        {
            var i = 0;
            var sql = new GebruikerSQL();
            var repo = new GebruikerRepo(sql);
            var g = new Gebruiker
            {
                Naam = "Klant",
                Wachtwoord = "Test1234",
                Email = "Klant@killerproducts.nl"
            };
            i = repo.CreateGebruiker(g);
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            var k = new Klant
            {
                Straat = "teststraat",
                HuisNr = "42A",
                Postcode = "8574EE",
                Woonplaats = "Eindhoven",
                Land = "Nederland"
            };
            krepo.CreateKlant(i, k);

            Assert.AreEqual(422, i);
        }
    }
}