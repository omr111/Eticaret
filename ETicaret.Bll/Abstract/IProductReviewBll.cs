using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IProductReviewBll
    {
        List<ProductReview> ListThem(Expression<Func<ProductReview, bool>> filter = null);
        ProductReview GetOne(Expression<Func<ProductReview, bool>> filter);
        bool Update(ProductReview productReview);
        bool Delete(int id);
        bool Add(ProductReview productReview);
        List<ProductReview> AccordingToStarCount(int star, int proId);
        List<ProductReview> AccordingToProductList(int id);
    }
}