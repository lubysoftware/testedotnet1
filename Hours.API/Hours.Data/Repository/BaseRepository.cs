using Hours.Data.Context;
using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ContextDB _context;
        private DbSet<T> _dataset;

        public BaseRepository(ContextDB context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == id);
                if(result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }                
        }      

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                item.CreateAt = DateTime.UtcNow;

                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> GetAsync(int? id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(x=> x.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAsync()
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
    }
}
