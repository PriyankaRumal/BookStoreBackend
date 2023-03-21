using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class AddressBL:IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public AddressModel AddAddress(AddressModel addressModel, long UserId)
        {
            try
            {
                return addressRL.AddAddress(addressModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAddress(long AddressId)
        {
            try
            {
                return addressRL.DeleteAddress(AddressId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressModel> GetAllAddress()
        {
            try
            {
                return addressRL.GetAllAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressModel UpdateAddress(AddressModel addressModel, long AddressId, long UserId)
        {
            try
            {
                return addressRL.UpdateAddress(addressModel, AddressId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
