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
    public class AddressRL:IAddressRL
    {
        string connectionString;
        public AddressRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");
        }
        public AddressModel AddAddress(AddressModel addressModel,long UserId)
        {
            SqlConnection sqlConnection=new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddAddress", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Address",addressModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressModel.State);
                    sqlCommand.Parameters.AddWithValue("@TypeId", addressModel.TypeId);
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    if(result != 0)
                    {
                        return addressModel;
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
        }
        public bool DeleteAddress(long AddressId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spDeleteAddress", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@AddressId", AddressId);
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
        public AddressModel UpdateAddress(AddressModel addressModel, long AddressId, long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("SpUpdateAddress", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@AddressId", AddressId);
                    sqlCommand.Parameters.AddWithValue("@Address", addressModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressModel.State);
                   
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return addressModel;
                    }
                    else
                    {
                        return addressModel;
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
        public List<AddressModel> GetAllAddress()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    List<AddressModel> Address = new List<AddressModel>();
                    SqlCommand cmd = new SqlCommand("spGetAllAddress", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AddressModel address = new AddressModel();
                        address.Address = sqlDataReader["Address"].ToString();
                        address.City = sqlDataReader["City"].ToString();
                        address.State = sqlDataReader["State"].ToString();
                        address.TypeId = Convert.ToInt32(sqlDataReader["TypeId"]);

                        Address.Add(address);
                    }
                    return Address;
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
