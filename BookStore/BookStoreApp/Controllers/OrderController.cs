using BussinessLayer.Interface;
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
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(OrderModel orderModel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = orderBL.AddOrder(orderModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Order Placed successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Order not Placed" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("CancelOrder")]
        public IActionResult CancelOrder( long OrderId)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = orderBL.CancelOrder(UserId, OrderId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Order Cancelled successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Order not Cancelled please try again!" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAllOrder")]
        public IActionResult GetAllOrder()
        {
            try
            {
                // long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = orderBL.GetAllOrder();

                if (response != null)
                {
                    return Ok(new { success = true, message = "retrived successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed!" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAllOrdersec")]
        public IActionResult GetAllOrderSec()
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = orderBL.GetAllOrderSec(UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "retrived successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Failed!" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
