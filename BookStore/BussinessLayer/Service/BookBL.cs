using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BussinessLayer.Service
{
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public AddBookModel AddBook(AddBookModel addBookModel)
        {

            try
            {
                return bookRL.AddBook(addBookModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteBook(long BookId)
        {
            try
            {
                return bookRL.DeleteBook(BookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddBookModel> GetAllBook()
        {
            try
            {
                return bookRL.GetAllBook();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object GetBookById(long BookId)
        {
            try
            {
                return bookRL.GetBookById(BookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddBookModel UpdateBook(AddBookModel addBookModel, long BookId)
        {
            try
            {
                return bookRL.UpdateBook(addBookModel, BookId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdateImage(UpdateBookImage updateBookImage)
        {
            try
            {
                return bookRL.UpdateImage(updateBookImage);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
