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
        void Update(Message message);
        void Delete(Guid id);
        void Add(Message message);
    }
}