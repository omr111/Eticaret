using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IOrderDetailBll
    {
        List<OrderDetail> ListThem(Expression<Func<OrderDetail, bool>> filter = null);
        List<OrderDetail> MostOrderList(Expression<Func<OrderDetail, bool>> filter = null);
        OrderDetail GetOne(Expression<Func<OrderDetail, bool>> filter);
        void Update(OrderDetail order);
        void Delete(Guid id);
        void Add(OrderDetail order);

    }
}