using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class UserRegistration
    {
        public string FullName { get; set; }
        public string Email_Id { get; set; }
        public string Password { get; set; }
        public string Mobile_Number { get; set; }

    }
}
