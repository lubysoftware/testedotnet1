using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using Lubby.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lubby.Data.Repository
{
    public class WorkRepository : IWorkRepository
    {
        private readonly LubbyContext context;
        public WorkRepository(LubbyContext cx) => context = cx;

        public Task Create(Work work)
        {
            try
            {
                work.WorkId = Guid.NewGuid().ToString();
                context.WorkSet.Add(work);
                return Task.FromResult(context.SaveChanges());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Task<List<WorkViewModel>> List()
        {
            var ret = (from work in context.WorkSet.Include(x => x.Dev)
                       join dev in context.DeveloperSet on work.Dev.Id equals dev.Id
                       group work by new { work.Dev } into result
                       select new
                       {
                           result.Key.Dev.Name,
                           Horas = result.Select(x => x.EndDate.Value.Subtract(x.StartDate))
                       });
            var resultList = new List<WorkViewModel>();
            foreach (var item in ret)
            {
                resultList.Add(new WorkViewModel { Horas = item.Horas, Name = item.Name });
            }

            return Task.FromResult(resultList.Take(5).ToList());
        }
    }
}
