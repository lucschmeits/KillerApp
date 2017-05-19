﻿using System;
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
        public void CreateKorting(Korting k, int productId)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "INSERT INTO Korting (percentage, omschrijving, productId) VALUES (@percentage, @omschrijving, @productId)";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@percentage", k.Percentage);
                command.Parameters.AddWithValue("@omschrijving", k.Omschrijving);
                command.Parameters.AddWithValue("@productId", productId);
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
                var cmdString = "DELETE FROM Korting WHERE id = @id";
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

        public List<Korting> RetrieveKortingByProduct(int id)
        {
            var returnList = new List<Korting>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Korting WHERE productId = @id";
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

        //public void UpdateKorting(Korting k)
        //{
        //    throw new NotImplementedException();
        //}
    }
}