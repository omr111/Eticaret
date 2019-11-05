using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductPicture
    {
        public int id { get; set; }
        public int ProductID { get; set; }
        public string PicPath { get; set; }
        public virtual Product Product { get; set; }
    }
}
