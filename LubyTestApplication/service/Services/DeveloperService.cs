using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain.Entities;
using test.domain.Interfaces.Repositories;
using test.domain.Interfaces.Services.DeveloperService;

namespace test.service.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _developerRepository.DeleteAsync(id);
        }

        public async Task<Developer> Get(Guid id)
        {
            return await _developerRepository.SelectAsync(id);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _developerRepository.SelectAsync();
        }

        public async Task<Developer> Post(Developer developer)
        {
            return await _developerRepository.InsertAsync(developer);
        }

        public async Task<Developer> Put(Developer developer)
        {
            return await _developerRepository.UpdateAsync(developer);
        }
    }
}
