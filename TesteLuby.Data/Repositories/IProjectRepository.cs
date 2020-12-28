using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> FindByName(string name);
    }
}
