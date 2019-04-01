using ETicaret.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Web;


namespace ETicaret.MVCUI.Models
{
    public class ProductAndReviews
    {
        public Product Product { get; set; }
        public List<ProductReview> ProductReviews { get; set; }
        public List<Comment> Comments { get; set; } 
    }
}