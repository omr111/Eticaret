using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IProductBll
    {
        List<Product> ListThem(Expression<Func<Product, bool>> filter=null);
        Product GetOne(Expression<Func<Product, bool>> filter);
        bool Update(Product product);
        bool Delete(int id);
        bool Add(Product product);
        List<Product> ListAccordingToCategory(int? id);

        List<Product> FilterProduct(string id);
        List<Product> PriceFilter(string search,decimal down,decimal up);
        bool AddProductBool(Product product);
    }
}