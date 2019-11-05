using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ProductPictureBll:IProductPictureBll
    {
        private IProductPictureDal _productPictureDal;
        public ProductPictureBll(IProductPictureDal productPictureDal)
        {
            _productPictureDal = productPictureDal;
        }

        public List<ProductPicture> ListThem(Expression<Func<ProductPicture, bool>> filter = null)
        {

            return _productPictureDal.ListThem(filter);
       
        }

        public ProductPicture GetOne(Expression<Func<ProductPicture, bool>> filter)
        {
            return _productPictureDal.GetOne(filter);
        }

        public bool Update(ProductPicture productPicture)
        {
            bool result = _productPictureDal.Update(productPicture);
            if (result)
            {
                return true;
            }

            return false;
        }

        

        public bool Delete(int id)
        {
            var deleteObject = _productPictureDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _productPictureDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(ProductPicture productPicture)
        {
            bool result = _productPictureDal.Add(productPicture);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}