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


        public static string GetTotaalProduct(decimal prijs, int aantal)
        {
            decimal totaal = 0;
            totaal = prijs * aantal;
            return totaal.ToString("C");
        }

        public static decimal GetTotaalProductDecimal(decimal prijs, int aantal)
        {
            decimal totaal = 0;
            totaal = prijs * aantal;
            return totaal;
        }

        public static string GetTotaalWinkelwagen(List<Bestelling> prijsList)
        {
            decimal totaal = 0;

          
            foreach (var bestel in prijsList)
            {
                if (bestel.Product.Kortingen.Count > 0)
                {
                    var x = bestel.Product.NewPrijs(bestel.Product);
                    totaal = totaal + x;
                }
                else
                {
                    totaal = totaal + bestel.Product.Prijs;
                }

            }
            return totaal.ToString("C");
        }
    }
}