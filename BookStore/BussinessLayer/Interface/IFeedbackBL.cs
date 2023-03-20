using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public bool AddFeedback(FeedBackModel feedbackModel, long UserId);
        public IEnumerable<GetFeedback> getFeedback(long BookId);
        public IEnumerable<GetFeedback> getFeedbackbyID(long FeedbackId, long UserId);
    }
}
