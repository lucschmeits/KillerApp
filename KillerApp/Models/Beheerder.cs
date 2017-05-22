using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;

namespace KillerApp.Models
{
    public class Beheerder : Gebruiker
    {
        public static List<Beheerder> RetrieveAll()
        {
            var bsql = new BeheerderSQL();
            var brepo = new BeheerderRepo(bsql);
            return brepo.RetrieveAll();
        }
    }
}