using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class WishListRL:IWishListRL
    {
        string connectionString;
        public WishListRL(IConfiguration configuration)
        {
            this.connectionString=configuration.GetConnectionString("UserDbConnection");
        }

        public bool AddToWishList(long UserId,long BookId)
        {
            SqlConnection sqlConnection=new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddToWishList", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    sqlCommand.Parameters.AddWithValue("@BookId", BookId);
                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        public bool deleteWishList(long WishListId, long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteWishlist", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@UserId ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<WishListModel> getWishList(long UserId)
        {
             SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
                try
                {
                    sqlConnection.Open();
                    List<WishListModel> wishlist = new List<WishListModel>();
                    SqlCommand cmd = new SqlCommand("spGetWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId ", UserId);
                     SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            BookId = Convert.ToInt32(sqlDataReader["BookId"]),
                            UserId = Convert.ToInt32(sqlDataReader["UserId"]),
                            Book_Image = sqlDataReader["Book_Image"].ToString(),
                            Author_Name = sqlDataReader["Author_Name"].ToString(),
                            Price = Convert.ToInt32(sqlDataReader["Price"]),
                            Discount_Price = Convert.ToInt32(sqlDataReader["Discount_Price"]),
                            Book_Name = sqlDataReader["Book_Name"].ToString(),

                        });
                    }
                    return wishlist;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }
        }
    }
}
