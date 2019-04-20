using System;
using System.Collections;
using System.Collections.Generic;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;

namespace ETicaret.Dal.Abstract
{
    public interface IBrandDal:IRepositoryBase<Brand>
    {
        List<ProductBrand> BrandsOfProduct(string brandsOfProduct, decimal? minValue, decimal? maxValue);
    }
}