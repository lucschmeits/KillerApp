using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class KortingSQL : IKorting
    {
        public void CreateKorting(Korting k)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "INSERT INTO Korting (percentage, omschrijving) VALUES (@percentage, @omschrijving)";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@percentage", k.Percentage);
                command.Parameters.AddWithValue("@omschrijving", k.Omschrijving);
               // command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteKorting(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Korting_Product WHERE kortingId = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Korting WHERE id = @id";
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Korting> RetrieveAll()
        {
            var returnList = new List<Korting>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Korting";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var k = new Korting();
                    k.Id = reader.GetInt32(0);
                    k.Percentage = reader.GetDecimal(1);
                    if (!reader.IsDBNull(2))
                    {
                        k.Omschrijving = reader.GetString(2);
                    }
                  
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

        public Korting RetrieveKortingById(int id)
        {
           
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Korting WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var k = new Korting();
                while (reader.Read())
                {
                   
                    k.Id = reader.GetInt32(0);
                    k.Percentage = reader.GetDecimal(1);
                    if (!reader.IsDBNull(2))
                    {
                        k.Omschrijving = reader.GetString(2);
                    }

                   
                }
                con.Close();
                return k;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
          
        }

        public List<Korting> RetrieveKortingByProduct(int id)
        {
            var returnList = new List<Korting>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Korting.* FROM Korting INNER JOIN Korting_Product ON Korting.id = Korting_Product.kortingId WHERE Korting_Product.productId = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var k = new Korting();
                    k.Id = reader.GetInt32(0);
                    k.Percentage = reader.GetDecimal(1);
                    k.Omschrijving = reader.GetString(2);
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

        public void UpdateKorting(Korting k)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "UPDATE Korting SET percentage = @percentage, omschrijving = @omschrijving WHERE id = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", k.Id);
                cmd.Parameters.AddWithValue("@percentage", k.Percentage);
                cmd.Parameters.AddWithValue("@omschrijving", k.Omschrijving);
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