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
        bool Update(ProductPicture productPicture);
        bool Delete(int id);
        bool Add(ProductPicture productPicture);
       
    }
}