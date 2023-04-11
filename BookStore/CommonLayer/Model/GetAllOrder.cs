using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class GetAllOrder
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public long AddressId { get; set; }

        public long TotalPrice { get; set; }
        public long BookQuantity { get; set; }
        public string OrderDate { get; set; }

        public string Book_Name { get; set; }
        public string Author_Name { get; set; }
        public long Price { get; set; }
        public long Discount_Price { get; set; }
        public string Book_Image { get; set; }
    }
}
