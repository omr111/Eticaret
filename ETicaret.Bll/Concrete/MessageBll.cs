using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class MessageBll:IMessageBll
    {
        private readonly IMessageDal _messageDal;
        public MessageBll(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> ListThem(Expression<Func<Message, bool>> filter)
        {

            return _messageDal.ListThem(filter);
       
        }

        public Message GetOne(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetOne(filter);

        }

        public bool Update(Message message)
        {
            bool result = _messageDal.Update(message);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(Guid id)
        {
            var deleteObject = _messageDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                bool result = _messageDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(Message message)
        {
           bool result= _messageDal.Add(message);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}