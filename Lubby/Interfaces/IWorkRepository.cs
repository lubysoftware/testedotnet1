using Lubby.Domain.Root;
using Lubby.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Domain.Interfaces
{
    public interface IWorkRepository
    {
        Task Create(Work work);
        Task<List<WorkViewModel>> List();
       
    }
}
