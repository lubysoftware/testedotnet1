using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeManager.Domain.Projects
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdsAsync(Guid id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid id);
    }
}
