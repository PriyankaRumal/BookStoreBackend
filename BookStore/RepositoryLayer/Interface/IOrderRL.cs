using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel AddOrder(OrderModel orderModel,long UserId);
        public bool CancelOrder(long UserId, long OrderId);
        public List<OrderDetails> GetAllOrder();
    }
}
