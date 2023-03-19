using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart(CartModel cartModel)
        {
            try
            {
                var currentUser = HttpContext.User;
                long UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = cartBL.AddToCart(UserId,cartModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Added to cart", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "not added" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("RetriveFromCart")]
        public IActionResult GetCartDetails()
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = cartBL.GetCartDetails(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "retrived Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "failed!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateCart")]
        public IActionResult UpdateCart(long CartId, long Book_Count)
        {
            try
            {
                var currentUser = HttpContext.User;
                int UserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                var result = cartBL.UpdateCart(CartId, Book_Count, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "updated Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "failed!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public ActionResult DeleteCart(long CartId)
        {
            try
            {
                var response = cartBL.DeleteCart(CartId);

                if (response != null)
                {
                    return this.Ok(new { success = true, message = "Delete Successfull", data = response });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Delete Unsuccessfull", data = response });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

