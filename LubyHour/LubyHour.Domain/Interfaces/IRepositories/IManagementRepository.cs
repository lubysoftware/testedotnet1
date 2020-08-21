using LubyHour.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubyHour.Domain.Interfaces.IRepositories
{
    public interface IManagementRepository : IRepository
    {
        void Create(Management management);
        void Update(Management management);
        void Delete(Management management);
        Task<IEnumerable<Management>> GetAll();
        Task<Management> GetById(Guid id);
    }
}
