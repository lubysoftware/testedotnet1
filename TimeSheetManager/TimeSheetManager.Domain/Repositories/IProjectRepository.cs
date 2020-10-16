using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManager.Domain.Entities.Project;

namespace TimeSheetManager.Domain.Repositories {
    public interface IProjectRepository {
        Task Post(Project developer);
        Task<Project> Get(Guid id);
        Task<List<Project>> GetAll();
        Task Update(Project developer);
        Task Delete(Guid id);
    }
}