using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace KillerApp.Models
{
    public class Klant : Gebruiker
    {
        public string Straat { get; set; }
        public string HuisNr { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Land { get; set; }
    }
}