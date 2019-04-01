using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IProductTypeBll
    {
        List<ProductType> ListThem(Expression<Func<ProductType, bool>> filter);
        ProductType GetOne(Expression<Func<ProductType, bool>> filter);
        void Update(ProductType productType);
        void Delete(int id);
        void Add(ProductType productType);
    }
}