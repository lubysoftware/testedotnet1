using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories
{
    public interface  IHoursQueries
    {
        Task<IEnumerable<HoursEntity>> GetAllAsync();
        Task<IEnumerable<HoursEntity>> GetAsync(HoursFilters filters);
        Task<List<HoursModelsResponse>> GetRankingDevsAsync();
        Task<HoursEntity> GetByIdAsync(Guid id);
        Task<List<HoursModelsResponse>> GetDevelopersOfTheWeek();
    }
}