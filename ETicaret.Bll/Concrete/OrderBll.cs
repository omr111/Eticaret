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

        public bool Update(Order order)
        {
            bool result = _orderDal.Update(order);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(Guid id)
        {
            var deleteObject = _orderDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                bool result = _orderDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Order order)
        {
            bool result = _orderDal.Add(order);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}