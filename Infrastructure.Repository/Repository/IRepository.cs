using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Search(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        //void Delete(Func<T, bool> predicate);
        void Delete(T entity);
        void Commit();
        void Dispose();
    }
}
