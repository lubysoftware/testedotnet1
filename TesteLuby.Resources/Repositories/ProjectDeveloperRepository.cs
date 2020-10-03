using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Context;
using TesteLuby.Resources.Contracts;

namespace Testeluby.ResourcesDB.Repositories
{
    public class ProjectDeveloperRepository : DapperRepository<ProjectDeveloper>, IRepository
    {
        public ProjectDeveloperRepository(IAppSettings appSettings) : base(appSettings)
        {
        }
    }
}