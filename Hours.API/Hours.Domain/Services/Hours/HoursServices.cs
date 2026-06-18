using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Repositories;
using Hours.Domain.Interfaces.Services.Hours;
using Hours.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Services.Hours
{
    public class HoursServices : IHoursService
    {
        private readonly IHoursCommands _hoursCommands;
        private readonly IHoursQueries _hoursQueries;

        public HoursServices(IHoursCommands hoursCommands, IHoursQueries hoursQueries)
        {
            _hoursCommands = hoursCommands;
            _hoursQueries = hoursQueries;
        }

        public async Task<IEnumerable<HoursEntity>> GetAsync(HoursFilters filter)
        {
            return await _hoursQueries.GetAsync(filter);
        }

        public async Task<IEnumerable<HoursEntity>> GetAllAsync()
        {
            return await _hoursQueries.GetAllAsync();
        }

        public async Task<HoursEntity> GetByIdAsync(Guid id)
        {
            return await _hoursQueries.GetByIdAsync(id);
        }

        public async Task<List<HoursDTO>> GetRankingDevsAsync()
        {
            return await _hoursQueries.GetRankingDevsAsync();
        }

        public async Task SaveAsync(HoursEntity data)
        {
            await _hoursCommands.SaveAsync(data);
        }

        public async Task UpdateAsync(HoursEntity data)
        {
            await _hoursCommands.UpdateAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _hoursCommands.DeleteAsync(id);
        }
    }
}
