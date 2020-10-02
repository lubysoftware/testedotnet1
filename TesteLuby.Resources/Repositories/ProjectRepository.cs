using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Context;
using TesteLuby.Resources.Contracts;

namespace Testeluby.ResourcesDB.Repositories
{
    public class ProjectRepository : DapperRepository<Project>, IRepository
    {
        public ProjectRepository(IAppSettings appSettings) : base(appSettings)
        {
        }
    }
}
