using Hours.Domain.Entities;
using Hours.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Interfaces.Repositories.Users
{
    public interface IUserQueries
    {
        Task<IEnumerable<UsersEntity>> GetAllAsync();
        Task<IEnumerable<UsersEntity>> GetAsync(UserFilters filters);
        Task<UsersEntity> GetByIdAsync(Guid id);
    }
}
