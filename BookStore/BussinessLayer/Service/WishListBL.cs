using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BussinessLayer.Service
{
    public class WishListBL : IWishListBL
    {

		IWishListRL wishRL;
		public WishListBL(IWishListRL wishRL)
		{
				this.wishRL = wishRL;
		}
        public bool AddToWishList(long UserId, long BookId)
        {
			try
			{
				return wishRL.AddToWishList(UserId, BookId);
			}
			catch (Exception)
			{

				throw;
			}
        }

		public bool deleteWishList(long WishListId, long UserId)
		{
            try
            {
                return wishRL.deleteWishList(WishListId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

		public IEnumerable<WishListModel> getWishList(long UserId)
		{
            try
            {
                return wishRL.getWishList(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
	}
}
