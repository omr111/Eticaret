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

        public void Update(ProductPicture productPicture)
        {
            _productPictureDal.Update(productPicture);
        }

        public void Delete(int id)
        {
            var deleteObject = _productPictureDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _productPictureDal.Delete(deleteObject);
            }
            
        }

        public void Add(ProductPicture productPicture)
        {
            _productPictureDal.Add(productPicture);
        }
    }
}