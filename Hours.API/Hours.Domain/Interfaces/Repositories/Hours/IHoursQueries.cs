using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories
{
    public interface  IHoursQueries
    {
        Task<IEnumerable<HoursEntity>> GetAllAsync();
        Task<IEnumerable<HoursEntity>> GetAsync(HoursFilters filters);
        Task<List<HoursDTO>> GetRankingDevsAsync();
        Task<HoursEntity> GetByIdAsync(Guid id);
        Task<List<HoursDTO>> GetDevelopersOfTheWeek();
    }
}