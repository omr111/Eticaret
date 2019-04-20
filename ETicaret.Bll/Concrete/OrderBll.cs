using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class OrderBll:IOrderBll
    {
        private readonly IOrderDal _orderDal;
        public OrderBll(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> ListThem(Expression<Func<Order, bool>> filter)
        {

            return _orderDal.ListThem(filter);
       
        }

        public Order GetOne(Expression<Func<Order, bool>> filter)
        {
            return _orderDal.GetOne(filter);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }

        public void Delete(Guid id)
        {
            var deleteObject = _orderDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _orderDal.Delete(deleteObject);
            }
            
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }
    }
}