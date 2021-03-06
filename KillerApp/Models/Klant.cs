﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Klant : Gebruiker
    {
        public string Straat { get; set; }
        public string HuisNr { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Land { get; set; }

        public static void CreateKlant(int id, Klant k)
        {
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            krepo.CreateKlant(id, k);
        }

        public static List<Klant> RetrieveAll()
        {
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            return krepo.RetrieveAll();
        }

        public static Klant RetrieveKlant(int id)
        {
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            return krepo.RetrieveKlant(id);
        }

        public static void DeleteKlant(int id)
        {
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            krepo.DeleteKlant(id);
        }

        public static void UpdateKlant(Klant k)
        {
            var ksql = new KlantSQL();
            var krepo = new KlantRepo(ksql);
            krepo.UpdateKlant(k);
        }
    }
}