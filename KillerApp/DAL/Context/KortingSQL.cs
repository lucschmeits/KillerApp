using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.DAL.Repo;
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

        public void UpdateKorting(Korting k, List<int> productIds)
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
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM Korting_Product WHERE kortingId = @id";
                cmd.Parameters.AddWithValue("@id", k.Id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                foreach (var productId in productIds)
                {
                    cmd.CommandText = "INSERT INTO Korting_Product (kortingId, productId) VALUES (@kortingId, @productId)";
                    cmd.Parameters.AddWithValue("@kortingId", k.Id);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                // throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public List<Product> RetrieveProductsByKorting(int kortingId)
        {
            var categorieSql = new ProductCategorieSQL();
            var categorieRepo = new ProductCategorieRepo(categorieSql);
            var leverancierSql = new LeverancierSQL();
            var leverancierRepo = new LeverancierRepo(leverancierSql);
            var afbeeldingSql = new AfbeeldingSQL();
            var afbeeldingRepo = new AfbeeldingRepo(afbeeldingSql);
            var beoordelingSql = new BeoordelingSQL();
            var beoordelingRepo = new BeoordelingRepo(beoordelingSql);
            var kortingsql = new KortingSQL();
            var kortingrepo = new KortingRepo(kortingsql);
            var returnList = new List<Product>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Product.*, kortingId FROM Korting INNER JOIN Korting_Product ON Korting.id = Korting_Product.kortingId INNER JOIN Product ON Korting_Product.productId = Product.id WHERE Korting.id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", kortingId);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var product = new Product();
                    product.Id = reader.GetInt32(0);
                    product.Naam = reader.GetString(1);
                    product.Voorraad = reader.GetInt32(2);
                    product.Prijs = reader.GetDecimal(3);
                    product.Categorie = categorieRepo.RetrieveCategorie(reader.GetInt32(4));
                    product.Leverancier = leverancierRepo.RetrieveLeverancier(reader.GetInt32(5));
                    product.Afbeeldingen = afbeeldingRepo.RetrieveAfbeeldingByProduct(reader.GetInt32(0));
                    product.Beoordelingen = beoordelingRepo.BeoordelingByProduct(reader.GetInt32(0));
                    product.Kortingen = kortingrepo.RetrieveKortingByProduct(reader.GetInt32(0));
                   // product.KortingId = reader.GetInt32(7);
                    if (!reader.IsDBNull(6))
                    {
                        product.Omschrijving = reader.GetString(6);
                    }

                    returnList.Add(product);
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