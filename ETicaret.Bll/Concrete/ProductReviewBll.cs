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

        public bool Update(ProductReview productReview)
        {
            bool result = _productReviewDal.Update(productReview);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {

            bool result = _productReviewDal.Delete(_productReviewDal.GetOne(x => x.id == id));
            if (result)
            {
                return true;
            }

            return false;

        }

        public bool Add(ProductReview productReview)
        {
            bool result = _productReviewDal.Add(productReview);
            if (result)
            {
                return true;
            }

            return false;
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