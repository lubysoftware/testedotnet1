using LTS.Domain.Base;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;
using LTS.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LTS.Infra.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(LubyContext contexto) : base(contexto)
        {
        }

        public async Task<PagedList<Project>> GetProjectsPaginated(PaginationParameters paginationParameters)
        {
            return PagedList<Project>.ToPagedList(await GetAll(),
             paginationParameters.PageNumber,
             paginationParameters.PageSize);
        }

        public async Task<Project> GetProjectWithDevelopersProject(Guid projectId) => await _dbSet.Include(x => x.DeveloperProjects)
            .AsNoTracking()
            .SingleAsync(y => y.Id == projectId);

        public async Task RemoveDeveloperFromProject(DeveloperProject developerProject)
        {
            _context.DeveloperProject.Remove(developerProject);
            await SaveChangesAsync();
        }
    }
}
