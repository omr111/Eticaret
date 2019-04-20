using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Member_Id { get; set; }
        public Nullable<int> ToWhoId { get; set; }
        public int Product_Id { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Member Member1 { get; set; }
        public virtual Product Product { get; set; }
    }
}
