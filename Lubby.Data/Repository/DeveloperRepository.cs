using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lubby.Data.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly LubbyContext context;
        public DeveloperRepository(LubbyContext cx) => context = cx;
        public Task Create(Developer dev)
        {
            try
            {
                dev.Id = Guid.NewGuid().ToString();
                dev.CreationDate = DateTime.Now;
                return Task.FromResult(context.DeveloperSet.Add(dev));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Task Delete(string identifier)
        {
            try
            {
                Developer dev = context.DeveloperSet.FirstOrDefault(x => x.Id.Equals(identifier));
                dev.DetachmentDate = DateTime.Now;
                context.DeveloperSet.Update(dev);
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
        public Task<Developer> Get(string identifier) => Task.FromResult(context.DeveloperSet.FirstOrDefault(x => x.Id.Equals(identifier)));
        public Task<List<Developer>> List() => Task.FromResult(context.DeveloperSet.OrderBy(x => x.Name).ToList());

        public Task Update(Developer dev)
        {
            try
            {
                Developer devFromDb = context.DeveloperSet.FirstOrDefault(x => x.Id.Equals(dev.Id));
                devFromDb.Name = dev.Name;

                context.DeveloperSet.Update(dev);
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
