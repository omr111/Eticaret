using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Abstract
{
    public interface ICommentBll
    {
        List<Comment> ListThem(Expression<Func<Comment, bool>> filter=null);
        Comment GetOne(Expression<Func<Comment, bool>> filter);
        bool Update(Comment comment);
        bool Delete(int id);
        bool Add(Comment comment);
        List<Comment> GetCommentAccordingToProductId(int id);
        List<Comment> ListAccordingToProductId(int id );
    }
}