using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Dal.Concrete.EntityFramework;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class BrandBll:IBrandBll
    {
        private IBrandDal _brandDal;
        public BrandBll(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> ListThem(Expression<Func<Brand,bool>>filter=null)
        {

            return _brandDal.ListThem(filter);
       
        }

        public Brand GetOne(Expression<Func<Brand, bool>> filter)
        {
            return _brandDal.GetOne(filter);
        }

        public List<ProductBrand> BrandsOfProduct(string brandsOfProduct, decimal? minValue, decimal? maxValue)
        {
            return _brandDal.BrandsOfProduct(brandsOfProduct,minValue,maxValue).ToList();
        }

        public bool Update(Brand brand)
        {
            bool result = _brandDal.Update(brand);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _brandDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _brandDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Brand brand)
        {
            bool result = _brandDal.Add(brand);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}