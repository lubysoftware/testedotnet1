using Business.Interfaces.Repository;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        public ProjectRepository(MyDbContext myDb) : base(myDb)
        {
        }

        public async Task<Project> GetProjectByIdToRemove(Guid id)
        {
            return await Db.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> GetProjectLaunchTime(Guid id)
        {
            return await Db.Projects.AsNoTracking().Include(project => project.LaunchTimes).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
