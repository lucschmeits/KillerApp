using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KillerApp.DAL.Context;

namespace KillerApp.Tests
{
    [TestClass]
    public class TestConnection
    {
        private ConSQL _sql = new ConSQL();
        private bool _state;

        [TestMethod]
        public void TestMethod1()
        {
            var con = new SqlConnection(_sql.ConnectionString);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                _state = true;
            }
            if (con.State == ConnectionState.Closed)
            {
                _state = false;
            }
            con.Close();
            Assert.AreEqual(true, _state);
        }
    }
}