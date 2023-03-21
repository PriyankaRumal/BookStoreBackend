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
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }

        [Authorize]
        [HttpPost]
        [Route("AddAddress")]
        public IActionResult AddAddress(AddressModel addressModel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = addressBL.AddAddress(addressModel, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Address added successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address Not Added" });
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
        public IActionResult DeleteAddress(long AddressId)
        {
            try
            {
                var response = addressBL.DeleteAddress(AddressId);
                if (response != null)
                {
                    return Ok(new { success = true, message = "Address Deleted" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address not Deleted" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateAddress(AddressModel addressModel, long AddressId)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = addressBL.UpdateAddress(addressModel, AddressId, UserId);

                if (response != null)
                {
                    return Ok(new { success = true, message = "Address added successfully", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Address Not Added" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("GetAllAddress")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var result = addressBL.GetAllAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Retrieve All Adress", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Try Again!! Something Wrong" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        }
}
