using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class RoleBll:IRoleBll
    {
        private readonly IRoleDal _roleDal;
        public RoleBll(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> ListThem(Expression<Func<Role, bool>> filter)
        {

            return _roleDal.ListThem(filter);
       
        }

        public Role GetOne(Expression<Func<Role, bool>> filter)
        {
            return _roleDal.GetOne(filter);
        }

        public bool Update(Role role)
        {
            bool result = _roleDal.Update(role);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _roleDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _roleDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Role role)
        {
            bool result = _roleDal.Add(role);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}