using Hours.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T data);
        Task<T> UpdateAsync(T data);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}