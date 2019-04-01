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
        void Update(Region region);
        void Delete(int id);
        void Add(Region region);
    }
}