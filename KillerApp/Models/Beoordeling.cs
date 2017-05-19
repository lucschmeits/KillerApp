using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models
{
    public class Beoordeling
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public decimal Cijfer { get; set; }

        public Product Product { get; set; }
    }
}