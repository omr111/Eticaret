using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IMessageReplyBll
    {
        List<MessageReply> ListThem(Expression<Func<MessageReply, bool>> filter=null);
        MessageReply GetOne(Expression<Func<MessageReply, bool>> filter);
        void Update(MessageReply messageReply);
        void Delete(Guid id);
        void Add(MessageReply messageReply);
    }
}