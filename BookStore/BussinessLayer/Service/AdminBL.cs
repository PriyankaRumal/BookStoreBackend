using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
     public  class AdminBL:IAdminBL
    {
        IAdminRL adminrl;
        public AdminBL(IAdminRL adminrl)
        {
            this.adminrl = adminrl;
        }

        public string Adminlogin(AdminLogin adminLogin)
        {
            try
            {
                return adminrl.Adminlogin(adminLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
