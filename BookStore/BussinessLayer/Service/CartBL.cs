using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class CartBL : ICartBL
    {
        ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public CartModel AddToCart(long UserId, CartModel cartModel)
        {
            try
            {
                return cartRL.AddToCart(UserId, cartModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCart(long CartId)
        {
            try
            {
                return cartRL.DeleteCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CartModel1> GetCartDetails(long UserId)
        {
            try
            {
                return cartRL.GetCartDetails(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCart(long CartId, long Book_Count, long UserId)
        {
            try
            {
                return cartRL.UpdateCart(CartId, Book_Count, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
