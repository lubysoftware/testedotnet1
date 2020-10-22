using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.Persistence.SqlServer.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Persistences.SqlServer
{
    public class RegisterHoursRepository : SqlServerRepository, IRegisterHoursRepository
    {
        public RegisterHoursRepository(IConfiguration configuration)
            : base(configuration.GetConnectionString("SqlServerConnection"))
        {
        }

        public async Task Delete(long id)
        {
            const string query = "DELETE RegisterHour WHERE id = @id";

            await ExecuteAsync(query, new { id });
        }

        public async Task<RegisterHourModel> Find(long id)
        {
            const string query =
                @"SELECT 
                      Id
                    , StartDateTime
                    , EndDateTime
                    , DeveloperId
                FROM RegisterHour
                WHERE id = @id";

            return await FindFirstOrDefaultAsync<RegisterHourModel>(query, new { id });
        }

        public async Task<IEnumerable<RegisterHourModel>> FindAll()
        {
            const string query =
                @"SELECT 
                      Id
                    , StartDateTime
                    , EndDateTime
                    , DeveloperId
                FROM RegisterHour";

            return await FindAsync<RegisterHourModel>(query);
        }

        public async Task Save(RegisterHourModel registerHour)
        {
            const string query =
                @"INSERT INTO RegisterHour (StartDateTime, EndDateTime, DeveloperId)
                VALUES (@startDateTime, @endDateTime, @developerId)";

            await ExecuteAsync(query, registerHour);
        }

        public async Task Update(RegisterHourModel registerHour)
        {
            const string query =
                @"UPDATE RegisterHour 
                SET StartDateTime = @startDateTime
                    , EndDateTime = @endDateTime
                    , DeveloperId = @developerId
                WHERE id = @id";

            await ExecuteAsync(query, registerHour);
        }
    }
}
