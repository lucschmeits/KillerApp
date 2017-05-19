using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class ProductSQL : IProduct
    {
        public void CreateProduct(Product p)
        {
            throw new NotImplementedException();
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
            var productList = new List<Product>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Product";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var p = new Product();
                    p.Id = reader.GetInt32(0);
                    p.Naam = reader.GetString(1);
                    p.Voorraad = reader.GetInt32(2);
                    p.Prijs = reader.GetDecimal(3);
                    //p.Categorie = reader.GetInt32(4);
                    //p.Leverancier = reader.GetInt32(5);
                    //p.Kortingen
                    //p.Afbeeldingen
                    //p.Beoordelingen
                    //p.Omschrijving
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
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Product WHERE id = @id";
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
                    //p.Categorie = reader.GetInt32(4);
                    //p.Leverancier = reader.GetInt32(5);
                    //p.Kortingen
                    //p.Afbeeldingen
                    //p.Beoordelingen
                    //p.Omschrijving
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
            throw new NotImplementedException();
        }

        public List<Product> RetrieveProductByOrder(int id)
        {
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
                    //p.Categorie = reader.GetInt32(4);
                    //p.Leverancier = reader.GetInt32(5);
                    //p.Kortingen
                    //p.Afbeeldingen
                    //p.Beoordelingen
                    //p.Omschrijving
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