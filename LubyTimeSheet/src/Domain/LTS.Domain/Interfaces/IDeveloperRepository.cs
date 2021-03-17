using LTS.Domain.Base;
using LTS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Domain.Interfaces
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<List<Developer>> GetAllWithHoursAsync();
        Task<PagedList<Developer>> GetDevelopersPaginated(PaginationParameters paginationParameters);
    }
}

