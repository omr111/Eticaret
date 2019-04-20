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
        void Update(Order orderDetail);
        void Delete(Guid id);
        void Add(Order orderDetail);
      
    }
}