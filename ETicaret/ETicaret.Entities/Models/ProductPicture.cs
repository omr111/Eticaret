using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductPicture
    {
        public int id { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string PicturePath { get; set; }
        public virtual Product Product { get; set; }
    }
}
