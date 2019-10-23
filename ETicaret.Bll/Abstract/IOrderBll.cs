using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IOrderBll
    {
        List<Order> ListThem(Expression<Func<Order, bool>> filter=null);
        Order GetOne(Expression<Func<Order, bool>> filter);
        bool Update(Order orderDetail);
        bool Delete(Guid id);
        bool Add(Order orderDetail);
      
    }
}