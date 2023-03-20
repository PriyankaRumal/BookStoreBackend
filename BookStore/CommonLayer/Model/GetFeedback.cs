﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class GetFeedback
    {
        public long UserId { get; set; }
        public long FeedbackId { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public long BookId { get; set; }
        public string FullName { get; set; }
    }
}
