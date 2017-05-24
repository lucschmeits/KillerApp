using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Categorie HoofdCategorie { get; set; }

        public static List<Categorie> RetrieveAll()
        {
            var sql = new ProductCategorieSQL();
            var repo = new ProductCategorieRepo(sql);

            return repo.RetrieveAll();
        }
    }
}