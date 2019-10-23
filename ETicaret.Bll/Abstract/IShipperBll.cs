using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IShipperBll
    {
        List<Shipper> ListThem(Expression<Func<Shipper, bool>> filter = null);
        Shipper GetOne(Expression<Func<Shipper, bool>> filter);
        bool Update(Shipper shipper);
        bool Delete(int id);
        bool Add(Shipper shipper);
    }
}