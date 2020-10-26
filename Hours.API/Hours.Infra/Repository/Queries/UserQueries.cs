using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Repositories.Base;
using Hours.Domain.Interfaces.Repositories.Users;
using Hours.Domain.Shared.Helpers;
using Hours.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infra.Repository.Queries
{
    public class UserQueries : IUserQueries
    {
        private IRepository<UsersEntity> _repository;
        protected readonly ContextDB _db;

        public UserQueries(IRepository<UsersEntity> repository, ContextDB db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<UsersEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UsersEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UsersEntity> FindByLoginAsync(string email)
        {
            var queryResponse = await (from h in _db.Users
                                       where h.Email == email
                                       select h).FirstOrDefaultAsync();          

            return queryResponse;
        }

        public async Task<IEnumerable<UsersEntity>> GetAsync(UserFilters filters)
        {
            var queryResponse = await (from h in _db.Users
                                       select h).ToListAsync();

            if (filters.Id.ValidField())
                queryResponse = queryResponse.Where(x => x.Id.Equals(filters.Id)).ToList();

            if (filters.Name.ValidField())
                queryResponse = queryResponse.Where(x => x.Name.Equals(filters.Name)).ToList();

            if (filters.Email.ValidField())
                queryResponse = queryResponse.Where(x => x.Email.Equals(filters.Email)).ToList();         

            return queryResponse;

        }  
    }
}
