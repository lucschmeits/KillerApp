using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class ProductCategorieSQL : IProductCategorie
    {
        public void CreateCategorie(Categorie c)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query1 = "INSERT INTO ProductCategorie (categorieId, naam, omschrijving) VALUES (@CategorieId, @Naam, @Omschrijving)";
                var command1 = new SqlCommand(query1, con);
                command1.Parameters.AddWithValue("@CategorieId", c.HoofdCategorie.Id);
                command1.Parameters.AddWithValue("@Naam", c.Naam);
                command1.Parameters.AddWithValue("@Omschrijving", c.Omschrijving);

                command1.ExecuteScalar();

                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCategorie(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM ProductCategorie WHERE id = @id";
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

        public List<Categorie> RetrieveAll()
        {
            var returnList = new List<Categorie>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM ProductCategorie";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var c = new Categorie();
                    c.Id = reader.GetInt32(0);
                    // c.SubCategories =
                    c.Naam = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        c.Omschrijving = reader.GetString(3);
                    }
                   
                    returnList.Add(c);
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

        public Categorie RetrieveCategorie(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM ProductCategorie WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var c = new Categorie();
                while (reader.Read())
                {
                    c.Id = reader.GetInt32(0);
                    // c.SubCategories =
                    c.Naam = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        c.Omschrijving = reader.GetString(3);
                    }
                }
                con.Close();
                return c;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public void UpdateCategorie(Categorie c)
        {
            throw new NotImplementedException();
        }
    }
}