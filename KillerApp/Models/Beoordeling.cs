using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Beoordeling
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public int Cijfer { get; set; }

        public Product Product { get; set; }

        public static void CreateBeoordeling(Beoordeling b)
        {
            var sql = new BeoordelingSQL();
            var repo = new BeoordelingRepo(sql);

            repo.CreateBeoordeling(b);
        }
    }
}