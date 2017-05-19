using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models
{
    public class Shoppingcart
    {
        public List<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();
        public int KlantId { get; set; }
    }
}