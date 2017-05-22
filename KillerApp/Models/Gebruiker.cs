using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

        public Gebruiker()
        {
        }

        public static int CreateGebruiker(Gebruiker g)
        {
            var gsql = new GebruikerSQL();
            var grepo = new GebruikerRepo(gsql);
            return grepo.CreateGebruiker(g);
        }
    }
}