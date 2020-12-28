using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Get(int id);
        IList<T> FindByQuery(Expression<Func<T, bool>> expression);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
