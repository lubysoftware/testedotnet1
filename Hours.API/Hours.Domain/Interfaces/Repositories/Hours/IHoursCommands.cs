using Hours.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories
{
    public interface IHoursCommands
    {
        Task SaveAsync(HoursEntity data);
        Task UpdateAsync(HoursEntity data);
        Task DeleteAsync(Guid id);
    }
}
