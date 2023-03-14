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


    }
}
