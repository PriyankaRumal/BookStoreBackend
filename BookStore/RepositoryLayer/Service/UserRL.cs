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
    public class UserRL:IUserRL
    {
        string connectionString;

        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");

        }
        public UserRegistration RegisterUser(UserRegistration userRegistration) {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCmd = new SqlCommand("spCreateUser", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FullName", userRegistration.FullName);
                    sqlCmd.Parameters.AddWithValue("@Email_Id", userRegistration.Email_Id);
                    sqlCmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    sqlCmd.Parameters.AddWithValue("@Mobile_Number", userRegistration.Mobile_Number);
                   
                    sqlConnection.Open();

                    int result=sqlCmd.ExecuteNonQuery();
                    if(result >= 1)
                    {
                        return userRegistration;
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
                if (sqlConnection.State== ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
