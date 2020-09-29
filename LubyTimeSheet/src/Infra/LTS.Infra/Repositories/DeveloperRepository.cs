using LTS.Domain.Base;
using LTS.Domain.Entities;
using LTS.Domain.Interfaces;
using LTS.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LTS.Infra.Repositories
{
    public class DeveloperRepository : RepositoryBase<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(LubyContext contexto) : base(contexto)
        {
        }

        public async Task<List<Developer>> GetAllWithHoursAsync() => await _dbSet.Include(x => x.TimeSheets).ToListAsync();

        public async Task<PagedList<Developer>> GetDevelopersPaginated(PaginationParameters paginationParameters)
        {
            return PagedList<Developer>.ToPagedList(await GetAll(),
             paginationParameters.PageNumber,
             paginationParameters.PageSize);
        }
    }
}
