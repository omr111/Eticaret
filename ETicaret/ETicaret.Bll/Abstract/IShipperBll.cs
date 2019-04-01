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
        void Update(Shipper shipper);
        void Delete(int id);
        void Add(Shipper shipper);
    }
}