using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using test.domain.Entities;
using test.domain.Interfaces.Repositories;
using test.domain.Interfaces.Services.DeveloperService;

namespace test.service.Services
{
    public class HoursService : IHoursService
    {
        private readonly IHoursRepository _hoursRepository;

        public HoursService(IHoursRepository hoursRepository)
        {
            _hoursRepository = hoursRepository;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _hoursRepository.DeleteAsync(id);
        }

        public async Task<Hours> Get(Guid id)
        {
            return await _hoursRepository.SelectAsync(id);
        }

        public IEnumerable<Hours> GetByDeveloper(string developer)
        {
            return _hoursRepository.GetByDeveloper(developer);
        }

        public async Task<IEnumerable<Hours>> GetAll()
        {
            return await _hoursRepository.SelectAsync();
        }

        public async Task<Hours> Post(Hours hours)
        {
            return await _hoursRepository.InsertAsync(hours);
        }

        public async Task<Hours> Put(Hours hours)
        {
            return await _hoursRepository.UpdateAsync(hours);
        }
    }
}