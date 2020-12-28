using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TesteLuby.Data.Context;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;

namespace TesteLuby.Repository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContextData _dbContextData;

        public BaseRepository(DbContextData dbContextData)
        {
            _dbContextData = dbContextData;
        }

        public bool Delete(T entity)
        {
            _dbContextData.Set<T>().Remove(entity);
            return _dbContextData.SaveChanges() > 0;
        }

        public IList<T> FindByQuery(Expression<Func<T, bool>> expression)
        {
            return _dbContextData.Set<T>().Where(expression).ToList();
        }

        public virtual T Get(int id)
        {
            return _dbContextData.Set<T>().Find(id);
        }

        public virtual bool Insert(T entity)
        {
            _dbContextData.Set<T>().Add(entity);
            return _dbContextData.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            _dbContextData.Entry<T>(entity).State = EntityState.Modified;
            return _dbContextData.SaveChanges() > 0;
        }
    }
}
