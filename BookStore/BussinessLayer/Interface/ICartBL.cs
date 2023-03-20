using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public  interface ICartBL
    {
        public CartModel AddToCart(long UserId, CartModel cartModel);
        public IEnumerable<CartModel1> GetCartDetails(long UserId);
        public bool UpdateCart(long CartId, long Book_Count, long UserId);
        public bool DeleteCart(long CartId);

        public IEnumerable<CartModel1> GetCartDetailsbyId(long UserId, long CartId);
        //public IEnumerable<GetCartModel> RemoveFromCart(long UserId);
    }
}
