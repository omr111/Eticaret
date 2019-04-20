using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class OrderDetailBll:IOrderDetailBll
    {
        private readonly IOrderDetailDal _orderDetail;
        public OrderDetailBll(IOrderDetailDal orderDetail)
        {
            _orderDetail = orderDetail;
        }


        public List<OrderDetail> ListThem(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return _orderDetail.ListThem();
        }

        public OrderDetail GetOne(Expression<Func<OrderDetail, bool>> filter)
        {
            return _orderDetail.GetOne(filter);
        }

        public void Update(OrderDetail order)
        {
            _orderDetail.Update(order);
        }

        public void Delete(Guid id)
        {
            var sil=_orderDetail.GetOne(x => x.Id == id);
            _orderDetail.Delete(sil);
        }

        public void Add(OrderDetail orderDetail)
        {
            _orderDetail.Add(orderDetail);
        }


        public List<OrderDetail> MostOrderList(Expression<Func<OrderDetail, bool>> filter = null)
        {
            List<OrderDetail> orderedProducts=_orderDetail.ListThem().GroupBy(x => x.Product_Id).OrderByDescending(x => x.Count()).Select(x => x.FirstOrDefault()).ToList();

            return orderedProducts;
        }
    }
}