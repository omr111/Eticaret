using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface ICityBll
    {
        List<City> ListThem(Expression<Func<City, bool>> filter = null);
        City GetOne(Expression<Func<City, bool>> filter);
        void Update(City city);
        void Delete(int id);
        void Add(City city);
    }
}