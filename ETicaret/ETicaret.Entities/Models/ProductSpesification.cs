using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductSpesification
    {
        public int id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string SpeCaption { get; set; }
        public string SpeDescription { get; set; }
        public virtual Product Product { get; set; }
    }
}
