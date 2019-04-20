using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IAddressBll
    {
        List<Address> ListThem(Expression<Func<Address, bool>> filter=null);
        Address GetOne(Expression<Func<Address, bool>> filter);
        void Update(Address address);
        void Delete(Guid id);
        void Add(Address address);
    }
}