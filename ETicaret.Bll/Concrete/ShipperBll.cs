using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class ShipperBll:IShipperBll
    {
        private IShipperDal _shipperDal;
        public ShipperBll(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }

        public List<Shipper> ListThem(Expression<Func<Shipper, bool>> filter = null)
        {

            return _shipperDal.ListThem(filter);
       
        }

        public Shipper GetOne(Expression<Func<Shipper, bool>> filter)
        {
            return _shipperDal.GetOne(filter);
        }

        public bool Update(Shipper shipper)
        {
            bool result = _shipperDal.Update(shipper);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _shipperDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _shipperDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Shipper shipper)
        {
            bool result = _shipperDal.Add(shipper);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}