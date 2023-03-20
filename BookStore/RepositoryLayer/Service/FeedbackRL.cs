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
    public class FeedbackRL:IFeedbackRL
    {
        string connectionString;
        public FeedbackRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDbConnection");
        }
        public bool AddFeedback(FeedBackModel feedbackModel,long UserId)
        {
            SqlConnection sqlConnection=new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddFeedBack", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Rating", feedbackModel.Rating);
                    cmd.Parameters.AddWithValue("@Comment", feedbackModel.Comment);
                    cmd.Parameters.AddWithValue("@BookId", feedbackModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
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
        public IEnumerable<GetFeedback> getFeedback(long BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //String query = "SELECT FeedbackID, rating, Comment, BookID FROM FeedbackTable WHERE UserID = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand("spGetFeedback", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId ", BookId);
                    SqlDataReader rd = cmd.ExecuteReader();
                    List<GetFeedback> feedback = new List<GetFeedback>();
                    while (rd.Read())
                    {
                        feedback.Add(new GetFeedback()
                        {
                            FeedbackId = (long)rd["FeedbackId"],
                            Rating = rd["Rating"].ToString(),
                            Comment = rd["Comment"].ToString(),
                            BookId = (long)rd["BookId"],
                            UserId = Convert.ToInt32(rd["UserId"]),
                            FullName = rd["FullName"].ToString(),

                        });
                    }
                    return feedback;
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

        public IEnumerable<GetFeedback> getFeedbackbyID(long FeedbackId,long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    //String query = "SELECT FeedbackID, rating, Comment, BookID FROM FeedbackTable WHERE UserID = '" + UserId + "'";
                    SqlCommand cmd = new SqlCommand("spGetFeedbackById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeedbackId ", FeedbackId);
                    SqlDataReader rd = cmd.ExecuteReader();
                    List<GetFeedback> feedback = new List<GetFeedback>();
                    while (rd.Read())
                    {
                        feedback.Add(new GetFeedback()
                        {
                            FeedbackId = (long)rd["FeedbackId"],
                            Rating = rd["Rating"].ToString(),
                            Comment = rd["Comment"].ToString(),
                            BookId = (long)rd["BookId"],
                            UserId = Convert.ToInt32(rd["UserId"]),
                            FullName = rd["FullName"].ToString(),

                        });
                    }
                    return feedback;
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
}
