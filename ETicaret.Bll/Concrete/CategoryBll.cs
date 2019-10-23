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

        public bool Update(Category category)
        {
            bool result = _categoryDal.Update(category);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _categoryDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                bool result = _categoryDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Category category)
        {
           bool result= _categoryDal.Add(category);
            if (result)
            {
                return true;
            }

            return false;
        }

        public List<Category> ListAccordingToParentID()
        {
            return _categoryDal.ListThem().ToList();

        }
    }
}