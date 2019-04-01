using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class CityBll:ICityBll
    {
        private ICityDal _cityDal;
        public CityBll(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public List<City> ListThem(Expression<Func<City, bool>> filter = null)
        {

            return _cityDal.ListThem(filter);
       
        }

        public City GetOne(Expression<Func<City, bool>> filter)
        {
            return _cityDal.GetOne(filter);
        }

        public void Update(City city)
        {
            _cityDal.Update(city);
        }

        public void Delete(int id)
        {
            var deleteObject = _cityDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _cityDal.Delete(deleteObject);
            }
            
        }

        public void Add(City city)
        {
            _cityDal.Add(city);
        }
    }
}