using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KillerApp.DAL.Context
{
    public class ConSQL
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["killerappCon"].ConnectionString;
    }
}