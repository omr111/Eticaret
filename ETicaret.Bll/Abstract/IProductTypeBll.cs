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
        bool Update(ProductType productType);
        bool Delete(int id);
        bool Add(ProductType productType);
    }
}