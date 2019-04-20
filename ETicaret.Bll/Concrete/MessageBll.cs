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

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        public void Delete(Guid id)
        {
            var deleteObject = _messageDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _messageDal.Delete(deleteObject);
            }
            
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }
    }
}