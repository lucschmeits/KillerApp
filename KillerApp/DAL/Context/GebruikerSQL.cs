﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class GebruikerSQL : IGebruiker
    {
        public int CreateGebruiker(Gebruiker g)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "INSERT INTO Gebruiker (naam, [e-mail], wachtwoord) VALUES(@naam, @email, @wachtwoord);SELECT CAST(scope_identity() AS int)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@naam", g.Naam);
                cmd.Parameters.AddWithValue("@email", g.Email);
                cmd.Parameters.AddWithValue("@wachtwoord", g.Wachtwoord);

                var id = (int)cmd.ExecuteScalar();
                con.Close();
                return id;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        public void UpdateGebruiker(Gebruiker g)
        {
        }
    }
}