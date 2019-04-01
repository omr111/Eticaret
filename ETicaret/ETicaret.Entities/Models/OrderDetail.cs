using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class OrderDetail
    {
        public System.Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public byte Discount { get; set; }
        public System.Guid Order_Id { get; set; }
        public int Product_Id { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
