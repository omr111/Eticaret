using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IRoleBll
    {
        List<Role> ListThem(Expression<Func<Role, bool>> filter);
        Role GetOne(Expression<Func<Role, bool>> filter);
        bool Update(Role role);
        bool Delete(int id);
        bool Add(Role role);
    }
}