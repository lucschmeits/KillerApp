using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class BeheerderSQL : IBeheerder
    {
        public void CreateBeheerder(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO Beheerder (id) VALUES (@newID)";
                var command1 = new SqlCommand(query1, con);
                command1.Parameters.AddWithValue("@newID", id);
                command1.ExecuteScalar();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteBeheerder(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Beheerder WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Beheerder> RetrieveAll()
        {
            var returnList = new List<Beheerder>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Gebruiker INNER JOIN Beheerder ON Gebruiker.id = Beheerder.id WHERE Gebruiker.id IN(SELECT id FROM Beheerder)";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var b = new Beheerder();
                    b.Id = reader.GetInt32(0);
                    b.Naam = reader.GetString(1);
                    b.Email = reader.GetString(2);
                    b.Wachtwoord = reader.GetString(3);

                    returnList.Add(b);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
            return returnList;
        }

        public Beheerder RetrieveBeheerder(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Gebruiker g WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                var b = new Beheerder();

                while (reader.Read())
                {
                    b.Id = reader.GetInt32(0);
                    b.Naam = reader.GetString(1);
                    b.Email = reader.GetString(2);
                    b.Wachtwoord = reader.GetString(3);
                }
                con.Close();
                return b;
            }
            catch (Exception ex)
            {
                //throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex
                throw ex;
            }
        }
    }
}