using System;
using System.Collections.Generic;

namespace ETicaret.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Comments = new List<Comment>();
            this.OrderDetails = new List<OrderDetail>();
            this.ProductPictures = new List<ProductPicture>();
            this.ProductReviews = new List<ProductReview>();
            this.ProductSpesifications = new List<ProductSpesification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public int ProductTypeID { get; set; }
        public int ProductBrandID { get; set; }
        public decimal Price { get; set; }
        public string CoverPicture { get; set; }
        public bool IsContinued { get; set; }
        public int StarPoint { get; set; }
        public int StarGivenMemberCount { get; set; }
        public int UnitsInStock { get; set; }
        public System.DateTime AddedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int Category_Id { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductSpesification> ProductSpesifications { get; set; }
    }
}
