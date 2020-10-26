using Hours.Domain.Entities;
using Hours.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UsersEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<UsersEntity>> GetAllAsync();
        Task<IEnumerable<UsersEntity>> GetAsync(UserFilters filter);
        Task SaveAsync(UsersEntity data);
        Task UpdateAsync(UsersEntity data);
        Task DeleteAsync(Guid id);
    }
}