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
        bool Update(MemberPicture memberPicture);
        bool Delete(int id);
        bool Add(MemberPicture memberPicture);
    }
}