using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class AddressBll:IAddressBll
    {
        private IAddressDal _addressDal;
        public AddressBll(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public List<Address> ListThem(Expression<Func<Address,bool>>filter=null)
        {
        
                return _addressDal.ListThem(filter);
       
        }

        public Address GetOne(Expression<Func<Address, bool>> filter)
        {
            return _addressDal.GetOne(filter);
        }

        public void Update(Address address)
        {
            _addressDal.Update(address);
        }

        public void Delete(Guid id)
        {
            var deleteObject = _addressDal.GetOne(x=>x.Id==id);
            if (deleteObject!=null)
            {
                _addressDal.Delete(deleteObject);
            }
            
        }

        public void Add(Address address)
        {
            _addressDal.Add(address);
        }
    }
}