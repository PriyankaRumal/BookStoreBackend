using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL:IUserRL
    {
        string connectionString;
        private readonly string _secret;
        private readonly string _expDate;

        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;


        }

        public string GenerateSecurityToken(string email, string UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

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
        public string LoginUser(UserLogin userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using(sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spUserLogin", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email_Id", userLogin.Email_Id);
                    sqlCommand.Parameters.AddWithValue("@Password", userLogin.Password);
                    sqlConnection.Open();
                    var result=sqlCommand.ExecuteScalar();

                    if (result != null)
                    {
                        string query = "SELECT UserId FROM UserTable WHERE EmaiL_Id = '" + userLogin.Email_Id + "'";
         
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        var Id = cmd.ExecuteScalar();
                        var token = GenerateSecurityToken(userLogin.Email_Id, Id.ToString());
                        return token;
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
        public string ForgetPassword(string Email_Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("SpForgetPassword", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Email_Id", Email_Id);
                    sqlConnection.Open();
                    SqlDataReader rd = sqlCommand.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            var userId = Convert.ToInt32(rd["UserId"] == DBNull.Value ? default : rd["UserId"]);
                            var token = this.GenerateSecurityToken(Email_Id, userId.ToString());
                            MSMQModel msmq = new MSMQModel();
                            msmq.sendData2Queue(token);
                            return token;
                        }

                    }
                    return null;
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
        public bool ResetPassword(string email,string newpassword,string confirmpass)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    if (newpassword == confirmpass)
                    {
                        SqlCommand sqlCommand = new SqlCommand("SpResetPassword", sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Email_Id", email);
                        sqlCommand.Parameters.AddWithValue("@Password", newpassword);
                        sqlConnection.Open();
                        SqlDataReader rd = sqlCommand.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                email = Convert.ToString(rd["Email_Id"] == DBNull.Value ? default : rd["Email_Id"]);
                                newpassword = Convert.ToString(rd["Password"] == DBNull.Value ? default : rd["Password"]);
                            }
                            return true;
                        }
                        return true;
                    }
                    return false;
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
}
