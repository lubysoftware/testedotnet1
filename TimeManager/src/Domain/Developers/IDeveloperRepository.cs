using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeManager.Domain.Developers
{
    public interface IDeveloperRepository
    {
        Task<List<Developer>> GetAllAsync();
        Task<Developer> GetByIdsAsync(Guid id);
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(Guid id);
    }
}
