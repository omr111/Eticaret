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

        public void Update(MemberPicture memberPicture)
        {
            _memberPictureDal.Update(memberPicture);
        }

        public void Delete(int id)
        {
            var deleteObject = _memberPictureDal.GetOne(x => x.id == id);
            if (deleteObject!=null)
            {
                _memberPictureDal.Delete(deleteObject);
            }
            
        }

        public void Add(MemberPicture memberPicture)
        {
            _memberPictureDal.Add(memberPicture);
        }
    }
}