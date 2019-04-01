using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IProductSpesificationBll
    {
        List<ProductSpesification> ListThem(Expression<Func<ProductSpesification, bool>> filter = null);
        ProductSpesification GetOne(Expression<Func<ProductSpesification, bool>> filter);
        void Update(ProductSpesification category);
        void Delete(int id);
        void Add(ProductSpesification category);
    }
}