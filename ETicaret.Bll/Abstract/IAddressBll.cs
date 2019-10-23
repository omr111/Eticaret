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
        bool Update(Address address);
        bool Delete(Guid id);
        bool Add(Address address);
    }
}