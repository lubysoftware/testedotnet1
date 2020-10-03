using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Context;
using TesteLuby.Resources.Contracts;

namespace TesteLuby.Resources.Repositories
{
    public class DeveloperRepository : DapperRepository<Developer>, IRepository
    {
        public DeveloperRepository(IAppSettings appSettings) : base(appSettings)
        {
        }
    }
}