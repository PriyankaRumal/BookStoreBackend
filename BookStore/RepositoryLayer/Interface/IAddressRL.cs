using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel AddAddress(AddressModel addressModel, long UserId);
        public bool DeleteAddress(long AddressId);
        public AddressModel UpdateAddress(AddressModel addressModel, long AddressId, long UserId);
        public List<AddressModel> GetAllAddress();
    }
}
