using CloudinaryDotNet;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRL:IBookRL
    {
        string connectionstring;
        IConfiguration configuration;

        public BookRL(IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("UserDbConnection");
            this.configuration = configuration;
        }

        public AddBookModel AddBook(AddBookModel addBookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddBook", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Book_Name", addBookModel.Book_Name);
                    sqlCommand.Parameters.AddWithValue("@Author_Name", addBookModel.Author_Name);
                    sqlCommand.Parameters.AddWithValue("@Book_Count", addBookModel.Book_Count);
                    sqlCommand.Parameters.AddWithValue("@Price", addBookModel.Price);
                    sqlCommand.Parameters.AddWithValue("@Discount_Price", addBookModel.Discount_Price);
                    sqlCommand.Parameters.AddWithValue("@Description", addBookModel.Description);
                    sqlCommand.Parameters.AddWithValue("@Rating", addBookModel.Rating);
                    sqlCommand.Parameters.AddWithValue("@Rating_Count", addBookModel.Rating_Count);
                    sqlCommand.Parameters.AddWithValue("@Book_Image", addBookModel.Book_Image);

                    sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        return addBookModel;
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
          public List<AddBookModel> GetAllBook()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    List<AddBookModel> allbook = new List<AddBookModel>();
                    SqlCommand sqlCommand = new SqlCommand("spGetAllBook", sqlConnection);
                    sqlCommand.CommandType=CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlConnection.Open();
                    adapter.Fill(dataTable);
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        allbook.Add(
                            new AddBookModel
                            {
                                BookId=Convert.ToInt32(dataRow["BookId"]),
                                Book_Name = dataRow["Book_Name"].ToString(),
                                Author_Name = dataRow["Author_Name"].ToString(),
                                Book_Count = Convert.ToInt32(dataRow["Book_Count"]),
                                Price = Convert.ToInt32(dataRow["Price"]),
                                Discount_Price = Convert.ToInt32(dataRow["Discount_Price"]),
                                Description = dataRow["Description"].ToString(),
                                Rating = dataRow["Rating"].ToString(),
                                Rating_Count = Convert.ToInt32(dataRow["Rating_Count"]),
                                Book_Image = dataRow["Book_Image"].ToString()
                            }
                            );
                    }
                    return allbook;
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

        public object GetBookById(long BookId)
        {
            SqlConnection sqlConnection=new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetBookById", sqlConnection);
                    sqlCommand.CommandType=CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", BookId);
                    sqlConnection.Open();
                    AddBookModel addBookModel=new AddBookModel();
                    SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            addBookModel.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
                            addBookModel.Book_Name = sqlDataReader["Book_Name"].ToString();
                            addBookModel.Author_Name = sqlDataReader["Author_Name"].ToString();
                            addBookModel.Book_Count = Convert.ToInt32(sqlDataReader["Book_Count"]);
                            addBookModel.Price = Convert.ToInt32(sqlDataReader["Price"]);
                            addBookModel.Discount_Price = Convert.ToInt32(sqlDataReader["Discount_Price"]);
                            addBookModel.Description = sqlDataReader["Description"].ToString();
                            addBookModel.Rating = sqlDataReader["Rating"].ToString();
                            addBookModel.Rating_Count = Convert.ToInt32(sqlDataReader["Rating_Count"]);
                            addBookModel.Book_Image = sqlDataReader["Book_Image"].ToString();
                        }
                        return addBookModel;
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

        public bool DeleteBook(long BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spDeleteBook", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId",BookId);
                    sqlConnection.Open();
                    var result=sqlCommand.ExecuteNonQuery();
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

        public AddBookModel UpdateBook(AddBookModel addBookModel,long BookId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateBook", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", BookId);
                    sqlCommand.Parameters.AddWithValue("@Book_Name", addBookModel.Book_Name);
                    sqlCommand.Parameters.AddWithValue("@Author_Name", addBookModel.Author_Name);
                    sqlCommand.Parameters.AddWithValue("@Book_Count", addBookModel.Book_Count);
                    sqlCommand.Parameters.AddWithValue("@Price", addBookModel.Price);
                    sqlCommand.Parameters.AddWithValue("@Discount_Price", addBookModel.Discount_Price);
                    sqlCommand.Parameters.AddWithValue("@Description", addBookModel.Description);
                    sqlCommand.Parameters.AddWithValue("@Rating", addBookModel.Rating);
                    sqlCommand.Parameters.AddWithValue("@Rating_Count", addBookModel.Rating_Count);
                    sqlCommand.Parameters.AddWithValue("@Book_Image", addBookModel.Book_Image);

                    sqlConnection.Open();
                    var result=sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return addBookModel;
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

        public string ImageUploadOnCloudinary(IFormFile imageFile)
        {
            try
            {
                Account account = new Account(
                        this.configuration["CloudinarySettings:CloudName"],
                       this.configuration["CloudinarySettings:ApiKey"],
                        this.configuration["CloudinarySettings:ApiSecret"]
                        );
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),

                };

                var uploadResult = cloudinary.Upload(uploadParams);
                string imagePath = uploadResult.Url.ToString();
                return imagePath;

            }
            catch (Exception)
            {

                throw;
            }
        }

         public bool UpdateImage(UpdateBookImage updateBookImage)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            using (sqlConnection)
            {
                try
                {
                    string uploadImagePath = ImageUploadOnCloudinary(updateBookImage.ImgFile);

                    SqlCommand sqlCommand = new SqlCommand("spBookImage", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@BookId", updateBookImage.BookId);
                    sqlCommand.Parameters.AddWithValue("@Book_Image", uploadImagePath);
                    sqlConnection.Open();
                    var result=sqlCommand.ExecuteNonQuery();

                    if (result >= 1)
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
        }
  
}
