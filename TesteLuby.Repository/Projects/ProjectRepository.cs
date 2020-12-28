using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;
using TesteLuby.Repository.Base;
using TesteLuby.Data.Context;
using System.Linq;

namespace TesteLuby.Repository.Projects
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContextData dbContextData) : base(dbContextData)
        {
        }

        public IEnumerable<Project> FindByName(string name)
        {
            return FindByQuery(x => x.Name.Contains(name)).AsEnumerable();
        }
    }
}
