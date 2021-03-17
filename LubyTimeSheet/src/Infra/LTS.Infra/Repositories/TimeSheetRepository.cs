using LTS.Domain.Base;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;
using LTS.Infra.Context;
using System.Threading.Tasks;

namespace LTS.Infra.Repositories
{
    public class TimeSheetRepository : RepositoryBase<TimeSheet>, ITimeSheetRepository
    {
        public TimeSheetRepository(LubyContext contexto) : base(contexto)
        {

        }

        public async Task<PagedList<TimeSheet>> GetProjectsPaginated(PaginationParameters paginationParameters)
        {
            return PagedList<TimeSheet>.ToPagedList(await GetAll(),
            paginationParameters.PageNumber,
            paginationParameters.PageSize);
        }
    }
}