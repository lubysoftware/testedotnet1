using LubyHour.Domain.Entities;
using LubyHour.Domain.Interfaces;
using LubyHour.Domain.Interfaces.IRepositories;
using LubyHour.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubyHour.Infra.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private readonly DataContext _context;
        public ManagementRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Management management)
        {
            _context.Management.AddAsync(management);
            _context.SaveChanges();
        }

        public void Update(Management management)
        {
            _context.Entry(management).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Management management)
        {
            _context.Management.Remove(management);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Management>> GetAll()
        {
            return await _context.Management.AsNoTracking().ToListAsync();
        }

        public async Task<Management> GetById(Guid id)
        {
            return await _context.Management.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Management>> GetManagementsFromWeek()
        {
            return await _context.Management.AsNoTracking().Where(x => x.StartTime >= DateTime.Now.Date.AddDays(-7)).ToListAsync();
        }

    }
}
