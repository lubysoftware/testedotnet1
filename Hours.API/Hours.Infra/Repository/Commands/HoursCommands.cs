using Hours.Domain.Entities;
using Hours.Domain.Interfaces.Repositories;
using Hours.Domain.Interfaces.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace Hours.Infra.Repository.Commands
{
    public class HoursCommands : IHoursCommands
    {                
        private IRepository<HoursEntity> _repository;

        public HoursCommands(IRepository<HoursEntity> repository)
        {
            _repository = repository;
        }

        public async Task SaveAsync(HoursEntity data)
        {
             await _repository.InsertAsync(data);
        }

        public async Task UpdateAsync(HoursEntity data)
        {
            await _repository.UpdateAsync(data);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
