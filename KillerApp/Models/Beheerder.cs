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

        public static Beheerder RetrieveBeheerder(int id)
        {
            var bsql = new BeheerderSQL();
            var brepo = new BeheerderRepo(bsql);
            return brepo.RetrieveBeheerder(id);
        }

        public static void UpdateGebruiker(Gebruiker g)
        {
            var gsql = new GebruikerSQL();
            var grepo = new GebruikerRepo(gsql);
            grepo.UpdateGebruiker(g);
        }

        public static void DeleteBeheerder(int id)
        {
            var bsql = new BeheerderSQL();
            var brepo = new BeheerderRepo(bsql);
            brepo.DeleteBeheerder(id);
        }

        public static void CreateBeheerder(int id)
        {
            var bsql = new BeheerderSQL();
            var brepo = new BeheerderRepo(bsql);
            brepo.CreateBeheerder(id);
        }
    }
}