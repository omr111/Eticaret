using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class SupplierBll:ISupplierBll
    {
        private ISupplierDal _supplierDal;
        public SupplierBll(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public List<Supplier> ListThem(Expression<Func<Supplier, bool>> filter = null)
        {

            return _supplierDal.ListThem(filter);
       
        }

        public Supplier GetOne(Expression<Func<Supplier, bool>> filter)
        {
            return _supplierDal.GetOne(filter);
        }

        public bool Update(Supplier brand)
        {
            bool result = _supplierDal.Update(brand);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _supplierDal.GetOne(x => x.SupplierID == id);
            if (deleteObject!=null)
            {
                bool result = _supplierDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Supplier supplier)
        {
            bool result = _supplierDal.Add(supplier);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}