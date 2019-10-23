using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ProductSpesificationBll : IProductSpesificationBll
    {
        private IProductSpesificationDal _productSpesificationDal;

        public ProductSpesificationBll(IProductSpesificationDal productSpesificationDal)
        {
            _productSpesificationDal = productSpesificationDal;
        }

        public List<ProductSpesification> ListThem(Expression<Func<ProductSpesification, bool>> filter = null)
        {
            return _productSpesificationDal.ListThem();
        }

        public ProductSpesification GetOne(Expression<Func<ProductSpesification, bool>> filter)
        {
            return _productSpesificationDal.GetOne(filter);
        }

        public bool Update(ProductSpesification productSpesification)
        {
            bool result = _productSpesificationDal.Update(productSpesification);
            if (result)
            {
                return true;
            }

            return false;

        }

        public bool Delete(int id)
        {

            var delete=_productSpesificationDal.GetOne(x => x.ProductId == id);
            bool result = _productSpesificationDal.Delete(delete);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Add(ProductSpesification productSpesification)
        {
            bool result = _productSpesificationDal.Add(productSpesification);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}