using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class LeverancierSQL : ILeverancier
    {
        public void CreateLeverancier(Leverancier l)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO Leverancier (leveranciersNr, naam, land, plaats, straat, huisNr, postcode, telefoonNr) VALUES (@LeveranciersNr, @Naam, @Land, @Plaats, @Straat, @HuisNr, @Postcode, @TelefoonNr)";
                var command1 = new SqlCommand(query1, con);

                command1.Parameters.AddWithValue("@LeveranciersNr", l.LeveranciersNr);
                command1.Parameters.AddWithValue("@Naam", l.Naam);
                command1.Parameters.AddWithValue("@Land", l.Land);
                command1.Parameters.AddWithValue("@Plaats", l.Plaats);
                command1.Parameters.AddWithValue("@Straat", l.Straat);
                command1.Parameters.AddWithValue("@HuisNr", l.HuisNr);
                command1.Parameters.AddWithValue("@Postcode", l.Postcode);
                command1.Parameters.AddWithValue("@TelefoonNr", l.TelefoonNr);

                command1.ExecuteScalar();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLeverancier(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Leverancier WHERE id = @id";
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

        public List<Leverancier> RetrieveAll()
        {
            var returnList = new List<Leverancier>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Leverancier";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var l = new Leverancier();
                    l.Id = reader.GetInt32(0);
                    l.LeveranciersNr = reader.GetInt32(1);
                    l.Naam = reader.GetString(2);
                    l.Land = reader.GetString(3);
                    l.Plaats = reader.GetString(4);
                    l.Straat = reader.GetString(5);
                    l.HuisNr = reader.GetString(6);
                    l.Postcode = reader.GetString(7);
                    l.TelefoonNr = reader.GetString(8);
                    returnList.Add(l);
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

        public Leverancier RetrieveLeverancier(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Leverancier WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var l = new Leverancier();
                while (reader.Read())
                {
                    l.Id = reader.GetInt32(0);
                    l.LeveranciersNr = reader.GetInt32(1);
                    l.Naam = reader.GetString(2);
                    l.Land = reader.GetString(3);
                    l.Plaats = reader.GetString(4);
                    l.Straat = reader.GetString(5);
                    l.HuisNr = reader.GetString(6);
                    l.Postcode = reader.GetString(7);
                    l.TelefoonNr = reader.GetString(8);
                }
                con.Close();
                return l;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public void UpdateLeverancier(Leverancier l)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "UPDATE Leverancier SET leveranciersNr = @LeveranciersNr, naam = @Naam, land = @Land, plaats = @Plaats, straat = @Straat, huisNr = @HuisNr, postcode = @Postcode, telefoonNr = @TelefoonNr WHERE id = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", l.Id);
                cmd.Parameters.AddWithValue("@LeveranciersNr", l.LeveranciersNr);
                cmd.Parameters.AddWithValue("@Naam", l.Naam);
                cmd.Parameters.AddWithValue("@Land", l.Land);
                cmd.Parameters.AddWithValue("@Plaats", l.Plaats);
                cmd.Parameters.AddWithValue("@Straat", l.Straat);
                cmd.Parameters.AddWithValue("@HuisNr", l.HuisNr);
                cmd.Parameters.AddWithValue("@Postcode", l.Postcode);
                cmd.Parameters.AddWithValue("@TelefoonNr", l.TelefoonNr);
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