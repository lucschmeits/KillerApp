using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public decimal Percentage { get; set; }
        public string Code { get; set; }
        public string Omschrijving { get; set; }
    }
}