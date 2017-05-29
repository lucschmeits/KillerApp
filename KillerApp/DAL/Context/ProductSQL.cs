using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.DAL.Repo;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class ProductSQL : IProduct
    {
        public void CreateProduct(Product p)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO Product (naam, voorraad, prijs, categorieId, leveranciersId, omschrijving) VALUES (@naam, @voorraad, @prijs, @categorieId, @leveranciersId, @omschrijving)";
                var command1 = new SqlCommand(query1, con);

                command1.Parameters.AddWithValue("@naam", p.Naam);
                command1.Parameters.AddWithValue("@voorraad", p.Voorraad);
                command1.Parameters.AddWithValue("@prijs", p.Prijs);
                command1.Parameters.AddWithValue("@categorieId", p.Categorie.Id);
                command1.Parameters.AddWithValue("@leveranciersId", p.Leverancier.Id);
                command1.Parameters.AddWithValue("@omschrijving", p.Omschrijving);

                command1.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Product WHERE id = @id";
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

        public List<Product> RetrieveAll()
        {
            var categorieSql = new ProductCategorieSQL();
            var categorieRepo = new ProductCategorieRepo(categorieSql);
            var leverancierSql = new LeverancierSQL();
            var leverancierRepo = new LeverancierRepo(leverancierSql);
            var kortingSql = new KortingSQL();
            var kortingRepo = new KortingRepo(kortingSql);
            var afbeeldingSql = new AfbeeldingSQL();
            var afbeeldingRepo = new AfbeeldingRepo(afbeeldingSql);
            var beoordelingSql = new BeoordelingSQL();
            var beoordelingRepo = new BeoordelingRepo(beoordelingSql);
            var productList = new List<Product>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Product.* FROM Product";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Naam = reader.GetString(1);
                    p.Voorraad = reader.GetInt32(2);
                    p.Prijs = reader.GetDecimal(3);
                    p.Categorie = categorieRepo.RetrieveCategorie(reader.GetInt32(4));
                    p.Leverancier = leverancierRepo.RetrieveLeverancier(reader.GetInt32(5));
                    p.Kortingen = kortingRepo.RetrieveKortingByProduct(reader.GetInt32(0));
                    p.Afbeeldingen = afbeeldingRepo.RetrieveAfbeeldingByProduct(reader.GetInt32(0));
                    p.Beoordelingen = beoordelingRepo.BeoordelingByProduct(reader.GetInt32(0));
                    //if (!reader.IsDBNull(7))
                    //{
                    //    p.KortingId = reader.GetInt32(7);
                    //}
                   
                    if (!reader.IsDBNull(6))
                    {
                        p.Omschrijving = reader.GetString(6);
                    }
                    productList.Add(p);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
            return productList;
        }

        public Product RetrieveProduct(int id)
        {
            var categorieSql = new ProductCategorieSQL();
            var categorieRepo = new ProductCategorieRepo(categorieSql);
            var leverancierSql = new LeverancierSQL();
            var leverancierRepo = new LeverancierRepo(leverancierSql);
            var kortingSql = new KortingSQL();
            var kortingRepo = new KortingRepo(kortingSql);
            var afbeeldingSql = new AfbeeldingSQL();
            var afbeeldingRepo = new AfbeeldingRepo(afbeeldingSql);
            var beoordelingSql = new BeoordelingSQL();
            var beoordelingRepo = new BeoordelingRepo(beoordelingSql);
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Product.* FROM Product WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                var p = new Product();

                while (reader.Read())
                {
                    p.Id = reader.GetInt32(0);
                    p.Naam = reader.GetString(1);
                    p.Voorraad = reader.GetInt32(2);
                    p.Prijs = reader.GetDecimal(3);
                    p.Categorie = categorieRepo.RetrieveCategorie(reader.GetInt32(4));
                    p.Leverancier = leverancierRepo.RetrieveLeverancier(reader.GetInt32(5));
                    p.Kortingen = kortingRepo.RetrieveKortingByProduct(reader.GetInt32(0));
                    p.Afbeeldingen = afbeeldingRepo.RetrieveAfbeeldingByProduct(reader.GetInt32(0));
                    p.Beoordelingen = beoordelingRepo.BeoordelingByProduct(reader.GetInt32(0));
                    //if (!reader.IsDBNull(7))
                    //{
                    //    p.KortingId = reader.GetInt32(7);
                    //}
                  
                    if (!reader.IsDBNull(6))
                    {
                        p.Omschrijving = reader.GetString(6);
                    }
                }
                con.Close();
                return p;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "UPDATE Product SET naam = @naam, prijs = @prijs, categorieId = @categorieId, leveranciersId = @leveranciersId, omschrijving = @omschrijving WHERE id = @id";
                var command1 = new SqlCommand(query1, con);
                command1.Parameters.AddWithValue("@id", p.Id);
                command1.Parameters.AddWithValue("@naam", p.Naam);
                command1.Parameters.AddWithValue("@prijs", p.Prijs);
                command1.Parameters.AddWithValue("@categorieId", p.Categorie.Id);
                command1.Parameters.AddWithValue("@leveranciersId", p.Leverancier.Id);
                command1.Parameters.AddWithValue("@omschrijving", p.Omschrijving);

                command1.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> RetrieveProductByOrder(int id)
        {
            var categorieSql = new ProductCategorieSQL();
            var categorieRepo = new ProductCategorieRepo(categorieSql);
            var leverancierSql = new LeverancierSQL();
            var leverancierRepo = new LeverancierRepo(leverancierSql);
            var kortingSql = new KortingSQL();
            var kortingRepo = new KortingRepo(kortingSql);
            var afbeeldingSql = new AfbeeldingSQL();
            var afbeeldingRepo = new AfbeeldingRepo(afbeeldingSql);
            var beoordelingSql = new BeoordelingSQL();
            var beoordelingRepo = new BeoordelingRepo(beoordelingSql);
            var productList = new List<Product>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Product.*, Order_Product.aantal FROM [Order] INNER JOIN Order_Product ON [Order].id = Order_Product.orderId INNER JOIN Product ON Order_Product.productId = Product.id WHERE[Order].id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Naam = reader.GetString(1);
                    p.Voorraad = reader.GetInt32(2);
                    p.Prijs = reader.GetDecimal(3);
                    p.Categorie = categorieRepo.RetrieveCategorie(reader.GetInt32(4));
                    p.Leverancier = leverancierRepo.RetrieveLeverancier(reader.GetInt32(5));
                    p.Kortingen = kortingRepo.RetrieveKortingByProduct(reader.GetInt32(0));
                    p.Afbeeldingen = afbeeldingRepo.RetrieveAfbeeldingByProduct(reader.GetInt32(0));
                    p.Beoordelingen = beoordelingRepo.BeoordelingByProduct(reader.GetInt32(0));
                    if (!reader.IsDBNull(6))
                    {
                        p.Omschrijving = reader.GetString(6);
                    }
                    p.Aantal = reader.GetInt32(7);
                    productList.Add(p);
                }
                con.Close();
                return productList;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public void UpdateKortingProduct(List<Korting> kortingList, int productId)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "DELETE FROM Korting_Product WHERE productId = @productId";
                var command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                foreach (var korting in kortingList)
                {
                    command.CommandText = "INSERT INTO Korting_Product (kortingId, productId) VALUES (@kortingId, @productId)";
                    command.Parameters.AddWithValue("@kortingId", korting.Id);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                   
                }
                

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> RetrieveProductByCategorie(int categorieId)
        {
            var categorieSql = new ProductCategorieSQL();
            var categorieRepo = new ProductCategorieRepo(categorieSql);
            var leverancierSql = new LeverancierSQL();
            var leverancierRepo = new LeverancierRepo(leverancierSql);
            var kortingSql = new KortingSQL();
            var kortingRepo = new KortingRepo(kortingSql);
            var afbeeldingSql = new AfbeeldingSQL();
            var afbeeldingRepo = new AfbeeldingRepo(afbeeldingSql);
            var beoordelingSql = new BeoordelingSQL();
            var beoordelingRepo = new BeoordelingRepo(beoordelingSql);
            var productList = new List<Product>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Product.* FROM Product INNER JOIN ProductCategorie ON Product.categorieId = ProductCategorie.id WHERE ProductCategorie.id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", categorieId);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Naam = reader.GetString(1);
                    p.Voorraad = reader.GetInt32(2);
                    p.Prijs = reader.GetDecimal(3);
                    p.Categorie = categorieRepo.RetrieveCategorie(reader.GetInt32(4));
                    p.Leverancier = leverancierRepo.RetrieveLeverancier(reader.GetInt32(5));
                    p.Kortingen = kortingRepo.RetrieveKortingByProduct(reader.GetInt32(0));
                    p.Afbeeldingen = afbeeldingRepo.RetrieveAfbeeldingByProduct(reader.GetInt32(0));
                    p.Beoordelingen = beoordelingRepo.BeoordelingByProduct(reader.GetInt32(0));
                    //if (!reader.IsDBNull(7))
                    //{
                    //    p.KortingId = reader.GetInt32(7);
                    //}

                    if (!reader.IsDBNull(6))
                    {
                        p.Omschrijving = reader.GetString(6);
                    }
                    productList.Add(p);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
            return productList;
        }
    }
}