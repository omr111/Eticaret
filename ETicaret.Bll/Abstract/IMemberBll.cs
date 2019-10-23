using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IMemberBll
    {
        List<Member> ListThem(Expression<Func<Member, bool>> filter=null);
        Member GetOne(Expression<Func<Member, bool>> filter);
        bool Update(Member member);
        bool Delete(int id);
        bool Add(Member member);
    }
}