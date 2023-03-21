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
    public class OrderRL:IOrderRL
    {
        string connectionString;
        public OrderRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");
        }
        public OrderModel AddOrder(OrderModel orderModel,long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAdOrder", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    sqlCommand.Parameters.AddWithValue("@AddressId",orderModel.AddressId);
                    sqlCommand.Parameters.AddWithValue("@BookId", orderModel.BookId);
                    sqlCommand.Parameters.AddWithValue("@BookQuantity", orderModel.BookQuantity);

                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return orderModel;
                    }
                    else
                    {
                        return null;
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
        public bool CancelOrder(long UserId,long OrderId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spCancelOrder", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@OrderId", OrderId);

                    int result = cmd.ExecuteNonQuery();
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

        public List<OrderDetails> GetAllOrder()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    List<OrderDetails> orderDetails = new List<OrderDetails>();
                    SqlCommand cmd = new SqlCommand("spGetOrderDetails", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OrderDetails orderDetails1=new OrderDetails();
                        orderDetails1.OrderId = Convert.ToInt32(sqlDataReader["OrderId"]);
                        orderDetails1.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
                        orderDetails1.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                        orderDetails1.AddressId = Convert.ToInt32(sqlDataReader["AddressId"]);
                        orderDetails1.TotalPrice= Convert.ToInt32(sqlDataReader["TotalPrice"]);
                        orderDetails1.BookQuantity= Convert.ToInt32(sqlDataReader["BookQuantity"]);
                        orderDetails1.OrderDate = sqlDataReader["OrderDate"].ToString();

                        orderDetails.Add(orderDetails1);
                    }
                    return orderDetails;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
