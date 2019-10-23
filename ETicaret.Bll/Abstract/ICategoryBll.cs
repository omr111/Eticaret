using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface ICategoryBll
    {
        List<Category> ListThem(Expression<Func<Category, bool>> filter=null);
        Category GetOne(Expression<Func<Category, bool>> filter);
        bool Update(Category category);
        bool Delete(int id);
        bool Add(Category category);
        List<Category> ListAccordingToParentID();
    }
}