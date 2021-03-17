using LTS.Domain.Base;
using LTS.Domain.Entities;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface ITimeSheetRepository : IRepository<TimeSheet>
    {
        Task<PagedList<TimeSheet>> GetProjectsPaginated(PaginationParameters paginationParameters);
    }
}
