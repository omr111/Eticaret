using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class MemberBll:IMemberBll
    {
        private IMemberDal _memberDal;
        public MemberBll(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public List<Member> ListThem(Expression<Func<Member, bool>> filter = null)
        {

            return _memberDal.ListThem(filter);
       
        }

        public Member GetOne(Expression<Func<Member, bool>> filter)
        {
            return _memberDal.GetOne(filter);
        }

        public void Update(Member member)
        {
            _memberDal.Update(member);
        }

        public void Delete(int id)
        {
            var deleteObject = _memberDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _memberDal.Delete(deleteObject);
            }
            
        }

        public void Add(Member member)
        {
            _memberDal.Add(member);
        }
    }
}