using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class OrderDetails
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public long AddressId { get; set; }
    
        public long TotalPrice { get; set; }
        public long BookQuantity { get; set; }
        public string OrderDate { get; set; }
    }
}
