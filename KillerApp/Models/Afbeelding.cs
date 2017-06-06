using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Afbeelding
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Path { get; set; }


        public static int CreateAfbeelding(Afbeelding a)
        {
            var sql = new AfbeeldingSQL();
            var repo = new AfbeeldingRepo(sql);
            return repo.CreateAfbeelding(a);
        }

        public static void KoppelAfbeeldingProduct(int afbeeldingId, int productId)
        {
            var sql = new AfbeeldingSQL();
            var repo = new AfbeeldingRepo(sql);
            repo.KoppelAfbeeldingProduct(afbeeldingId, productId);
        }
    }
}