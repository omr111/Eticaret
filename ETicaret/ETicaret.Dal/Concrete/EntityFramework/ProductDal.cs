using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Dal.Concrete.EntityFramework
{
    public class ProductDal:RepositoryBase<Product>,IProductDal
    {
        public bool AddProductBool(Product product)
        {
            UdemyETicaretDBContext ctx=new UdemyETicaretDBContext();

            EntityState result = ctx.Entry(product).State = EntityState.Added;
            if (result != 0)
                return true;
            else
                return false;
        }
    }
}