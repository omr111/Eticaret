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

        public void Update(Region region)
        {
            _regionDal.Update(region);
        }

        public void Delete(int id)
        {
            var deleteObject = _regionDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _regionDal.Delete(deleteObject);
            }
            
        }

        public void Add(Region region)
        {
            _regionDal.Add(region);
        }
    }
}