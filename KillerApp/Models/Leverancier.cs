using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Leverancier
    {
        public int Id { get; set; }
        public int LeveranciersNr { get; set; }
        public string Naam { get; set; }
        public string Land { get; set; }
        public string Plaats { get; set; }
        public string Straat { get; set; }
        public string HuisNr { get; set; }
        public string Postcode { get; set; }
        public string TelefoonNr { get; set; }

        public static List<Leverancier> RetrieveAll()
        {
            var lsql = new LeverancierSQL();
            var lrepo = new LeverancierRepo(lsql);
            return lrepo.RetrieveAll();
        }
    }
}