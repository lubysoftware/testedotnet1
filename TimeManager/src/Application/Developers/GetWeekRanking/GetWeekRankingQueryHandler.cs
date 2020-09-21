using System;
using System.Linq;
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

            var data = await connection.QueryAsync<dynamic>(@"
	            SELECT 
		            SUM(TR.CalculatedHoursWorked) as SumWorkedWeekHOurs,
		            MIN(TR.StartedAt) as FirstDayWorked,
		            MAX(TR.EndedAt) as LastDayWorked,
		            D.Id as 'Developer_Id',
		            D.Name as 'Developer_Name'
	            FROM TimeReports TR
	            JOIN Developers D ON D.Id = TR.DeveloperId
	            WHERE TR.CalculatedWeekOfTheYear = @Week
	            GROUP BY 
		            TR.CalculatedWeekOfTheYear, D.Id, D.Name
            ", new { Week = thisWeek });

            // @TODO
            // Considerar que há dias que não foram trabalhados no meio da semana
            var realData = Slapper.AutoMapper.MapDynamic<RankingViewModel>(data);

            // @TODO
            // Ordenação e TOP 5 na propria query
            realData.OrderByDescending(o => o.AverageHoursWorked);

            return new Response(realData);
        }
    }
}
