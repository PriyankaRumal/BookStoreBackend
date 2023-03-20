using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IWishListBL
    {
        public bool AddToWishList(long UserId, long BookId);
        public bool deleteWishList(long WishListId, long UserId);
        public IEnumerable<WishListModel> getWishList(long UserId);
    }
}
