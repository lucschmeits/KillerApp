using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public int Voorraad { get; set; }
        public decimal Prijs { get; set; }
        public List<Beoordeling> Beoordelingen { get; set; }
        public List<Afbeelding> Afbeeldingen { get; set; }
        public Categorie Categorie { get; set; }
        public Leverancier Leverancier { get; set; }
        public List<Korting> Kortingen { get; set; }

        public decimal GemiddeldeBeoordeling { get; set; }

        public static List<Product> All()
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);

            return repo.RetrieveAll();
        }

        public static Product ProductById(int id)
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);

            return repo.RetrieveProduct(id);
        }

        public static void CreateProduct(Product p)
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);
            repo.CreateProduct(p);
        }

        public static void UpdateProduct(Product p)
        {
            var sql = new ProductSQL();
            var repo = new ProductRepo(sql);
            repo.UpdateProduct(p);
        }
        public decimal GemiddeldeScore(Product product)
        {
            if (product.Beoordelingen.Count == 0)
            {
                return 0;
            }
            if(product.Beoordelingen.Count > 0)
            {
                decimal totaal = 0;
                foreach (var b in product.Beoordelingen)
                {
                    totaal = b.Cijfer + totaal;
                }
                totaal = totaal / product.Beoordelingen.Count;
                return totaal;
            }
            return 0;
        }
    }
}