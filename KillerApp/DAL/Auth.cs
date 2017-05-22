using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Context;
using KillerApp.DAL.Repo;
using KillerApp.Models;

namespace KillerApp.DAL
{
    public class Auth
    {
     public static Gebruiker CheckLogin(string email, string wachtwoord)
        {
            try
            {
               var ksql = new KlantSQL();
                var krepo = new KlantRepo(ksql);
                var bsql = new BeheerderSQL();
                var brepo = new BeheerderRepo(bsql);
                foreach (var k in krepo.RetrieveAll())
                {
                    if (k.Email == email && k.Wachtwoord == wachtwoord)
                    {
                        return k;
                    }
                }
                foreach (var b in brepo.RetrieveAll())
                {
                    if (b.Email == email && b.Wachtwoord == wachtwoord)
                    {
                        return b;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}