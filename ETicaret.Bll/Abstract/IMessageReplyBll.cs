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
        bool Update(MessageReply messageReply);
        bool Delete(Guid id);
        bool Add(MessageReply messageReply);
    }
}