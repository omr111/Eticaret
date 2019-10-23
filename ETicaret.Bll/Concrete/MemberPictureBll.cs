using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class MemberPictureBll:IMemberPictureBll
    {
        private IMemberPictureDal _memberPictureDal;
        public MemberPictureBll(IMemberPictureDal memberPictureDal)
        {
            _memberPictureDal = memberPictureDal;
        }

        public List<MemberPicture> ListThem(Expression<Func<MemberPicture, bool>> filter = null)
        {

            return _memberPictureDal.ListThem(filter);
       
        }

        public MemberPicture GetOne(Expression<Func<MemberPicture, bool>> filter)
        {
            return _memberPictureDal.GetOne(filter);
        }

        public bool Update(MemberPicture memberPicture)
        {
            bool result = _memberPictureDal.Update(memberPicture);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deleteObject = _memberPictureDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                bool result = _memberPictureDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(MemberPicture memberPicture)
        {
            bool result = _memberPictureDal.Add(memberPicture);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}