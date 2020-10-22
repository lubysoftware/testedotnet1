using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.Persistence.SqlServer.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Persistences.SqlServer
{
    public class PersonRepository : SqlServerRepository, IPersonRepository
    {
        public PersonRepository(IConfiguration configuration)
            : base(configuration.GetConnectionString("SqlServerConnection"))
        {
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonModel> Find(long id)
        {
            const string query =
                @"SELECT 
                      Id
                    , Name
                FROM Person
                WHERE id = @id";

            return await FindFirstOrDefaultAsync<PersonModel>(query, new { id });
        }

        public Task<IEnumerable<PersonModel>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task Save(PersonModel registerHour)
        {
            throw new NotImplementedException();
        }

        public Task Update(PersonModel registerHour)
        {
            throw new NotImplementedException();
        }
    }
}
