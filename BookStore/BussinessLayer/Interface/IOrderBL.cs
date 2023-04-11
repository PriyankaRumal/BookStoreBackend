using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IOrderBL
    {
        public OrderModel AddOrder(OrderModel orderModel, long UserId);
        public bool CancelOrder(long UserId, long OrderId);
        public List<OrderDetails> GetAllOrder();
        public IEnumerable<GetAllOrder> GetAllOrderSec(long UserId);
    }
}
