using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class BeoordelingSQL : IBeoordeling
    {
        public void CreateBeoordeling(Beoordeling b)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO Beoordeling (titel, omschrijving, cijfer, productId) VALUES (@titel, @omschrijving, @cijfer, @productId)";
                var command1 = new SqlCommand(query1, con);

                command1.Parameters.AddWithValue("@titel", b.Titel);
                command1.Parameters.AddWithValue("@omschrijving", b.Omschrijving);
                command1.Parameters.AddWithValue("@cijfer", b.Cijfer);
                command1.Parameters.AddWithValue("@productId", b.Product.Id);

                command1.ExecuteScalar();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteBeoordeling(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Beoordeling WHERE id = @id";
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

        public List<Beoordeling> RetrieveAll()
        {
            var returnList = new List<Beoordeling>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Beoordeling";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var b = new Beoordeling();
                    b.Id = reader.GetInt32(0);
                    b.Titel = reader.GetString(1);
                    b.Omschrijving = reader.GetString(2);
                    b.Cijfer = reader.GetDecimal(3);
                    // b.Product =
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

        public Beoordeling RetrieveBeoordeling(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Beoordeling WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var b = new Beoordeling();
                while (reader.Read())
                {
                    b.Id = reader.GetInt32(0);
                    b.Titel = reader.GetString(1);
                    b.Omschrijving = reader.GetString(2);
                    b.Cijfer = reader.GetDecimal(3);
                    // b.Product =
                }
                con.Close();
                return b;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public void UpdateBeoordeling(Beoordeling b)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "UPDATE Beoordeling SET titel = @titel, omschrijving = @omschrijving, cijfer = @cijfer WHERE id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", b.Id);
                cmd.Parameters.AddWithValue("@titel", b.Titel);
                cmd.Parameters.AddWithValue("@omschrijving", b.Omschrijving);
                cmd.Parameters.AddWithValue("@cijfer", b.Cijfer);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                // throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public List<Beoordeling> BeoordelingByProduct(int id)
        {
            var returnList = new List<Beoordeling>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Beoordeling WHERE productId = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var b = new Beoordeling();
                    b.Id = reader.GetInt32(0);
                    b.Titel = reader.GetString(1);
                    b.Omschrijving = reader.GetString(2);
                    b.Cijfer = reader.GetDecimal(3);
                    // b.Product =
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
    }
}