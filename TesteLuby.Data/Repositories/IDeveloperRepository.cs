using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Repositories
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        IEnumerable<Developer> FindByName(string name);
    }
}
