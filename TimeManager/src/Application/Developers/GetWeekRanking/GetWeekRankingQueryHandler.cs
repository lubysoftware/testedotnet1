using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using TimeManager.Application.Common.Interfaces;
using TimeManager.Application.Common.Models;
using TimeManager.Domain;

namespace TimeManager.Application.Developers.GetWeekRanking
{
    public class GetWeekRankingQueryHandler : IRequestHandler<GetWeekRankingQuery, Response>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetWeekRankingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response> Handle(GetWeekRankingQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var thisWeek = DateTime.Now.WeekNumberOfTheYear();

            const string query = @"
                SELECT TOP 5
	                AVG(CalculatedHoursWorked) as AverageHoursWorked,
	                D.Id as Developer_Id,
	                D.Name as Developer_Name
                FROM TimeReports TR
                JOIN Developers D ON d.Id = TR.DeveloperId
                GROUP BY 
	                D.Id, D.Name, Tr.CalculatedWeekOfTheYear
                HAVING
	                CalculatedWeekOfTheYear = @Week
                ORDER BY
	                AverageHoursWorked DESC";

            var data = await connection.QueryAsync<dynamic>(query, new { Week = thisWeek });

            var realData = Slapper.AutoMapper.MapDynamic<RankingViewModel>(data);

            return new Response(realData);
        }
    }
}
