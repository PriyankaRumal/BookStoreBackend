using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public bool AddFeedback(FeedBackModel feedbackModel, long UserId);
        public IEnumerable<GetFeedback> getFeedback(long BookId);
        public IEnumerable<GetFeedback> getFeedbackbyID(long FeedbackId, long UserId);
    }
}
