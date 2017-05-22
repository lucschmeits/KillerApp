using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.DAL.Repo;
using KillerApp.Models;

namespace KillerApp.DAL.Context
{
    public class OrderSQL : IOrder
    {
        public void CreateOrder(Order o, Shoppingcart cart)
        {
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();

                DataTable tvp = new DataTable();
                // define / populate DataTable from your List here
                tvp.Columns.Add("ProductId", typeof(int));
                tvp.Columns.Add("Aantal", typeof(int));

                foreach (var s in cart.Bestellingen)
                {
                    tvp.Rows.Add(s.ProductId, s.Aantal);
                }

                SqlCommand cmd = new SqlCommand("dbo.OrdersProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
                tvparam.SqlDbType = SqlDbType.Structured;
                SqlParameter klantp = cmd.Parameters.AddWithValue("@klantId", o.Klant.Id);
                SqlParameter coupon = cmd.Parameters.AddWithValue("@couponId", o.Coupon.Id);
                // execute query, consume results, etc. here
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }

        public List<Order> RetrieveAll()
        {
            var couponSql = new CouponSQL();
            var couponRepo = new CouponRepo(couponSql);
            var klantSql = new KlantSQL();
            var klantRepo = new KlantRepo(klantSql);
            var productSql = new ProductSQL();
            var productRepo = new ProductRepo(productSql);

            var returnList = new List<Order>();
            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM [Order]";
                var command = new SqlCommand(cmdString, con);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var o = new Order();
                    o.Id = reader.GetInt32(0);
                    o.Datum = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2))
                    {
                        o.Coupon = couponRepo.RetrieveCoupon(reader.GetInt32(2));
                    }
                   
                    o.Klant = klantRepo.RetrieveKlant(reader.GetInt32(3));
                    o.Producten = productRepo.RetrieveProductByOrder(reader.GetInt32(0));
                    returnList.Add(o);
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

        public Order RetrieveOrder(int id)
        {
            var couponSql = new CouponSQL();
            var couponRepo = new CouponRepo(couponSql);
            var klantSql = new KlantSQL();
            var klantRepo = new KlantRepo(klantSql);
            var productSql = new ProductSQL();
            var productRepo = new ProductRepo(productSql);

            try
            {
                var con = new SqlConnection(ConSQL.ConnectionString);
                con.Open();
                var cmdString = "SELECT * FROM [Order] WHERE id = @id";
                var command = new SqlCommand(cmdString, con);
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var o = new Order();
                while (reader.Read())
                {
                    o.Id = reader.GetInt32(0);
                    o.Datum = reader.GetDateTime(1);
                    if (!reader.IsDBNull(2))
                    {
                        o.Coupon = couponRepo.RetrieveCoupon(reader.GetInt32(2));
                    }
                    o.Klant = klantRepo.RetrieveKlant(reader.GetInt32(3));
                    o.Producten = productRepo.RetrieveProductByOrder(reader.GetInt32(0));
                }
                con.Close();
                return o;
            }
            catch (Exception ex)
            {
                //  throw new DatabaseException("Er ging iets mis bij het ophalen van de gegevens", ex);
                throw ex;
            }
        }
    }
}