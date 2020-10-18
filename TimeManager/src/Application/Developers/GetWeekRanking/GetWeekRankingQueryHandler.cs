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

            var data = await connection.QueryAsync<dynamic>(@"
                SELECT *
                INTO #Temp
                FROM (     
                    SELECT 
	                    SUM(TR.CalculatedHoursWorked) as SumWorkedDayHours,
	                    1 as DayCount,
	                    D.Id as 'Developer_Id',
	                    D.Name as 'Developer_Name'
                    FROM TimeReports TR
                    JOIN Developers D ON D.Id = TR.DeveloperId
                    WHERE TR.CalculatedWeekOfTheYear = @Week
                    GROUP BY TR.CalculatedWeekOfTheYear, D.Id, D.Name, TR.WeekDay ) t

                SELECT TOP 5
	                SUM(SumWorkedDayHours) / SUM(DayCount) AverageWorkedDayHours,
	                Developer_Id,
	                Developer_Name
                FROM #Temp
                GROUP BY Developer_Id, Developer_Name
                ORDER BY AverageWorkedDayHours DESC
            ", new { Week = thisWeek });

            var realData = Slapper.AutoMapper.MapDynamic<RankingViewModel>(data);

            return new Response(realData);
        }
    }
}
