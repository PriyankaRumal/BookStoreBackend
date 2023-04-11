using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class OrderBL:IOrderBL
    {
        IOrderRL orderRL;
        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public OrderModel AddOrder(OrderModel orderModel, long UserId)
        {
            try
            {
                return orderRL.AddOrder(orderModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CancelOrder(long UserId, long OrderId)
        {
            try
            {
                return orderRL.CancelOrder(UserId, OrderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<OrderDetails> GetAllOrder()
        {
            try
            {
                return orderRL.GetAllOrder();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetAllOrder> GetAllOrderSec(long UserId)
        {
            try
            {
                return orderRL.GetAllOrderSec(UserId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
