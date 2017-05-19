using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class CouponSQL : ICoupon
    {
        public void CreateCoupon(Coupon c)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "INSERT INTO Kortingscoupon (percentage, code, omschrijving) VALUES (@percentage, @code, @omschrijving)";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@percentage", c.Percentage);
                command.Parameters.AddWithValue("@code", c.Code);
                command.Parameters.AddWithValue("@omschrijving", c.Omschrijving);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCoupon(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "DELETE FROM Kortingscoupon WHERE id = @id";
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

        public List<Coupon> RetrieveAll()
        {
            var returnList = new List<Coupon>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Kortingscoupon";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var c = new Coupon();
                    c.Id = reader.GetInt32(0);
                    c.Percentage = reader.GetDecimal(1);
                    c.Code = reader.GetString(2);
                    c.Omschrijving = reader.GetString(3);
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

        public Coupon RetrieveCoupon(int id)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM Kortingscoupon";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var c = new Coupon();
                while (reader.Read())
                {
                    c.Id = reader.GetInt32(0);
                    c.Percentage = reader.GetDecimal(1);
                    c.Code = reader.GetString(2);
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

        public void UpdateCoupon(Coupon c)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var query = "UPDATE Kortingscoupon SET percentage = @percentage, code = @code, omschrijving = @omschrijving WHERE id = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", c.Id);
                cmd.Parameters.AddWithValue("@percentage", c.Percentage);
                cmd.Parameters.AddWithValue("@code", c.Code);
                cmd.Parameters.AddWithValue("@omschrijving", c.Omschrijving);
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