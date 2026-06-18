using Hours.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories.Users
{
    public interface IUserCommands
    {
        Task SaveAsync(UsersEntity data);
        Task UpdateAsync(UsersEntity data);
        Task DeleteAsync(Guid id);
    }
}