using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class RegionBll:IRegionBll
    {
        private IRegionDal _regionDal;
        public RegionBll(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        public List<Region> ListThem(Expression<Func<Region, bool>> filter = null)
        {

            return _regionDal.ListThem(filter);
       
        }

        public Region GetOne(Expression<Func<Region, bool>> filter)
        {
            return _regionDal.GetOne(filter);
        }

        public bool Update(Region region)
        {
            bool result = _regionDal.Update(region);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _regionDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _regionDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Region region)
        {
            bool result = _regionDal.Add(region);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}