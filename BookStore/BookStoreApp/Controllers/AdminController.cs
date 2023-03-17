using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBL adminbl;
        public AdminController(IAdminBL adminbl)
        {
            this.adminbl = adminbl;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Adminlogin(AdminLogin adminLogin)
        {
            try
            {
                var result = adminbl.Adminlogin(adminLogin);
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
    }
}
