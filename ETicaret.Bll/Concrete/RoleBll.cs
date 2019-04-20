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

        public void Update(Role role)
        {
            _roleDal.Update(role);
        }

        public void Delete(int id)
        {
            var deleteObject = _roleDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _roleDal.Delete(deleteObject);
            }
            
        }

        public void Add(Role role)
        {
            _roleDal.Add(role);
        }
    }
}