using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            this.Products = new List<Product>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
