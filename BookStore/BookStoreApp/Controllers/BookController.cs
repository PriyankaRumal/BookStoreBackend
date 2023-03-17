using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("BookAdd")]
        public IActionResult AddBook(AddBookModel addBookModel)
        {
            try
            {
                var result = bookBL.AddBook(addBookModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book Added Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book not Added!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBook")]
        public IActionResult GetAllBook()
        {
            try
            {
                var result=bookBL.GetAllBook();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book retrived Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book not retrived!" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetBookByID")]
        public IActionResult GetBookById(long BookId)
        {
            try
            {
                var result = bookBL.GetBookById(BookId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Book retrived Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Book not retrived!" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(long BookId)
        {
            var result = bookBL.DeleteBook(BookId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Book deleted Successfull!", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Book deletion failed" });
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(AddBookModel addBookModel, long BookId)
        {
            var result = bookBL.UpdateBook(addBookModel, BookId);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Book Update Successfull!", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Updation failed" });
            }
        }


        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("BookImage")]
        public IActionResult UpdateImage( [FromForm]UpdateBookImage updateBookImage)
        {
            var result = bookBL.UpdateImage(updateBookImage);
            if (result != null)
            {
                return this.Ok(new { success = true, message = "Image Update Successfull!", data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Updation failed" });
            }
        }
    }
}
