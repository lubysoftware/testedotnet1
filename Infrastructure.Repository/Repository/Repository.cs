using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private DatabaseContext Context;
        protected Repository()
        {
            Context = new DatabaseContext(new DbContextOptions<DatabaseContext>());
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {            
            Context.Remove(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }    

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T Search(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
