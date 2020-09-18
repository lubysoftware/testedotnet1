using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManager.Domain.Projects;
using TimeManager.Infrastructure.Persistence;

namespace TimeManager.Infrastructure.Domain.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdsAsync(Guid id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Projects.Where(p => p.Id == id).SingleOrDefaultAsync();

            _context.Projects.Remove(entity);

            await _context.SaveChangesAsync();
        }

    }
}
