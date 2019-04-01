using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ETicaret.Dal.Abstract;
using ETicaret.Entities.Models;

namespace ETicaret.Dal.Concrete.EntityFramework
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T: class
    {
        UdemyETicaretDBContext ctx=new UdemyETicaretDBContext();
        public List<T> ListThem(Expression<System.Func<T, bool>> filter = null)
        {
            if (filter==null)
            {
                List<T> objects = ctx.Set<T>().ToList();
                return objects;
            }

            return ctx.Set<T>().Where(filter).ToList();
        }

        public T GetOne(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            
            return ctx.Set<T>().FirstOrDefault(filter);
        }

        public void Update(T entity)
        {
            
            ctx.Entry(entity).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            ctx.SaveChanges(); 
        }

        public void Add(T entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            ctx.SaveChanges();
        }
    }
}