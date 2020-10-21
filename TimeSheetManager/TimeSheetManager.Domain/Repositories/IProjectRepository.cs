using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManager.Domain.Entities.Project;

namespace TimeSheetManager.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task Post(Project Project);
        Task<Project> Get(Guid id);
        Task<List<Project>> GetAll();
        Task Update(Project Project);
        Task Delete(Guid id);
    }
}