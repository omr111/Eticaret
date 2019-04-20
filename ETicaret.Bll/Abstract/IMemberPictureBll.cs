using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IMemberPictureBll
    {
        List<MemberPicture> ListThem(Expression<Func<MemberPicture, bool>> filter = null);
        MemberPicture GetOne(Expression<Func<MemberPicture, bool>> filter);
        void Update(MemberPicture memberPicture);
        void Delete(int id);
        void Add(MemberPicture memberPicture);
    }
}