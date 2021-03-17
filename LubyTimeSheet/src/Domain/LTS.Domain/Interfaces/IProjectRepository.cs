using LTS.Domain.Base;
using LTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<PagedList<Project>> GetProjectsPaginated(PaginationParameters paginationParameters);
        Task<Project> GetProjectWithDevelopersProject(Guid projectId);
        Task RemoveDeveloperFromProject(DeveloperProject developerProject);
    }
}
