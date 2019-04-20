using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ProductTypeBll:IProductTypeBll
    {
        private readonly IProductTypeDal _productTypeDal;
        public ProductTypeBll(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }

        public List<ProductType> ListThem(Expression<Func<ProductType, bool>> filter = null)
        {

            return _productTypeDal.ListThem(filter);
       
        }

        public ProductType GetOne(Expression<Func<ProductType, bool>> filter)
        {
            return _productTypeDal.GetOne(filter);
        }

        public void Update(ProductType productType)
        {
            _productTypeDal.Update(productType);
        }

        public void Delete(int id)
        {
            var deleteObject = _productTypeDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _productTypeDal.Delete(deleteObject);
            }
            
        }

        public void Add(ProductType productType)
        {
            _productTypeDal.Add(productType);
        }
    }
}