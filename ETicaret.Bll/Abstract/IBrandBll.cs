using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IBrandBll
    {
        List<Brand> ListThem(Expression<Func<Brand, bool>> filter=null);
        Brand GetOne(Expression<Func<Brand, bool>> filter);
        List<ProductBrand> BrandsOfProduct(string brandsOfProduct, decimal? minValue, decimal? maxValue);
        bool Update(Brand brand);
        bool Delete(int id);
        bool Add(Brand brand);
    }
}