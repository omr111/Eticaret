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
        void Update(Member member);
        void Delete(int id);
        void Add(Member member);
    }
}