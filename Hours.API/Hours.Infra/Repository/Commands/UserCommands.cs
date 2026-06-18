using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Domain.Interfaces.Repositories.Users;
using System;
using System.Threading.Tasks;

namespace Hours.Infra.Repository.Commands
{
    public class UserCommands : IUserCommands
    {                
        private IRepository<UsersEntity> _repository;

        public UserCommands(IRepository<UsersEntity> repository)
        {
            _repository = repository;
        }

        public async Task SaveAsync(UsersEntity data)
        {
             await _repository.InsertAsync(data);
        }

        public async Task UpdateAsync(UsersEntity data)
        {
            await _repository.UpdateAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
