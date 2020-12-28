using System;
using System.Collections.Generic;
using System.Linq;
using TesteLuby.Data.Context;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Repositories;
using TesteLuby.Repository.Base;

namespace TesteLuby.Repository.Developers
{
    public class DevelopersRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DevelopersRepository(DbContextData dbContextData) : base(dbContextData)
        {
        }

        public IEnumerable<Developer> FindByName(string name)
        {
            return FindByQuery(x => x.Name.Contains(name)).AsEnumerable();
        }
    }
}
