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

        public void Update(Supplier brand)
        {
            _supplierDal.Update(brand);
        }

        public void Delete(int id)
        {
            var deleteObject = _supplierDal.GetOne(x => x.SupplierID == id);
            if (deleteObject!=null)
            {
                _supplierDal.Delete(deleteObject);
            }
            
        }

        public void Add(Supplier supplier)
        {
            _supplierDal.Add(supplier);
        }
    }
}