using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Application.Common.Models;

namespace TimeManager.Application.Projects.GetProjects
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, Response>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetProjectsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string query = @"
                SELECT
	                Id,
	                Name
                FROM Projects";

            var data = await connection.QueryAsync<ProjectDto>(query);

            return new Response(data);
        }
    }
}
