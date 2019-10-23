using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ETicaret.Dal.Abstract
{
    public interface IRepositoryBase<T>where T: class
    {
        List<T> ListThem(Expression<Func<T, bool>> filter = null);
        T GetOne(Expression<Func<T, bool>> filter=null);
        bool Update(T entity);
        bool Delete(T entity);
        bool Add(T entity);
    }
}