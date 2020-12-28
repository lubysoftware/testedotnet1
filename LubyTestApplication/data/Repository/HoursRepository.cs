using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using test.data.Context;
using test.domain.Entities;
using test.domain.Interfaces.Repositories;
using System.Linq;

namespace test.data.Repository
{
    public class HoursRepository : IHoursRepository
    {
        protected readonly MyContext _context;
        private DbSet<Hours> _dataset;
        public HoursRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Hours>();
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

      

        public async Task<Hours> InsertAsync(Hours hours)
        {
            try
            {
                _context.Hours.Add(hours);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hours;
        }



        public async Task<Hours> SelectAsync(Guid id)
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

        public IEnumerable<Hours> GetByDeveloper(string developer)
        {
            try
            {
                var query = (from d in _context.Hours
                            where d.Developer == developer
                            select d);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Hours>> SelectAsync()
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

        public async Task<Hours> UpdateAsync(Hours hours)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(hours.Id));
                if (result == null)
                {
                    return null;
                }

                hours.StartDate = result.StartDate;
                hours.EndDate = result.EndDate;
                hours.Developer = result.Developer;

                _context.Entry(result).CurrentValues.SetValues(hours);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return hours;
        }
    }
}
