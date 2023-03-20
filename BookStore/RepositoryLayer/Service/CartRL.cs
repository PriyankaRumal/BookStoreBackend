using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;

namespace RepositoryLayer.Service
{
   public class CartRL:ICartRL
    {
        string connectionString;
        public CartRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");
        }
        public CartModel AddToCart(long UserId,CartModel cartModel)
        {
            SqlConnection sqlConnection =new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddToCart", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId",UserId);
                    sqlCommand.Parameters.AddWithValue("@BookId",cartModel.BookId);
                    sqlCommand.Parameters.AddWithValue("@Book_Count", cartModel.Book_Count);
                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
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
        }
        public IEnumerable<CartModel1> GetCartDetails (long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spgetcart", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    sqlConnection.Open();
                    SqlDataReader rd = sqlCommand.ExecuteReader();
                    if (!rd.HasRows)
                    {
                        return null;
                    }
                    List<CartModel1> cartDetails = new List<CartModel1>();
                    while (rd.Read())
                    {
                        CartModel1 cartModel1 = new CartModel1();
                        cartModel1.CartId= Convert.ToInt32(rd["CartId"]);
                        cartModel1.UserId= Convert.ToInt32(rd["UserId"]);
                        cartModel1.BookId= Convert.ToInt32(rd["BookId"]);
                        cartModel1.Book_Count = Convert.ToInt32(rd["Book_Count"]);
                        cartDetails.Add(cartModel1);
                    }
                    return cartDetails;

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

        public IEnumerable<CartModel1> GetCartDetailsbyId(long UserId,long CartId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetAllCartById", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    sqlCommand.Parameters.AddWithValue("@CartId", CartId);
                    sqlConnection.Open();
                    SqlDataReader rd = sqlCommand.ExecuteReader();
                    if (!rd.HasRows)
                    {
                        return null;
                    }
                    List<CartModel1> cartDetails = new List<CartModel1>();
                    while (rd.Read())
                    {
                        CartModel1 cartModel1 = new CartModel1();
                        cartModel1.CartId = Convert.ToInt32(rd["CartId"]);
                        cartModel1.UserId = Convert.ToInt32(rd["UserId"]);
                        cartModel1.BookId = Convert.ToInt32(rd["BookId"]);
                        cartModel1.Book_Count = Convert.ToInt32(rd["Book_Count"]);
                        cartDetails.Add(cartModel1);
                    }
                    return cartDetails;

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
        public bool UpdateCart(long CartId,long Book_Count,long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateCart", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CartId", CartId);
                    sqlCommand.Parameters.AddWithValue("@Book_Count", Book_Count);
                    
                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
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

        public bool DeleteCart(long CartId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spDeleteCart", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CartId", CartId);
                    sqlConnection.Open();
                    var result=sqlCommand.ExecuteNonQuery();
                    if(result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false ;
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
        //public IEnumerable<GetCartModel> RemoveFromCart(long UserId)
        //{
        //    SqlConnection sqlConnection=new SqlConnection(connectionString);
        //    try
        //    {
        //        using (sqlConnection)
        //        {
        //            List<GetCartModel> cart = new List<GetCartModel>();
        //            SqlCommand sqlCommand = new SqlCommand("spGetAllCart", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@UserId", UserId);
        //            sqlConnection.Open();
        //            SqlDataReader rd=sqlCommand.ExecuteReader();
        //            while (rd.Read())
        //            {
        //                cart.Add(new GetCartModel()
        //                {
        //                    CartId= Convert.ToInt32(rd["CartId"]),
        //                    BookId= Convert.ToInt32(rd["BookId"]),
        //                    UserId= Convert.ToInt32(rd["UserId"]),
        //                    Book_Count= (long)rd["Book_Quantity"],
        //                    Book_Name= rd["Book_Name"].ToString(),
        //                    Author_Name = rd["Author_Name"].ToString(),
        //                    Price= Convert.ToInt32(rd["Price"]),
        //                    Discount_Price= Convert.ToInt32(rd["Discount_Price"]),
        //                    Book_Image= rd["Book_Image"].ToString(),

        //                });
        //            }
        //            return cart;

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        if (sqlConnection.State == ConnectionState.Open)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //}
    }
}
