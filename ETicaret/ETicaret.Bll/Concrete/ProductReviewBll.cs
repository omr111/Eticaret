using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ProductReviewBll : IProductReviewBll
    {
        private IProductReviewDal _productReviewDal;

        public ProductReviewBll(IProductReviewDal productReviewDal)
        {
            _productReviewDal = productReviewDal;
        }

        public List<ProductReview> ListThem(Expression<Func<ProductReview, bool>> filter = null)
        {
            return _productReviewDal.ListThem();
        }

        public ProductReview GetOne(Expression<Func<ProductReview, bool>> filter)
        {
            return _productReviewDal.GetOne(filter);
        }

        public void Update(ProductReview productReview)
        {
            _productReviewDal.Update(productReview);
        }

        public void Delete(int id)
        {
            
            _productReviewDal.Delete(_productReviewDal.GetOne(x => x.id == id));

        }

        public void Add(ProductReview productReview)
        {
            _productReviewDal.Add(productReview);
        }

        public List<ProductReview> AccordingToStarCount(int star, int proId)
        {
            return _productReviewDal.ListThem(x => x.YildizSayisi == star&&x.productId==proId).ToList();
        }

        public List<ProductReview> AccordingToProductList(int id)
        {
            return _productReviewDal.ListThem(x => x.productId == id).ToList();
        }
    }
}