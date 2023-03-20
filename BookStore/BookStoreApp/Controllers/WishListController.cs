using BussinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishListBL wishListBL;
        public WishListController(IWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public IActionResult AddToWishList( long BookId)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = wishListBL.AddToWishList(BookId, UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Add Book successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Add Book unsuccessful" });

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public IActionResult deleteWishList(long WishListId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

                var result = wishListBL.deleteWishList(WishListId, userId);

                if (result != false)
                {
                    return Ok(new { success = true, message = "WishList Deleted" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "WishList Not Deleted" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("GetWishList")]
        public IActionResult GetWishList()
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = wishListBL.getWishList(UserId);
                if (result != null)
                {
                    return Ok(new { Success = true, Message = "Wishlist Retrieved", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Retrieve Unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
