using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface ISupplierBll
    {
        List<Supplier> ListThem(Expression<Func<Supplier, bool>> filter = null);
        Supplier GetOne(Expression<Func<Supplier, bool>> filter);
        bool Update(Supplier supplier);
        bool Delete(int id);
        bool Add(Supplier supplier);
    }
}