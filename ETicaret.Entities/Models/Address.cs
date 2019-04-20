using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Address
    {
        public System.Guid Id { get; set; }
        public string AdresDescription { get; set; }
        public int Member_Id { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Member Member { get; set; }
    }
}
