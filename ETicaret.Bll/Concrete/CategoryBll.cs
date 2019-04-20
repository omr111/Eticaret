using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class CategoryBll:ICategoryBll
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryBll(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> ListThem(Expression<Func<Category, bool>> filter=null)
        {

            return _categoryDal.ListThem(filter);
       
        }

        public Category GetOne(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.GetOne(filter);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(int id)
        {
            var deleteObject = _categoryDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _categoryDal.Delete(deleteObject);
            }
            
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public List<Category> ListAccordingToParentID()
        {
            return _categoryDal.ListThem().ToList();

        }
    }
}