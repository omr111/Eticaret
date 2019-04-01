using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ETicaret.Bll.Abstract;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Bll.Concrete
{
    public class CommentBll:ICommentBll
    {
        private readonly ICommentDal _commentDal;
        public CommentBll(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> ListThem(Expression<Func<Comment, bool>> filter=null)
        {

            return _commentDal.ListThem(filter);
       
        }
        public List<Comment> GetCommentAccordingToProductId(int id)
        {
            return _commentDal.ListThem(x => x.Product_Id == id);
        }

        public List<Comment> ListAccordingToProductId(int id)
        {
            return _commentDal.ListThem(x => x.Product_Id == id).ToList();
        }

        public Comment GetOne(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.GetOne(filter);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public void Delete(int id)
        {
            var deleteObject = _commentDal.GetOne(x => x.Id == id);
            if (deleteObject!=null)
            {
                _commentDal.Delete(deleteObject);
            }
            
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }


       
    }
}