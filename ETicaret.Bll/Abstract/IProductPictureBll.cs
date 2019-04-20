using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IProductPictureBll
    {
        List<ProductPicture> ListThem(Expression<Func<ProductPicture, bool>> filter = null);
        ProductPicture GetOne(Expression<Func<ProductPicture, bool>> filter);
        void Update(ProductPicture productPicture);
        void Delete(int id);
        void Add(ProductPicture productPicture);
    }
}