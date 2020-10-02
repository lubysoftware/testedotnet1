using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Context;
using TesteLuby.Resources.Contracts;

namespace Testeluby.ResourcesDB.Repositories
{
    public class BusinessHourRepository: DapperRepository<Developer>, IRepository
    {
        public BusinessHourRepository(IAppSettings appSettings) : base(appSettings)
        {
        }
    }
}
