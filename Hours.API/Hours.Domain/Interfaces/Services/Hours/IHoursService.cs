﻿using Hours.Domain.DTO;
using Hours.Domain.Entities;
using Hours.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Services.Hours
{
    public interface IHoursService
    {
        Task SaveAsync(HoursEntity data);
        Task UpdateAsync(HoursEntity data);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<HoursEntity>> GetAllAsync();
        Task<IEnumerable<HoursEntity>> GetAsync(HoursFilters filter);
        Task<List<HoursDTO>> GetRankingDevsAsync();
        Task<HoursEntity> GetByIdAsync(Guid id);
    }
}
