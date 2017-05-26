using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.Controllers;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class KlantSQL : IKlant
    {
        public void CreateKlant(int id, Klant k)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO Klant (id, straat, huisNr, postcode, woonplaats, land) VALUES (@newID, @straat, @huisNr, @postcode, @woonplaats, @land)";
                var command1 = new SqlCommand(query1, con);
                command1.Parameters.AddWithValue("@newID", id);
                command1.Parameters.AddWithValue("@straat", k.Straat);
                command1.Parameters.AddWithValue("@huisNr", k.HuisNr);
                command1.Parameters.AddWithValue("@postcode", k.Postcode);
                command1.Parameters.AddWithValue("@woonplaats", k.Woonplaats);
                command1.Parameters.AddWithValue("@land", k.Land);
                command1.ExecuteScalar();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteKlant(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Klant WHERE id = @id";
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

        public List<Klant> RetrieveAll()
        {
            var returnList = new List<Klant>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Gebruiker INNER JOIN Klant ON Gebruiker.id = Klant.id WHERE Gebruiker.id IN(SELECT id FROM Klant)";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var k = new Klant();
                    k.Id = reader.GetInt32(0);
                    k.Naam = reader.GetString(1);
                    k.Email = reader.GetString(2);
                    k.Wachtwoord = reader.GetString(3);
                    k.Straat = reader.GetString(5);
                    k.HuisNr = reader.GetString(6);
                    k.Postcode = reader.GetString(7);
                    k.Woonplaats = reader.GetString(8);
                    k.Land = reader.GetString(9);

                    returnList.Add(k);
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

        public Klant RetrieveKlant(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Gebruiker g INNER JOIN Klant AS k ON g.id = k.id WHERE g.id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                var k = new Klant();

                while (reader.Read())
                {
                    k.Id = reader.GetInt32(0);
                    k.Naam = reader.GetString(1);
                    k.Email = reader.GetString(2);
                    k.Wachtwoord = reader.GetString(3);
                    k.Straat = reader.GetString(5);
                    k.HuisNr = reader.GetString(6);
                    k.Postcode = reader.GetString(7);
                    k.Woonplaats = reader.GetString(8);
                    k.Land = reader.GetString(9);
                }
                con.Close();
                return k;
            }
            catch (Exception ex)
            {
                //throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex
                throw ex;
            }
        }

        public void UpdateKlant(Klant k)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "UPDATE Gebruiker SET naam = @naam, [e-mail] = @email, wachtwoord = @wachtwoord WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", k.Id);
                cmd.Parameters.AddWithValue("@naam", k.Naam);
                cmd.Parameters.AddWithValue("@email", k.Email);
                cmd.Parameters.AddWithValue("@wachtwoord", k.Wachtwoord);

                cmd.ExecuteNonQuery();
                cmd.CommandText = "UPDATE Klant SET straat = @straat, huisNr = @huisNr, postcode = @postcode, woonplaats = @woonplaats, land = @land WHERE id = @id";
                cmd.Parameters.AddWithValue("@straat", k.Straat);
                cmd.Parameters.AddWithValue("@huisNr", k.HuisNr);
                cmd.Parameters.AddWithValue("@postcode", k.Postcode);
                cmd.Parameters.AddWithValue("@woonplaats", k.Woonplaats);
                cmd.Parameters.AddWithValue("@land", k.Land);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                // throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }
    }
}