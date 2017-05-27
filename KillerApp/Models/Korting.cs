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

        public static Korting RetrieveKortingById(int id)
        {
            var ksql = new KortingSQL();
            var krepo = new KortingRepo(ksql);
            return krepo.RetrieveKortingById(id);
        }

        public static void DeleteKorting(int id)
        {
            var ksql = new KortingSQL();
            var krepo = new KortingRepo(ksql);
            krepo.DeleteKorting(id);
        }

        public static void UpdateKorting(Korting k)
        {
            var ksql = new KortingSQL();
            var krepo = new KortingRepo(ksql);
            krepo.UpdateKorting(k);
        }

        public static void CreateKorting(Korting k)
        {
            var ksql = new KortingSQL();
            var krepo = new KortingRepo(ksql);
            krepo.CreateKorting(k);
        }

    }
}