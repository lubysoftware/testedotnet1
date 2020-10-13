namespace Luby.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Model;
    using Luby.Data.Context;
    using Microsoft.EntityFrameworkCore;

    public abstract class Repository<T> : IRepository<T>
        where T : Entity, new()
    {
        protected readonly LubyContext _context;
        protected readonly DbSet<T> _dbSet;
        protected Repository(LubyContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await _dbSet.AsNoTracking().ToListAsync();

        public virtual async Task<T> GetbyId(int id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);

            await SaveChange();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);

            await SaveChange();

            return entity;
        }

        public async Task<IEnumerable<T>> Seach(Expression<Func<T, bool>> precidate)
            => await _dbSet.AsNoTracking().Where(precidate).ToListAsync();

        public async Task Delete(int id)
        {
            _dbSet.Remove(new T { Id = id });
            await SaveChange();
        }

        public async Task<int> SaveChange()
            => await _context.SaveChangesAsync();
        

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}