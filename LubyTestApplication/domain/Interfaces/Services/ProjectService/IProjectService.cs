using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain.Entities;

namespace test.domain.Interfaces.Services.ProjectService
{
    public interface IProjectService
    {
        Task<Project> Get(Guid id);
        Task<IEnumerable<Project>> GetAll();
        Task<Project> Post(Project project);
        Task<Project> Put(Project project);
        Task<bool> Delete(Guid id);
    }
}
