using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Lubby.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly LubbyContext context;
        public ProjectRepository(LubbyContext cx) => context = cx;
        
        public Task Create(Project project)
        {
            try
            {
                project.Id = Guid.NewGuid().ToString();
                project.CreationDate = DateTime.Now;
                context.ProjectSet.Add(project);
                return Task.FromResult(context.SaveChanges());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task  Delete(string identifier)
        {
            try
            {
                Project project = context.ProjectSet.FirstOrDefault(x => x.Id.Equals(identifier));
                project.DetachmentDate = DateTime.Now;
                context.ProjectSet.Update(project);
                return Task.FromResult(context.SaveChanges());
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public Task<Project> Get(string identifier) => Task.FromResult(context.ProjectSet.FirstOrDefault(x => x.Id.Equals(identifier)));

        public Task<List<Project>> List() => Task.FromResult(context.ProjectSet.OrderBy(x => x.CreationDate).ToList());

        public Task Update(Project project)
        {
            try
            {
                Project projectFromDb = context.ProjectSet.FirstOrDefault(x => x.Id.Equals(project.Id));
                projectFromDb.Name = project.Name;

                context.ProjectSet.Update(project);
                return Task.FromResult(context.SaveChanges());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
