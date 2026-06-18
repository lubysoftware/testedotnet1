using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Repositories.Users;
using Hours.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Domain.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;

        public UserService(IUserCommands userCommands, IUserQueries userQueries)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
        }

        public async Task DeleteAsync(Guid id)
        {
             await _userCommands.DeleteAsync(id);
        }

        public async Task<UsersEntity> FindByLoginAsync(string email)
        {
            return await _userQueries.FindByLoginAsync(email);
        }

        public async Task<IEnumerable<UsersEntity>> GetAllAsync()
        {
            return await _userQueries.GetAllAsync();
        }

        public async Task<IEnumerable<UsersEntity>> GetAsync()
        {
            return await _userQueries.GetAllAsync();
        }

        public async Task<IEnumerable<UsersEntity>> GetAsync(UserFilters filter)
        {
            return await _userQueries.GetAsync(filter);
        }

        public async Task<UsersEntity> GetByIdAsync(Guid id)
        {
            return await _userQueries.GetByIdAsync(id);
        }

        public async Task SaveAsync(UsersEntity data)
        {
             await _userCommands.SaveAsync(data);
        }

        public async Task UpdateAsync(UsersEntity data)
        {
             await _userCommands.UpdateAsync(data);
        }
    }
}
