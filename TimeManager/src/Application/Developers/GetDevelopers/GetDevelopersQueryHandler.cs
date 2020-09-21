using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Developers.GetDevelopers
{
    public class GetDevelopersQueryHandler : IRequestHandler<GetDevelopersQuery, Response>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetDevelopersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response> Handle(GetDevelopersQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string query = @"
                SELECT
	                Id,
	                Name
                FROM Developers";

            var data = await connection.QueryAsync<DeveloperDto>(query);

            return new Response(data);
        }
    }
}
