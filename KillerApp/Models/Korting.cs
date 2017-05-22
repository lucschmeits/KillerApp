using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Korting
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public string Omschrijving { get; set; }


        public static List<Korting> RetrieveAll()
        {
            var ksql = new KortingSQL();
            var krepo = new KortingRepo(ksql);
            return krepo.RetrieveAll();
        }
    }
}