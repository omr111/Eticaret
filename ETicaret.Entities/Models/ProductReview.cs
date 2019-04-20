using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductReview
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int productId { get; set; }
        public int YildizSayisi { get; set; }
        public string text { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Product Product { get; set; }
    }
}
