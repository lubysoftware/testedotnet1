using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain.Entities;
using test.domain.Interfaces.Repositories;
using test.domain.Interfaces.Services.ProjectService;

namespace test.service.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _projectRepository.DeleteAsync(id);
        }

        public async Task<Project> Get(Guid id)
        {
            return await _projectRepository.SelectAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _projectRepository.SelectAsync();
        }

        public async Task<Project> Post(Project project)
        {
            return await _projectRepository.InsertAsync(project);
        }

        public async Task<Project> Put(Project project)
        {
            return await _projectRepository.UpdateAsync(project);
        }
    }
}
