using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class CartModel
    {
        public long BookId { get; set; }
        public long Book_Count { get; set; }
    }
    public class CartModel1
    {
        public long CartId { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public long Book_Count { get; set; }

      //  public AddBookModel Book { get; set; } 


    }
}
