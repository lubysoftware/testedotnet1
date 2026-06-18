using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Repositories;
using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Domain.DTO;
using Hours.Domain.Shared.Helpers;
using Hours.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hours.Infra.Repository.Queries
{
    public class HoursQueries : IHoursQueries
    {
        private IRepository<HoursEntity> _repository;
        protected readonly ContextDB _db;

        public HoursQueries(IRepository<HoursEntity> repository, ContextDB db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<HoursEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HoursEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<HoursEntity>> GetAsync(HoursFilters filters)
        {
            var queryResponse = await (from h in _db.Hours
                                       select h).ToListAsync();

            if (filters.Id.ValidField())
                queryResponse = queryResponse.Where(x => x.Id.Equals(filters.Id)).ToList();

            if (filters.Developer.ValidField())
                queryResponse = queryResponse.Where(x => x.Developer.Contains(filters.Developer)).ToList();
           
            if (filters.StartDate.ToString().ValidDate())
            {
                var nDate = filters.StartDate.Value.AddMilliseconds(-1);
                queryResponse = queryResponse.Where(f => f.StartDate >= nDate).ToList();
            }
            if (filters.EndDate.ToString().ValidDate())
            {
                var nDate = filters.EndDate.Value.AddDays(1).AddSeconds(-1);
                queryResponse = queryResponse.Where(f => f.EndDate <= nDate).ToList();
            }

            return queryResponse;

        }

        public async Task<List<HoursDTO>> GetRankingDevsAsync()
        {
            var lDevelopersWeek = await GetDevelopersOfTheWeek();

            var queryResponse = (from prin in (from aa in lDevelopersWeek
                                               group aa by new { aa.Developer } into _gg
                                               select new
                                               {
                                                   _gg.Key.Developer,
                                                   HoursWorkedInTheWeek = _gg.Sum(x => x.HoursWorkedInTheWeek.Ticks),
                                                   CountRegister = _gg.Count()
                                               })
                                 select new HoursDTO
                                 {
                                     Developer = prin.Developer,
                                     HoursWorkedInTheWeek = TimeSpan.FromTicks(prin.HoursWorkedInTheWeek),
                                     AverageWorked = TimeSpan.FromTicks(prin.HoursWorkedInTheWeek / prin.CountRegister)
                                 }).Take(5).OrderByDescending(x => x.HoursWorkedInTheWeek).ToList();

            return queryResponse;
        }

        public async Task<List<HoursDTO>> GetDevelopersOfTheWeek()
        {
            //first day week
            DateTime firtsDayWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek).Date;

            var firstDayWeek = firtsDayWeek;
            var lastDayWeek = firtsDayWeek.AddDays(7).AddSeconds(-1);

            List<HoursDTO> queryDevelopersWeek = await _db.Hours
                                                   .Where(x => x.StartDate >= firstDayWeek && x.EndDate < lastDayWeek)
                                                   .OrderByDescending(x => x.Developer)
                                                   .AsNoTracking()
                                                   .Select(x => new HoursDTO
                                                   {
                                                       Developer = x.Developer,
                                                       HoursWorkedInTheWeek = x.EndDate - x.StartDate
                                                   }).ToListAsync();

            return queryDevelopersWeek;
        }
    }
}
