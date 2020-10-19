using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheetManager.Domain.Entities.Project;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Infra.Context;

namespace TimeSheetManager.Infra.Repositories {
    public class ProjectRepository : IProjectRepository {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Delete(Guid id){
            var project = _context.Projects.Where(x => x.Id == id).First();
             _context.Projects.Remove(project);
             await _context.SaveChangesAsync();
        }

        public async Task<Project> Get(Guid id) {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return project;
        }

        public async Task<List<Project>> GetAll(){
            var projects = await _context.Projects.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
            return projects;
        }

        public async Task Post(Project project) {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Project project) {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}