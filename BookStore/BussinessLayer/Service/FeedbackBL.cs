using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BussinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public bool AddFeedback(FeedBackModel feedbackModel, long UserId)
        {
            try
            {
                return feedbackRL.AddFeedback(feedbackModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetFeedback> getFeedback(long BookId)
        {
            try
            {
                return feedbackRL.getFeedback(BookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetFeedback> getFeedbackbyID(long FeedbackId, long UserId)
        {
            try
            {
                return feedbackRL.getFeedbackbyID(FeedbackId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
