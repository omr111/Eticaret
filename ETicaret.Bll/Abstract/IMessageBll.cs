using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface IMessageBll
    {
        List<Message> ListThem(Expression<Func<Message, bool>> filter=null);
        Message GetOne(Expression<Func<Message, bool>> filter);
        bool Update(Message message);
        bool Delete(Guid id);
        bool Add(Message message);
    }
}