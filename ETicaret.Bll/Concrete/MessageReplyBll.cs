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

        public bool Update(MessageReply messageReply)
        {
            bool result = _messageReplyDal.Update(messageReply);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(Guid id)
        {
            var deleteObject = _messageReplyDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                bool result = _messageReplyDal.Delete(deleteObject);
                if (result)
                {
                    return true;
                }

                return false;
            }
            return false;
        }

        public bool Add(MessageReply messageReply)
        {
            bool result = _messageReplyDal.Add(messageReply);
            if (result)
            {
                return true;
            }

            return false;
        }
    }
}