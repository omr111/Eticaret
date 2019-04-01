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
        void Update(Category category);
        void Delete(int id);
        void Add(Category category);
        List<Category> ListAccordingToParentID();
    }
}