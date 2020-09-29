using LTS.Domain.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();

    }
}

