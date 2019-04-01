using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class MessageReplyBll:IMessageReplyBll
    {
        private readonly IMessageReplyDal _messageReplyDal;
        public MessageReplyBll(IMessageReplyDal messageReplyDal)
        {
            _messageReplyDal = messageReplyDal;
        }

        public List<MessageReply> ListThem(Expression<Func<MessageReply, bool>> filter)
        {

            return _messageReplyDal.ListThem(filter);
       
        }

        public MessageReply GetOne(Expression<Func<MessageReply, bool>> filter)
        {
            return _messageReplyDal.GetOne(filter);
        }

        public void Update(MessageReply messageReply)
        {
            _messageReplyDal.Update(messageReply);
        }

        public void Delete(Guid id)
        {
            var deleteObject = _messageReplyDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _messageReplyDal.Delete(deleteObject);
            }
            
        }

        public void Add(MessageReply messageReply)
        {
            _messageReplyDal.Add(messageReply);
        }
    }
}