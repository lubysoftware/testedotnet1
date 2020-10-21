using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Infra.Context;

namespace TimeSheetManager.Infra.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly DataContext _context;

        public DeveloperRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id)
        {
            var dev = _context.Developers.Where(x => x.Id == id).First();
            _context.Developers.Remove(dev);
            await _context.SaveChangesAsync();
        }

        public async Task<Developer> Get(Guid id)
        {
            var dev = await _context.Developers.FirstOrDefaultAsync(x => x.Id == id);
            return dev;
        }

        public async Task<List<Developer>> GetAll()
        {
            var devs = await _context.Developers.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
            return devs;
        }

        public async Task Post(Developer developer)
        {
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();
        }
    }
}