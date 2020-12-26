using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.data.Context;
using test.domain.Entities;
using test.domain.Interfaces;
using test.domain.Interfaces.Repositories;

namespace test.data.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly MyContext _context;
        private DbSet<Developer> _dataset;
        public DeveloperRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Developer>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<Developer> InsertAsync(Developer developer)
        {
            try
            {
                if (developer.Id == Guid.Empty)
                {
                    developer.Id = Guid.NewGuid();
                }

                developer.StartDate = DateTime.UtcNow;
                developer.EndDate = DateTime.UtcNow;

                _context.Developers.Add(developer);
                _dataset.Add(developer);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return developer;
        }

        public async Task<Developer> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> UpdateAsync(Developer developer)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(developer.Id));
                if (result == null)
                {
                    return null;
                }

                developer.StartDate = result.StartDate;
                developer.EndDate = result.EndDate;
                developer.Name = result.Name;

                _context.Entry(result).CurrentValues.SetValues(developer);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return developer;
        }
    }
}
