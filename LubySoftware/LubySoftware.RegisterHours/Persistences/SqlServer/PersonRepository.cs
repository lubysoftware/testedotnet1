using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.Persistence.SqlServer.Repositories;
using Microsoft.Extensions.Configuration;
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

        public async Task Delete(long id)
        {
            const string query = "DELETE Person WHERE id = @id";

            await ExecuteAsync(query, new { id });
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

        public async Task<IEnumerable<PersonModel>> FindAll()
        {
            const string query =
                @"SELECT 
                      Id
                    , Name
                FROM Person";

            return await FindAsync<PersonModel>(query);
        }

        public async Task Save(PersonModel person)
        {
            const string query =
                @"INSERT INTO Person (Name)
                VALUES (@name)";

            await ExecuteAsync(query, person);
        }

        public async Task Update(PersonModel person)
        {
            const string query =
                @"UPDATE RegisterHour 
                SET Name = @name
                WHERE id = @id";

            await ExecuteAsync(query, person);
        }
    }
}
