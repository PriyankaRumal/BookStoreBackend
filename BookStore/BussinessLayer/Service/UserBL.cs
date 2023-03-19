using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;
        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }

        public bool DeleteUser(long userId)
        {
            try
            {
                return userRl.DeleteUser(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgetPassword(string Email_Id)
        {

            try
            {
                return userRl.ForgetPassword(Email_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string LoginUser(UserLogin userLogin)
        {
            try
            {
                return userRl.LoginUser(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserRegistration RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                return userRl.RegisterUser(userRegistration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPassword(string email, string newpassword, string confirmpass)
        {
            try
            {
                return userRl.ResetPassword(email, newpassword, confirmpass);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
