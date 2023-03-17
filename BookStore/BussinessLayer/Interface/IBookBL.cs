using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IBookBL
    {
        public AddBookModel AddBook(AddBookModel addBookModel);
        public List<AddBookModel> GetAllBook();
        public object GetBookById(long BookId);
        public bool DeleteBook(long BookId);
        public AddBookModel UpdateBook(AddBookModel addBookModel, long BookId);

        public bool UpdateImage(UpdateBookImage updateBookImage);
    }
}
