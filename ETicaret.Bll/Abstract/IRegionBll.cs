using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IRegionBll
    {
        List<Region> ListThem(Expression<Func<Region, bool>> filter = null);
        Region GetOne(Expression<Func<Region, bool>> filter);
        bool Update(Region region);
        bool Delete(int id);
        bool Add(Region region);
    }
}