using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Categories1 = new List<Category>();
            this.Products = new List<Product>();
        }

        public int Id { get; set; }
        public Nullable<int> parentId { get; set; }
        public string Name { get; set; }
        public string CategoryPicPath { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public System.DateTime ModifedDate { get; set; }
        public virtual ICollection<Category> Categories1 { get; set; }
        public virtual Category Category1 { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
