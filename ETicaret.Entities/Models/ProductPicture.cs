using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductPicture
    {
        public int id { get; set; }
        public string BigPicture { get; set; }
        public string MediumPicture { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
