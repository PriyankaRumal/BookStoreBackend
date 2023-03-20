using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL feedbackBL;
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }
        [Authorize]
        [HttpPost]
        [Route("GiveFeedback")]
        public IActionResult AddFeedback(FeedBackModel feedbackModel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var response = feedbackBL.AddFeedback(feedbackModel, UserId);
                if (response != null)
                {
                    return Ok(new { success = true, Message = "Feedback Added", data = response });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Feedback Not Added", data = response });
                }

            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [Authorize]
        [HttpGet]
        [Route("Getfeedback")]
        public IActionResult getFeedback(long BookId)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = feedbackBL.getFeedback(BookId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = " Get Feedback Successful ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Get Feedback Unsuccessful " });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetfeedbackbyId")]
        public IActionResult getFeedbackbyID(long FeedbackId)
        {
            try
            {
                int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(g => g.Type == "UserId").Value);
                var result = feedbackBL.getFeedbackbyID(FeedbackId, UserId);

                if (result != null)
                {
                    return Ok(new { Success = true, Message = " Get Feedback Successful ", Data = result });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Get Feedback Unsuccessful " });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
