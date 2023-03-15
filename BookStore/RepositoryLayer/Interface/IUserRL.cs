using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegistration RegisterUser(UserRegistration userRegistration);
        public string LoginUser(UserLogin userLogin);
        public string ForgetPassword(string Email_Id);
        public bool ResetPassword(string email, string newpassword, string confirmpass);
    }
}
