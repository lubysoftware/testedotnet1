using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using test.data.Context;
using test.domain.Entities;
using test.domain.Interfaces;

namespace test.data.Repository
{
    public class ProjectRepository : IRepository<Project>
    {
        protected readonly MyContext _context;
        private DbSet<Project> _dataset;
        public ProjectRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<Project>();
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

        public async Task<Project> InsertAsync(Project project)
        {
            try
            {
                if (project.Id == Guid.Empty)
                {
                    project.Id = Guid.NewGuid();
                }

                project.StartDate = DateTime.UtcNow;
                project.EndDate = DateTime.UtcNow;

                _context.Projects.Add(project);
                _dataset.Add(project);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return project;
        }

        public async Task<Project> SelectAsync(Guid id)
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

        public async Task<IEnumerable<Project>> SelectAsync()
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

        public async Task<Project> UpdateAsync(Project project)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(project.Id));
                if (result == null)
                {
                    return null;
                }

                project.StartDate = result.StartDate;
                project.EndDate = result.EndDate;
                project.Name = result.Name;

                _context.Entry(result).CurrentValues.SetValues(project);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return project;
        }
    }
}
