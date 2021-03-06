﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class AfbeeldingSQL : IAfbeelding
    {
        public int CreateAfbeelding(Afbeelding a)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "INSERT INTO Afbeelding (path, naam) VALUES (@path, @foto);SELECT CAST(scope_identity() AS int)";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@path", a.Path);
                command.Parameters.AddWithValue("@foto", "foto");


                var id = (int)command.ExecuteScalar();
                con.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void KoppelAfbeeldingProduct(int afbeeldingId, int productId)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "INSERT INTO Product_Afbeelding (afbeeldingId, productId) VALUES (@afbeelding, @product)";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@afbeelding", afbeeldingId);
                command.Parameters.AddWithValue("@product", productId);
                command.ExecuteNonQuery();
               
                con.Close();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAfbeelding(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Afbeelding WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Product_Afbeelding WHERE afbeeldingId = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Afbeelding> RetrieveAfbeeldingByProduct(int id)
        {
            var returnList = new List<Afbeelding>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Afbeelding.* FROM Afbeelding INNER JOIN Product_Afbeelding ON Afbeelding.id = Product_Afbeelding.afbeeldingId WHERE Product_Afbeelding.productId = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var a = new Afbeelding();
                    a.Id = reader.GetInt32(0);
                    a.Path = reader.GetString(1);
                    a.Naam = reader.GetString(2);
                    returnList.Add(a);
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

        public List<Afbeelding> RetrieveAll()
        {
            var returnList = new List<Afbeelding>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT Afbeelding.* FROM Afbeelding";
                var command = new SqlCommand(cmdString, con);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var a = new Afbeelding();
                    a.Id = reader.GetInt32(0);
                    a.Path = reader.GetString(1);
                    a.Naam = reader.GetString(2);
                    returnList.Add(a);
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