using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeManager.Domain.Developers;
using TimeManager.Infrastructure.Persistence;

namespace TimeManager.Infrastructure.Domain.Developers
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Developer>> GetAllAsync()
        {
            return await _context.Developers.ToListAsync();
        }

        public async Task<Developer> GetByIdsAsync(Guid id)
        {
            return await _context.Developers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Developer developer)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Developers.Where(p => p.Id == id).SingleOrDefaultAsync();

            _context.Developers.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
