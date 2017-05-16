using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}