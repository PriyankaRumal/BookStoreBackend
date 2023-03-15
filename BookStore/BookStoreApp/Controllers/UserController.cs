using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBl;
        public UserController(IUserBL userBl)


        {
            this.userBl = userBl;
        }
        [HttpPost]
        [Route("UserRegistration")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = userBl.RegisterUser(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration Unsuccessfull!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult loginuser(UserLogin userLogin)
        {
            try
            {
                var result = userBl.LoginUser(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "login Successfull!", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "login Unsuccessfull!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("forget")]
        public IActionResult forgetpassword(string Email_Id)
        {
            try
            {
                var result = userBl.ForgetPassword(Email_Id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "mail sent successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "error!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("reset")]
        public IActionResult Resetpassword( string newpassword, string confirmpass)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBl.ResetPassword(email, newpassword, confirmpass);
                if (result != null)
                {
                    if (newpassword == confirmpass)
                    {
                        return this.Ok(new { Success = true, message = "Your password has been changed sucessfully" });
                    }
                    else
                    {
                        return this.Ok(new { Success = true, message = "Password dont matched" });
                    }
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "error!" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
