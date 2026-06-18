using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Hours.Infra.Repository.Base
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == id.ToString());
                if (result == null)
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
                if ((item.Id ?? "") == "")
                    item.Id = Guid.NewGuid().ToString();

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

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == item.Id);
                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;
                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(x => x.Id == (id.ToString()));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
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
